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
    public DbSet<FeePayment> FeePayments { get; set; }
    public DbSet<FeeStructure> FeeStructures { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<TransportExpense> TransportExpenses { get; set; }

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
            entity.Property(e => e.EmployeeId).IsRequired().HasMaxLength(20);
            entity.HasIndex(e => e.EmployeeId).IsUnique();
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
            entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15);
            entity.Property(e => e.Gender).IsRequired().HasMaxLength(10);
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Position).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Salary).HasColumnType("decimal(18,2)");
            entity.HasIndex(e => e.EmployeeId).IsUnique();
        });

        modelBuilder.Entity<FeePayment>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ReceiptNumber).IsRequired().HasMaxLength(20);
            entity.Property(e => e.AmountPaid).HasColumnType("decimal(18,2)");
            entity.Property(e => e.PreviousBalance).HasColumnType("decimal(18,2)");
            entity.Property(e => e.RemainingBalance).HasColumnType("decimal(18,2)");
            entity.Property(e => e.LateFee).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Discount).HasColumnType("decimal(18,2)");
            entity.Property(e => e.TransactionId).HasMaxLength(100);
            entity.Property(e => e.ChequeNumber).HasMaxLength(50);
            entity.Property(e => e.BankName).HasMaxLength(100);
            entity.Property(e => e.PaymentNotes).HasMaxLength(500);
            entity.Property(e => e.AcademicYear).IsRequired().HasMaxLength(10);
            entity.Property(e => e.GeneratedBy).IsRequired().HasMaxLength(100);
            entity.HasIndex(e => e.ReceiptNumber).IsUnique();

            entity.HasOne(e => e.Student)
                  .WithMany(s => s.FeePayments)
                  .HasForeignKey(e => e.StudentId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<FeeStructure>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
            entity.Property(e => e.AcademicYear).IsRequired().HasMaxLength(10);
            entity.Property(e => e.Description).HasMaxLength(200);

            entity.HasOne(e => e.Class)
                  .WithMany(c => c.FeeStructures)
                  .HasForeignKey(e => e.ClassId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(e => new { e.ClassId, e.FeeType, e.AcademicYear }).IsUnique();
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.VehicleNumber).IsRequired().HasMaxLength(20);
            entity.Property(e => e.DriverName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.DriverPhone).HasMaxLength(15);
            entity.Property(e => e.Route).HasMaxLength(200);
            entity.HasIndex(e => e.VehicleNumber).IsUnique();
        });

        modelBuilder.Entity<TransportExpense>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18,2)");
            entity.Property(e => e.DriverName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.InvoiceNumber).HasMaxLength(50);

            entity.HasOne(e => e.Vehicle)
                  .WithMany(v => v.TransportExpenses)
                  .HasForeignKey(e => e.VehicleId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>().HasData(
            new Teacher { Id = 1, FirstName = "John", LastName = "Smith", EmployeeId = "T001" },
            new Teacher { Id = 2, FirstName = "Sarah", LastName = "Johnson", EmployeeId = "T002" }
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
                PhoneNumber = "9876543213", DateOfBirth = new DateTime(1985, 3, 15), Gender = "Male",
                Address = "101 Transport Ave, City", Position = "Driver", Salary = 25000
            },
            new Staff
            {
                Id = 2, EmployeeId = "ST002", FirstName = "Kamala", LastName = "Devi",
                PhoneNumber = "9876543215", DateOfBirth = new DateTime(1978, 7, 22), Gender = "Female",
                Address = "202 Clean St, City", Position = "Peon", Salary = 18000
            },
            new Staff
            {
                Id = 3, EmployeeId = "ST003", FirstName = "Suresh", LastName = "Singh",
                PhoneNumber = "9876543217", DateOfBirth = new DateTime(1982, 11, 8), Gender = "Male",
                Address = "303 Office Lane, City", Position = "Clerk", Salary = 22000
            }
        );

        modelBuilder.Entity<FeeStructure>().HasData(
            new FeeStructure { Id = 1, ClassId = 1, FeeType = IEMS.Core.Enums.FeeType.TUITION, Amount = 60000, AcademicYear = "2024-25", Description = "Annual Tuition Fees" },
            new FeeStructure { Id = 2, ClassId = 1, FeeType = IEMS.Core.Enums.FeeType.ADMISSION, Amount = 5000, AcademicYear = "2024-25", Description = "One-time Admission Fees" },
            new FeeStructure { Id = 3, ClassId = 1, FeeType = IEMS.Core.Enums.FeeType.EXAM, Amount = 2000, AcademicYear = "2024-25", Description = "Examination Fees" },
            new FeeStructure { Id = 4, ClassId = 1, FeeType = IEMS.Core.Enums.FeeType.TRANSPORT, Amount = 12000, AcademicYear = "2024-25", Description = "Annual Transport Fees" },
            new FeeStructure { Id = 5, ClassId = 2, FeeType = IEMS.Core.Enums.FeeType.TUITION, Amount = 60000, AcademicYear = "2024-25", Description = "Annual Tuition Fees" },
            new FeeStructure { Id = 6, ClassId = 2, FeeType = IEMS.Core.Enums.FeeType.ADMISSION, Amount = 5000, AcademicYear = "2024-25", Description = "One-time Admission Fees" },
            new FeeStructure { Id = 7, ClassId = 2, FeeType = IEMS.Core.Enums.FeeType.EXAM, Amount = 2000, AcademicYear = "2024-25", Description = "Examination Fees" },
            new FeeStructure { Id = 8, ClassId = 2, FeeType = IEMS.Core.Enums.FeeType.TRANSPORT, Amount = 12000, AcademicYear = "2024-25", Description = "Annual Transport Fees" }
        );

        modelBuilder.Entity<Vehicle>().HasData(
            new Vehicle { Id = 1, VehicleNumber = "MH12AB1234", VehicleType = IEMS.Core.Enums.VehicleType.BUS, DriverName = "Rajesh Kumar", DriverPhone = "9876543213", Route = "Main Street - School", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Vehicle { Id = 2, VehicleNumber = "MH12CD5678", VehicleType = IEMS.Core.Enums.VehicleType.AUTO, DriverName = "Suresh Patil", DriverPhone = "9876543214", Route = "Park Road - School", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Vehicle { Id = 3, VehicleNumber = "MH12EF9012", VehicleType = IEMS.Core.Enums.VehicleType.TRAVELLER, DriverName = "Mohan Singh", DriverPhone = "9876543215", Route = "Highway - School", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        );

        modelBuilder.Entity<TransportExpense>().HasData(
            new TransportExpense { Id = 1, VehicleId = 1, Category = IEMS.Core.Enums.ExpenseCategory.FUEL, FuelType = IEMS.Core.Enums.FuelType.DIESEL, Amount = 5000, Quantity = 50, ExpenseDate = DateTime.Today.AddDays(-5), DriverName = "Rajesh Kumar", Description = "Fuel refill for bus", InvoiceNumber = "F001", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new TransportExpense { Id = 2, VehicleId = 1, Category = IEMS.Core.Enums.ExpenseCategory.MAINTENANCE, FuelType = null, Amount = 2500, Quantity = 1, ExpenseDate = DateTime.Today.AddDays(-10), DriverName = "Rajesh Kumar", Description = "Engine oil change", InvoiceNumber = "M001", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new TransportExpense { Id = 3, VehicleId = 2, Category = IEMS.Core.Enums.ExpenseCategory.FUEL, FuelType = IEMS.Core.Enums.FuelType.CNG, Amount = 1200, Quantity = 20, ExpenseDate = DateTime.Today.AddDays(-3), DriverName = "Suresh Patil", Description = "CNG refill for auto", InvoiceNumber = "F002", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        );
    }
}