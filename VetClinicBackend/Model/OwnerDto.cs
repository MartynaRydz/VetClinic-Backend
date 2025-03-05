using VetClinicBackend.DbModels;

namespace VetClinicBackend.Model;

public class OwnerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public Address Address { get; set; }
}
