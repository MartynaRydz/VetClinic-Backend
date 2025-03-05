using VetClinicBackend.Model;

namespace VetClinicBackend.Service.OwnerService;

public interface IOwnerService
{
    bool DeleteOwner(int id);
    bool AddOwner(OwnerDto pet);
    bool EditOwner(OwnerDto pet);
    IEnumerable<OwnerDto> GetOwners();
}
