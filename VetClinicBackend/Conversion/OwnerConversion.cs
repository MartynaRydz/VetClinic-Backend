using VetClinicBackend.DbModels;
using VetClinicBackend.Model;

namespace VetClinicBackend.Conversion;

public static class OwnerConversion
{
    public static OwnerDto Convert(Owner owner)
    {
        return new OwnerDto()
        {
            Name = owner.Name,
            Surname = owner.Surname,
            PhoneNumber = owner.PhoneNumber,
            Address = owner.Address,
            Id = owner.Id
        };
    }

    public static Owner Convert(OwnerDto ownerDto)
    {
        return new Owner()
        {
            Name = ownerDto.Name,
            Surname = ownerDto.Surname,
            PhoneNumber = ownerDto.PhoneNumber,
            Address = ownerDto.Address,
            Id = ownerDto.Id
        };
    }
}
