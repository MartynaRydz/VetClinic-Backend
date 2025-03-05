namespace VetClinicBackend.DbModels;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Species Species { get; set; } = null!;
    public Gender Gender { get; set; } = null!;
    public DateTime YearOfBirth { get; set; }
    public bool IsDeleted { get; set; } = false;
    public Owner Owner { get; set; } = null!;
    public int OwnerId { get; set; }
}
