using Microsoft.EntityFrameworkCore;
using VetClinicBackend.Conversion;
using VetClinicBackend.Database;
using VetClinicBackend.DbModels;
using VetClinicBackend.Model;

namespace VetClinicBackend.Service.PetService;

public class PetService(VetClinicDbContext dbContext) : IPetService
{
    public IEnumerable<PetDto> GetPets()
    {
        var list = dbContext.Pet
            .Include(x => x.Gender)
            .Include(x => x.Species)
            .Include(x=> x.Owner)
            .Where(x => !x.IsDeleted).ToList();
        if (list is null)
        {
            throw new Exception("Pets not found");
        }

        var petDtoList = list.Select(PetConversion.Convert);
        return petDtoList;
    }
    public PetDto GetPet(int id)
    {
        var pet = dbContext.Pet
            .Include(x => x.Gender)
            .Include(x => x.Species)
            .Include(x => x.Owner)
            .FirstOrDefault(x => !x.IsDeleted && x.Id == id);
        if (pet is null)
        {
            throw new Exception("Pets not found");
        }

        var petDto = PetConversion.Convert(pet);
        return petDto;
    }

    public bool AddPet(PetDto pet)
    {
        //try
        //{
        //    var petdb = PetConversion.Convert(pet);
        //    dbContext.Pet.Add(petdb);
        //    dbContext.SaveChanges();
        //    return true;
        //}
        //catch (Exception ex)
        //{
        //    return false;
        //}
        var petdb = PetConversion.Convert(pet);
        dbContext.Pet.Add(petdb);
        dbContext.SaveChanges();
        return true;
    }

    public bool EditPet(PetDto pet)
    {
        try
        {
            var petdb = PetConversion.Convert(pet);
            var existingPet = dbContext.Pet.FirstOrDefault(p => p.Id == petdb.Id);
            if (existingPet != null)
            {
                existingPet.Name = pet.Name;
                var species = dbContext.Species.FirstOrDefault(p => p.Name == pet.Species);
                if (species is null)
                {
                    dbContext.Species.Add(new Species()
                    {
                        Name = pet.Name,
                    });
                    dbContext.SaveChanges();
                    species = dbContext.Species.FirstOrDefault(p => p.Name == pet.Species);
                }
                existingPet.Species = species!;
                var gender = dbContext.Gender.FirstOrDefault(p => p.Name == pet.Gender);
                if (gender is null)
                {
                    throw new Exception("Gender not found");
                }
                existingPet.Gender = gender;
                existingPet.YearOfBirth = pet.YearOfBirth;
            }
            else
            {
                dbContext.Pet.Add(petdb);
            }
            dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeletePet(int id)
    {
        var existingPet = dbContext.Pet.FirstOrDefault(pet => pet.Id == id);
        if (existingPet != null)
        {
            existingPet.IsDeleted = true;
        }
        dbContext.SaveChanges();
        return true;
    }
}
