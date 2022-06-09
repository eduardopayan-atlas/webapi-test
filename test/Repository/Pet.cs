using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository;

public class Pet
{
    public int OwnerId { get; set; }
    public int AnimalId { get; set; }
    public Person Owner { get; set; }
    public Animal Animal { get; set; }
    
}

internal class PetConfig : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("Pet");
        builder.HasKey(p => new {p.OwnerId, p.AnimalId});

        builder.HasOne(p => p.Owner).WithMany(p => p.Pets).HasForeignKey(p=>p.OwnerId);
        builder.HasOne(p => p.Animal).WithMany().HasForeignKey(p=>p.AnimalId);
    }
}