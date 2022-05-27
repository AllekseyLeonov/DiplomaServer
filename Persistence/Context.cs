using Core;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public sealed class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }

    public DbSet<Material> Materials { get; set; }
    public DbSet<Technology> Technologies { get; set; }
    public DbSet<Theory> Theories { get; set; }
    public DbSet<Practice> Practices { get; set; }
    public DbSet<Code> Codes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Dialog> Dialogs { get; set; }
 
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
        
        modelBuilder
            .Entity<User>()
            .HasMany(u => u.CompletedMaterials)
            .WithMany(m => m.UsersWhoHasAccess)
            .UsingEntity(j => j.HasData(
                new
                {
                    UsersWhoHasAccessId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    CompletedMaterialsId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                }, 
                new
                {
                    UsersWhoHasAccessId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    CompletedMaterialsId = Guid.Parse("00000000-0000-0000-0000-000000000002"), 
                },
                new
                {
                    UsersWhoHasAccessId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    CompletedMaterialsId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                })
            );
        modelBuilder.Entity<Practice>()
            .HasOne(p => p.Moderator)
            .WithMany()
            .HasForeignKey(p => p.ModeratorId);
        
        modelBuilder.Entity<Message>()
            .HasOne<Dialog>()
            .WithMany(d => d.Messages)
            .HasForeignKey(m => m.DialogId);
        modelBuilder.Entity<Message>()
            .HasOne(m => m.Sender)
            .WithMany()
            .HasForeignKey(m => m.SenderId);
        modelBuilder.Entity<Dialog>()
            .HasOne(d => d.Moderator)
            .WithMany()
            .HasForeignKey(d=>d.ModeratorId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Dialog>()
            .HasOne(d => d.User)
            .WithMany()
            .HasForeignKey(d=>d.UserId)
            .OnDelete(DeleteBehavior.NoAction);;
        
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
            PracticeId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
        };
        Material mat1 = new Material
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Name = "Переменные",
            Description = "Для хранения данных в программе применяются переменные. Переменная представляет именнованную область памяти, в которой хранится значение определенного типа. Переменная имеет тип, имя и значение. Тип определяет, какого рода информацию может хранить переменная.",
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
            Title = "Переменные",
            ModeratorId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
        };
        Practice practice2 = new Practice
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            Description = "задачи про переменные",
            TheoryId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            Title = "Переменные",
            ModeratorId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
        };
        Code code1 = new Code()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            StaticPart = "bool functionThatReturnsTrue(){<inner>} <outer>",
            Tests = "functionThatReturnsTrue() == true",
            PracticeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
        };
        Code code2 = new Code()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            StaticPart = "bool functionThatReturnsTrue(){<inner>} <outer>",
            Tests = "functionThatReturnsTrue() == true",
            PracticeId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
        };
        Theory theory1 = new Theory
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Filename = "theory1.html",
        };
        Theory theory2 = new Theory
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            Filename = "theory1.html",
        };
        User user = new User
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Name = "regular",
            Login = "login",
            Password = "password",
            Role = "regular"
        };
        User moderator = new User
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            Name = "moderator",
            Login = "moderator",
            Password = "password",
            Role = "moderator"
        };
        Dialog dialog1 = new Dialog
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            ModeratorId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
        };
        Dialog dialog2 = new Dialog
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            ModeratorId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
        };
        Message message1 = new Message
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            DialogId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            DateTime = DateTime.Now,
            SenderId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Text = "Hi! I have a question..."
        };
        Message message2 = new Message
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            DialogId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            DateTime = DateTime.Now,
            SenderId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            Text = "Hi! How I can help you?"
        };
        Message message3 = new Message
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
            DialogId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            DateTime = DateTime.Now,
            SenderId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Text = "Hello! How to solve this..."
        };
        Message message4 = new Message
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
            DialogId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            DateTime = DateTime.Now,
            SenderId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            Text = "Hello! You should try foreach cycle"
        };
        Message message5 = new Message
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
            DialogId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            DateTime = DateTime.Now,
            SenderId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Text = "Thanks"
        };
        
        modelBuilder.Entity<Theory>().HasData(theory1, theory2);
        modelBuilder.Entity<Practice>().HasData(practice1, practice2);
        modelBuilder.Entity<Material>().HasData(mat1, mat2, mat3, mat4, mat5, mat6);
        modelBuilder.Entity<Technology>().HasData(tech1);
        modelBuilder.Entity<Code>().HasData(code1, code2);
        modelBuilder.Entity<User>().HasData(user, moderator);
        modelBuilder.Entity<Dialog>().HasData(dialog1, dialog2);
        modelBuilder.Entity<Message>().HasData(message1, message2, message3, message4, message5);
    }
}