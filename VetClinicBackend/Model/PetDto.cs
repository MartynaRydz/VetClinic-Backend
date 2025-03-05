namespace VetClinicBackend.Model;

public class PetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Species { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public DateTime YearOfBirth { get; set; }
    public OwnerDto Owner { get; set; } = null!;
}
