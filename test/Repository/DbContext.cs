using Microsoft.EntityFrameworkCore;

namespace Repository;

public class CustomDbContext:DbContext
{
    public CustomDbContext(DbContextOptions<CustomDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(assembly: typeof(CustomDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseLazyLoadingProxies(false);
    }
    public virtual DbSet<Person> Persons { get; set; }
    public virtual DbSet<Animal> Animals { get; set; }
    public virtual DbSet<Pet> Pets { get; set; }
}