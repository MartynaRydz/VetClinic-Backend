using Microsoft.EntityFrameworkCore;
using VetClinicBackend.Conversion;
using VetClinicBackend.Database;
using VetClinicBackend.Model;

namespace VetClinicBackend.Service.OwnerService;

public class OwnerService : IOwnerService
{
    private readonly VetClinicDbContext dbContext;

    public OwnerService(VetClinicDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<OwnerDto> GetOwners()
    {
        var list = dbContext.Owner
            .Include(x => x.Address) 
            .Where(x => !x.IsDeleted).ToList();
        if (list is null)
        {
            throw new Exception("Owners not found");
        }

        var ownerDtoList = list.Select(OwnerConversion.Convert);
        return ownerDtoList;
    }

    public OwnerDto GetOwnerById(int id)
    {
        var owner = dbContext.Owner
            .Include(x => x.Address) 
            .FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        if (owner == null)
        {
            throw new Exception("Owner not found");
        }
        return OwnerConversion.Convert(owner);
    }

    public bool AddOwner(OwnerDto ownerDto)
    {
        try
        {
            var owner = OwnerConversion.Convert(ownerDto);
            dbContext.Owner.Add(owner);
            dbContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool EditOwner(OwnerDto ownerDto)
    {
        try
        {
            var existingOwner = dbContext.Owner.FirstOrDefault(o => o.Id == ownerDto.Id);
            if (existingOwner != null)
            {
                existingOwner.Name = ownerDto.Name;
                existingOwner.Surname = ownerDto.Surname;
                existingOwner.PhoneNumber = ownerDto.PhoneNumber;

               
                if (ownerDto.Address != null)
                {
                    var address = dbContext.Address.FirstOrDefault(a => a.Id == ownerDto.Address.Id);
                    if (address != null)
                    {
                        existingOwner.Address = address;
                    }
                    else
                    {
                        
                        dbContext.Address.Add(ownerDto.Address);
                        dbContext.SaveChanges();
                        existingOwner.Address = dbContext.Address.FirstOrDefault(a => a.Id == ownerDto.Address.Id);
                    }
                }
            }
            else
            {
                var newOwner = OwnerConversion.Convert(ownerDto);
                dbContext.Owner.Add(newOwner);
            }
            dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteOwner(int id)
    {
        var existingOwner = dbContext.Owner.FirstOrDefault(o => o.Id == id);
        if (existingOwner != null)
        {
            existingOwner.IsDeleted = true;
            dbContext.SaveChanges();
            return true;
        }
        return false;
    }
}
