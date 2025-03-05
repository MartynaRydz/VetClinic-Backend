using VetClinicBackend.DbModels;
using VetClinicBackend.Model;

namespace VetClinicBackend.Conversion;

public static class PetConversion
{
    public static PetDto Convert(Pet pet)
    {
        return new PetDto()
        {
            Id = pet.Id,
            Name = pet.Name,
            Gender = pet.Gender.Name,
            Species = pet.Species.Name,
            YearOfBirth = pet.YearOfBirth,
            Owner = OwnerConversion.Convert(pet.Owner)
        };
    }

    public static Pet Convert(PetDto pet)
    {
        return new Pet()
        {
            Id = pet.Id,
            Name = pet.Name,
            Gender = new Gender() { Name = pet.Gender },
            Species = new Species() { Name = pet.Species },
            YearOfBirth = pet.YearOfBirth,
            Owner = OwnerConversion.Convert(pet.Owner),
        };
    }
}
