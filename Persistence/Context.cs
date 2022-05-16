using Core;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public sealed class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public DbSet<Material> Materials { get; set; }
    public DbSet<Technology> Technologies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Material>()
            .HasMany(m => m.Children)
            .WithOne()
            .HasForeignKey(m => m.ParentId)
            .OnDelete(DeleteBehavior.NoAction);
        
        Material mat6 = new Material
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
            Name = "Цикл while",
            IsAvailable = true,
            ParentId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
        };
        Material mat5 = new Material
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
            Name = "Цикл foreach",
            ParentId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
        };
        Material mat4 = new Material 
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
            Name = "Цикл for",
            ParentId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
            IsAvailable = true
        };
        Material mat3 = new Material
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
            Name = "Циклы",
            ParentId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            IsSectionParent = true,
            IsAvailable = true
        };
        Material mat2 = new Material
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            Name = "Массивы",
            ParentId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            IsCompleted = true,
            IsAvailable = true
        };
        Material mat1 = new Material
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Name = "Переменные",
            ParentId = null,
            IsCompleted = true,
            IsAvailable = true
        };
        Technology tech1 = new Technology
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Name = "C#",
            RootMaterialId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
        };
        
        modelBuilder.Entity<Material>().HasData(mat1,mat2,mat3,mat4);
        modelBuilder.Entity<Technology>().HasData(tech1);
    }
}