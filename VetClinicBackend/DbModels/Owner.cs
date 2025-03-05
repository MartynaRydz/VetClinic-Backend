namespace VetClinicBackend.DbModels;

public class Owner
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public bool IsDeleted { get; set; } = false;
    public ICollection<Pet> Pets { get; set; } = [];
}
