using Microsoft.EntityFrameworkCore;
using VetClinicBackend.DbModels;

namespace VetClinicBackend.Database;

public class VetClinicDbContext : DbContext
{
    public virtual DbSet<Gender> Gender { get; set; }
    public virtual DbSet<Species> Species { get; set; }
    public virtual DbSet<Pet> Pet { get; set; }
    public virtual DbSet<Owner> Owner { get; set; }
    public virtual DbSet<Address> Address { get; set; }

    public VetClinicDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Species>((builder) =>
        {
            builder.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Gender>((builder) =>
        {
            builder.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Pet>((builder) =>
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(100);
            builder.HasOne(e => e.Gender);
            builder.HasOne(e => e.Species);
            builder.HasOne(e => e.Owner)
                .WithMany(o => o.Pets); 
        });

        modelBuilder.Entity<Owner>((builder) =>
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(100);
            builder.Property(e => e.Surname).HasMaxLength(100);
            builder.Property(e => e.PhoneNumber).HasMaxLength(15);
            builder.HasOne(e => e.Address);
        });

        modelBuilder.Entity<Address>((builder) =>
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Street).HasMaxLength(200);
            builder.Property(e => e.HouseNumber).HasMaxLength(20);
            builder.Property(e => e.City).HasMaxLength(100);
            builder.Property(e => e.Country).HasMaxLength(100);
        });
    }
}
