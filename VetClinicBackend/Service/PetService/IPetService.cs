using VetClinicBackend.Model;

namespace VetClinicBackend.Service.PetService;

public interface IPetService
{
    bool DeletePet(int id);
    bool AddPet(PetDto pet);
    bool EditPet(PetDto pet);
    IEnumerable<PetDto> GetPets();
    PetDto GetPet(int id);
}


