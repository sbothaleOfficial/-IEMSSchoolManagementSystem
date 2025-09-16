using Microsoft.EntityFrameworkCore;
using IEMS.Core.Entities;

namespace IEMS.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Class> Classes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.RollNumber).IsRequired().HasMaxLength(20);
            entity.HasIndex(e => e.RollNumber).IsUnique();
            entity.HasIndex(e => e.Email).IsUnique();

            entity.HasOne(e => e.Class)
                  .WithMany(c => c.Students)
                  .HasForeignKey(e => e.ClassId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.EmployeeId).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Subject).IsRequired().HasMaxLength(100);
            entity.HasIndex(e => e.EmployeeId).IsUnique();
            entity.HasIndex(e => e.Email).IsUnique();
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Section).IsRequired().HasMaxLength(10);

            entity.HasOne(e => e.Teacher)
                  .WithMany(t => t.Classes)
                  .HasForeignKey(e => e.TeacherId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>().HasData(
            new Teacher { Id = 1, FirstName = "John", LastName = "Smith", Email = "john.smith@school.edu", EmployeeId = "T001", Subject = "Mathematics" },
            new Teacher { Id = 2, FirstName = "Sarah", LastName = "Johnson", Email = "sarah.johnson@school.edu", EmployeeId = "T002", Subject = "English" }
        );

        modelBuilder.Entity<Class>().HasData(
            new Class { Id = 1, Name = "Grade 10", Section = "A", TeacherId = 1 },
            new Class { Id = 2, Name = "Grade 10", Section = "B", TeacherId = 2 }
        );

        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, FirstName = "Alice", LastName = "Brown", Email = "alice.brown@student.edu", DateOfBirth = new DateTime(2008, 5, 15), RollNumber = "S001", ClassId = 1 },
            new Student { Id = 2, FirstName = "Bob", LastName = "Wilson", Email = "bob.wilson@student.edu", DateOfBirth = new DateTime(2008, 8, 22), RollNumber = "S002", ClassId = 1 },
            new Student { Id = 3, FirstName = "Charlie", LastName = "Davis", Email = "charlie.davis@student.edu", DateOfBirth = new DateTime(2008, 12, 3), RollNumber = "S003", ClassId = 2 }
        );
    }
}