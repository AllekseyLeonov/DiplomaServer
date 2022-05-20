using Core;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public sealed class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DbSet<Material> Materials { get; set; }
    public DbSet<Technology> Technologies { get; set; }
    public DbSet<Theory> Theories { get; set; }
    public DbSet<Practice> Practices { get; set; }
    public DbSet<Code> Codes { get; set; }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Material>()
            .HasMany(m => m.Children)
            .WithOne()
            .HasForeignKey(m => m.ParentId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Practice>()
            .HasOne(p => p.Theory)
            .WithOne(t => t.Practice)
            .HasForeignKey<Practice>(p => p.TheoryId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<Material>()
            .HasOne(m => m.Practice)
            .WithOne(p => p.Material)
            .HasForeignKey<Material>(m => m.PracticeId);
        
        modelBuilder.Entity<Material>()
            .HasOne(m => m.Theory)
            .WithOne(t => t.Material)
            .HasForeignKey<Material>(m => m.TheoryId);
        
        modelBuilder.Entity<Code>()
            .HasOne(c => c.Practice)
            .WithOne(p => p.Code)
            .HasForeignKey<Code>(c => c.PracticeId);

        Material mat6 = new Material
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
            Name = "Цикл while",
            Description = "Краткое описание того, что будет в этом материале",
            IsAvailable = true,
            ParentId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
        };
        Material mat5 = new Material
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
            Name = "Цикл foreach",
            Description = "Краткое описание того, что будет в этом материале",
            ParentId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
        };
        Material mat4 = new Material 
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
            Name = "Цикл for",
            Description = "Краткое описание того, что будет в этом материале",
            ParentId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
            IsAvailable = true,
        };
        Material mat3 = new Material
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
            Name = "Циклы",
            Description = "Краткое описание того, что будет в этом материале",
            ParentId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            IsSectionParent = true,
            IsAvailable = true,
        };
        Material mat2 = new Material
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            Name = "Массивы",
            Description = "Краткое описание того, что будет в этом материале",
            ParentId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            IsCompleted = true,
            IsAvailable = true,
        };
        Material mat1 = new Material
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Name = "Переменные",
            Description = "Краткое описание того, что будет в этом материале",
            ParentId = null,
            IsCompleted = true,
            IsAvailable = true,
            TheoryId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            PracticeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
        };
        Technology tech1 = new Technology
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Name = "C#",
            RootMaterialId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
        };
        Practice practice1 = new Practice
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Description = "задачи про переменные",
            TheoryId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Title = "Переменные"
        };
        Code code1 = new Code()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            StaticPart = "bool functionThatReturnsTrue(){<inner>} <outer>",
            Tests = "functionThatReturnsTrue() == true",
            PracticeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
        };
        Theory theory1 = new Theory
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Filename = "theory1.html",
        };
        
        modelBuilder.Entity<Theory>().HasData(theory1);
        modelBuilder.Entity<Practice>().HasData(practice1);
        modelBuilder.Entity<Material>().HasData(mat1, mat2, mat3, mat4, mat5, mat6);
        modelBuilder.Entity<Technology>().HasData(tech1);
        modelBuilder.Entity<Code>().HasData(code1);
    }
}