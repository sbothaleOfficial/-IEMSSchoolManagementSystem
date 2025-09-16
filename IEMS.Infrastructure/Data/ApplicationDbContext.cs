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
    public DbSet<Staff> Staff { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.SerialNo).IsRequired();
            entity.Property(e => e.Standard).IsRequired().HasMaxLength(20);
            entity.Property(e => e.ClassDivision).IsRequired().HasMaxLength(10);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.FatherName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Surname).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Gender).IsRequired().HasMaxLength(10);
            entity.Property(e => e.MotherName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.StudentNumber).IsRequired().HasMaxLength(20);
            entity.Property(e => e.CasteCategory).HasMaxLength(30);
            entity.Property(e => e.Religion).HasMaxLength(30);
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.ParentMobileNumber).HasMaxLength(15);
            entity.HasIndex(e => e.StudentNumber).IsUnique();
            entity.HasIndex(e => e.SerialNo).IsUnique();

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

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.EmployeeId).IsRequired().HasMaxLength(20);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15);
            entity.Property(e => e.Gender).IsRequired().HasMaxLength(10);
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Position).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Department).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Status).IsRequired().HasMaxLength(20);
            entity.Property(e => e.EmergencyContact).HasMaxLength(50);
            entity.Property(e => e.EmergencyContactPhone).HasMaxLength(15);
            entity.Property(e => e.Qualifications).HasMaxLength(200);
            entity.Property(e => e.Experience).HasMaxLength(50);
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.Salary).HasColumnType("decimal(18,2)");
            entity.HasIndex(e => e.EmployeeId).IsUnique();
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
            new Student
            {
                Id = 1, SerialNo = 1, Standard = "10th", ClassDivision = "A",
                FirstName = "Alice", FatherName = "Robert Brown", Surname = "Brown",
                DateOfBirth = new DateTime(2008, 5, 15), Gender = "Female",
                MotherName = "Mary Brown", StudentNumber = "S001",
                AdmissionDate = new DateTime(2023, 6, 1), CasteCategory = "General",
                Religion = "Christian", IsBPL = false, IsSemiEnglish = true,
                Address = "123 Main St, City", ParentMobileNumber = "9876543210", ClassId = 1
            },
            new Student
            {
                Id = 2, SerialNo = 2, Standard = "10th", ClassDivision = "A",
                FirstName = "Bob", FatherName = "David Wilson", Surname = "Wilson",
                DateOfBirth = new DateTime(2008, 8, 22), Gender = "Male",
                MotherName = "Susan Wilson", StudentNumber = "S002",
                AdmissionDate = new DateTime(2023, 6, 1), CasteCategory = "OBC",
                Religion = "Hindu", IsBPL = true, IsSemiEnglish = false,
                Address = "456 Oak Ave, City", ParentMobileNumber = "9876543211", ClassId = 1
            },
            new Student
            {
                Id = 3, SerialNo = 3, Standard = "10th", ClassDivision = "B",
                FirstName = "Charlie", FatherName = "Michael Davis", Surname = "Davis",
                DateOfBirth = new DateTime(2008, 12, 3), Gender = "Male",
                MotherName = "Jennifer Davis", StudentNumber = "S003",
                AdmissionDate = new DateTime(2023, 6, 1), CasteCategory = "SC",
                Religion = "Hindu", IsBPL = true, IsSemiEnglish = true,
                Address = "789 Pine Rd, City", ParentMobileNumber = "9876543212", ClassId = 2
            }
        );

        modelBuilder.Entity<Staff>().HasData(
            new Staff
            {
                Id = 1, EmployeeId = "ST001", FirstName = "Rajesh", LastName = "Kumar",
                Email = "rajesh.kumar@school.edu", PhoneNumber = "9876543213",
                DateOfBirth = new DateTime(1985, 3, 15), Gender = "Male",
                Address = "101 Transport Ave, City", Position = "Bus Driver", Department = "Transport",
                HireDate = new DateTime(2020, 4, 1), Salary = 25000, Status = "Active",
                EmergencyContact = "Sunita Kumar", EmergencyContactPhone = "9876543214",
                Qualifications = "Commercial Driving License", Experience = "8 years",
                Remarks = "Excellent safety record"
            },
            new Staff
            {
                Id = 2, EmployeeId = "ST002", FirstName = "Kamala", LastName = "Devi",
                Email = "kamala.devi@school.edu", PhoneNumber = "9876543215",
                DateOfBirth = new DateTime(1978, 7, 22), Gender = "Female",
                Address = "202 Clean St, City", Position = "Cleaner", Department = "Maintenance",
                HireDate = new DateTime(2018, 6, 15), Salary = 18000, Status = "Active",
                EmergencyContact = "Ram Lal", EmergencyContactPhone = "9876543216",
                Qualifications = "10th Pass", Experience = "12 years",
                Remarks = "Dedicated and hardworking"
            },
            new Staff
            {
                Id = 3, EmployeeId = "ST003", FirstName = "Suresh", LastName = "Singh",
                Email = "suresh.singh@school.edu", PhoneNumber = "9876543217",
                DateOfBirth = new DateTime(1982, 11, 8), Gender = "Male",
                Address = "303 Security Lane, City", Position = "Security Guard", Department = "Security",
                HireDate = new DateTime(2019, 8, 1), Salary = 22000, Status = "Active",
                EmergencyContact = "Meera Singh", EmergencyContactPhone = "9876543218",
                Qualifications = "12th Pass, Security Training", Experience = "10 years",
                Remarks = "Night shift supervisor"
            }
        );
    }
}