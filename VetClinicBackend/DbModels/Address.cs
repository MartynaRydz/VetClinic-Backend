namespace VetClinicBackend.DbModels;

public class Address
{
    public int Id { get; set; }
    public string Street { get; set; } = null!;
    public string HouseNumber { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
}
