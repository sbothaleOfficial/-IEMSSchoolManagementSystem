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
    public DbSet<ElectricityBill> ElectricityBills { get; set; }
    public DbSet<OtherExpense> OtherExpenses { get; set; }
    public DbSet<AcademicYear> AcademicYears { get; set; }

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
            entity.Property(e => e.CityVillage).HasMaxLength(100);
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
            entity.Property(e => e.MonthlySalary).HasColumnType("decimal(18,2)");
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
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Position).IsRequired().HasMaxLength(50);
            entity.Property(e => e.MonthlySalary).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.BankAccountNumber).HasMaxLength(20);
            entity.Property(e => e.AadharNumber).HasMaxLength(12);
            entity.Property(e => e.PANNumber).HasMaxLength(10);
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

        modelBuilder.Entity<ElectricityBill>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.BillNumber).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Units).HasColumnType("decimal(18,2)");
            entity.Property(e => e.UnitsRate).HasColumnType("decimal(18,2)");
            entity.Property(e => e.TransactionId).HasMaxLength(100);
            entity.Property(e => e.BankName).HasMaxLength(100);
            entity.Property(e => e.ChequeNumber).HasMaxLength(50);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.HasIndex(e => e.BillNumber).IsUnique();
            entity.HasIndex(e => new { e.BillMonth, e.BillYear }).IsUnique();
        });

        modelBuilder.Entity<OtherExpense>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ExpenseType).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
            entity.Property(e => e.TransactionId).HasMaxLength(100);
            entity.Property(e => e.BankName).HasMaxLength(100);
            entity.Property(e => e.ChequeNumber).HasMaxLength(50);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.InvoiceNumber).HasMaxLength(50);
            entity.Property(e => e.VendorName).HasMaxLength(100);
        });

        modelBuilder.Entity<AcademicYear>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Year).IsRequired().HasMaxLength(10);
            entity.Property(e => e.StartDate).IsRequired();
            entity.Property(e => e.EndDate).IsRequired();
            entity.Property(e => e.IsCurrent).IsRequired();
            entity.HasIndex(e => e.Year).IsUnique();
            entity.HasIndex(e => e.IsCurrent);
        });

        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>().HasData(
            new Teacher
            {
                Id = 1,
                EmployeeId = "T001",
                FirstName = "Priya",
                LastName = "Sharma",
                PhoneNumber = "9876543201",
                Address = "123 Teachers Colony, Mumbai, Maharashtra",
                JoiningDate = new DateTime(2020, 6, 15),
                MonthlySalary = 55000,
                Email = "priya.sharma@iemsschool.edu.in",
                BankAccountNumber = "SBI1234567890",
                AadharNumber = "1234-5678-9012",
                PANNumber = "ABCDE1234F",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Teacher
            {
                Id = 2,
                EmployeeId = "T002",
                FirstName = "Rajesh",
                LastName = "Patel",
                PhoneNumber = "9876543202",
                Address = "456 Gandhi Nagar, Pune, Maharashtra",
                JoiningDate = new DateTime(2019, 4, 10),
                MonthlySalary = 62000,
                Email = "rajesh.patel@iemsschool.edu.in",
                BankAccountNumber = "HDFC9876543210",
                AadharNumber = "2345-6789-0123",
                PANNumber = "FGHIJ5678K",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Teacher
            {
                Id = 3,
                EmployeeId = "T003",
                FirstName = "Anita",
                LastName = "Kulkarni",
                PhoneNumber = "9876543203",
                Address = "789 Shivaji Park, Nashik, Maharashtra",
                JoiningDate = new DateTime(2021, 8, 25),
                MonthlySalary = 48000,
                Email = "anita.kulkarni@iemsschool.edu.in",
                BankAccountNumber = "ICICI5432109876",
                AadharNumber = "3456-7890-1234",
                PANNumber = "LMNOP9012Q",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Teacher
            {
                Id = 4,
                EmployeeId = "T004",
                FirstName = "Suresh",
                LastName = "Gupta",
                PhoneNumber = "9876543204",
                Address = "101 Nehru Colony, Nagpur, Maharashtra",
                JoiningDate = new DateTime(2018, 3, 12),
                MonthlySalary = 68000,
                Email = "suresh.gupta@iemsschool.edu.in",
                BankAccountNumber = "AXIS6789012345",
                AadharNumber = "4567-8901-2345",
                PANNumber = "RSTUV3456W",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Teacher
            {
                Id = 5,
                EmployeeId = "T005",
                FirstName = "Kavita",
                LastName = "Singh",
                PhoneNumber = "9876543205",
                Address = "202 Laxmi Nagar, Aurangabad, Maharashtra",
                JoiningDate = new DateTime(2022, 1, 18),
                MonthlySalary = 45000,
                Email = null,
                BankAccountNumber = null,
                AadharNumber = "5678-9012-3456",
                PANNumber = null,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        );

        modelBuilder.Entity<Class>().HasData(
            new Class { Id = 1, Name = "Class 10", Section = "A", TeacherId = 1 },
            new Class { Id = 2, Name = "Class 10", Section = "B", TeacherId = 2 },
            new Class { Id = 3, Name = "Class 9", Section = "A", TeacherId = 3 },
            new Class { Id = 4, Name = "Class 9", Section = "B", TeacherId = 4 },
            new Class { Id = 5, Name = "Class 8", Section = "A", TeacherId = 5 },
            new Class { Id = 6, Name = "Class 1", Section = "", TeacherId = 1 },
            new Class { Id = 7, Name = "Class 2", Section = "", TeacherId = 2 }
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
                Address = "123 Main St, City", CityVillage = "Mumbai", ParentMobileNumber = "9876543210", ClassId = 1
            },
            new Student
            {
                Id = 2, SerialNo = 2, Standard = "10th", ClassDivision = "A",
                FirstName = "Bob", FatherName = "David Wilson", Surname = "Wilson",
                DateOfBirth = new DateTime(2008, 8, 22), Gender = "Male",
                MotherName = "Susan Wilson", StudentNumber = "S002",
                AdmissionDate = new DateTime(2023, 6, 1), CasteCategory = "OBC",
                Religion = "Hindu", IsBPL = true, IsSemiEnglish = false,
                Address = "456 Oak Ave, City", CityVillage = "Pune", ParentMobileNumber = "9876543211", ClassId = 1
            },
            new Student
            {
                Id = 3, SerialNo = 3, Standard = "10th", ClassDivision = "B",
                FirstName = "Charlie", FatherName = "Michael Davis", Surname = "Davis",
                DateOfBirth = new DateTime(2008, 12, 3), Gender = "Male",
                MotherName = "Jennifer Davis", StudentNumber = "S003",
                AdmissionDate = new DateTime(2023, 6, 1), CasteCategory = "SC",
                Religion = "Hindu", IsBPL = true, IsSemiEnglish = true,
                Address = "789 Pine Rd, City", CityVillage = "Nashik", ParentMobileNumber = "9876543212", ClassId = 2
            },
            // Class 1 Students for Bulk Promotion Testing
            new Student
            {
                Id = 4, SerialNo = 4, Standard = "1st", ClassDivision = "",
                FirstName = "Aarav", FatherName = "Raj Sharma", Surname = "Sharma",
                DateOfBirth = new DateTime(2017, 3, 15), Gender = "Male",
                MotherName = "Priya Sharma", StudentNumber = "S004",
                AdmissionDate = new DateTime(2024, 6, 1), CasteCategory = "General",
                Religion = "Hindu", IsBPL = false, IsSemiEnglish = true,
                Address = "101 Class Street, City", CityVillage = "Mumbai", ParentMobileNumber = "9876543220", ClassId = 6
            },
            new Student
            {
                Id = 5, SerialNo = 5, Standard = "1st", ClassDivision = "",
                FirstName = "Ananya", FatherName = "Suresh Patel", Surname = "Patel",
                DateOfBirth = new DateTime(2017, 6, 20), Gender = "Female",
                MotherName = "Meera Patel", StudentNumber = "S005",
                AdmissionDate = new DateTime(2024, 6, 1), CasteCategory = "OBC",
                Religion = "Hindu", IsBPL = false, IsSemiEnglish = true,
                Address = "102 Class Street, City", CityVillage = "Pune", ParentMobileNumber = "9876543221", ClassId = 6
            },
            new Student
            {
                Id = 6, SerialNo = 6, Standard = "1st", ClassDivision = "",
                FirstName = "Ishaan", FatherName = "Amit Kumar", Surname = "Kumar",
                DateOfBirth = new DateTime(2017, 1, 10), Gender = "Male",
                MotherName = "Sunita Kumar", StudentNumber = "S006",
                AdmissionDate = new DateTime(2024, 6, 1), CasteCategory = "General",
                Religion = "Hindu", IsBPL = false, IsSemiEnglish = false,
                Address = "103 Class Street, City", CityVillage = "Delhi", ParentMobileNumber = "9876543222", ClassId = 6
            },
            new Student
            {
                Id = 7, SerialNo = 7, Standard = "1st", ClassDivision = "",
                FirstName = "Diya", FatherName = "Ravi Singh", Surname = "Singh",
                DateOfBirth = new DateTime(2017, 9, 5), Gender = "Female",
                MotherName = "Kavita Singh", StudentNumber = "S007",
                AdmissionDate = new DateTime(2024, 6, 1), CasteCategory = "SC",
                Religion = "Hindu", IsBPL = true, IsSemiEnglish = true,
                Address = "104 Class Street, City", CityVillage = "Nagpur", ParentMobileNumber = "9876543223", ClassId = 6
            },
            new Student
            {
                Id = 8, SerialNo = 8, Standard = "1st", ClassDivision = "",
                FirstName = "Arjun", FatherName = "Manoj Gupta", Surname = "Gupta",
                DateOfBirth = new DateTime(2017, 4, 25), Gender = "Male",
                MotherName = "Asha Gupta", StudentNumber = "S008",
                AdmissionDate = new DateTime(2024, 6, 1), CasteCategory = "General",
                Religion = "Hindu", IsBPL = false, IsSemiEnglish = true,
                Address = "105 Class Street, City", CityVillage = "Indore", ParentMobileNumber = "9876543224", ClassId = 6
            },
            new Student
            {
                Id = 9, SerialNo = 9, Standard = "1st", ClassDivision = "",
                FirstName = "Sara", FatherName = "Ahmed Khan", Surname = "Khan",
                DateOfBirth = new DateTime(2017, 7, 12), Gender = "Female",
                MotherName = "Fatima Khan", StudentNumber = "S009",
                AdmissionDate = new DateTime(2024, 6, 1), CasteCategory = "General",
                Religion = "Muslim", IsBPL = false, IsSemiEnglish = true,
                Address = "106 Class Street, City", CityVillage = "Bhopal", ParentMobileNumber = "9876543225", ClassId = 6
            },
            new Student
            {
                Id = 10, SerialNo = 10, Standard = "1st", ClassDivision = "",
                FirstName = "Karan", FatherName = "Vikram Reddy", Surname = "Reddy",
                DateOfBirth = new DateTime(2017, 11, 8), Gender = "Male",
                MotherName = "Lakshmi Reddy", StudentNumber = "S010",
                AdmissionDate = new DateTime(2024, 6, 1), CasteCategory = "OBC",
                Religion = "Hindu", IsBPL = false, IsSemiEnglish = false,
                Address = "107 Class Street, City", CityVillage = "Hyderabad", ParentMobileNumber = "9876543226", ClassId = 6
            },
            new Student
            {
                Id = 11, SerialNo = 11, Standard = "1st", ClassDivision = "",
                FirstName = "Myra", FatherName = "Rajesh Jain", Surname = "Jain",
                DateOfBirth = new DateTime(2017, 2, 28), Gender = "Female",
                MotherName = "Pooja Jain", StudentNumber = "S011",
                AdmissionDate = new DateTime(2024, 6, 1), CasteCategory = "General",
                Religion = "Jain", IsBPL = false, IsSemiEnglish = true,
                Address = "108 Class Street, City", CityVillage = "Jaipur", ParentMobileNumber = "9876543227", ClassId = 6
            },
            new Student
            {
                Id = 12, SerialNo = 12, Standard = "1st", ClassDivision = "",
                FirstName = "Vihaan", FatherName = "Deepak Yadav", Surname = "Yadav",
                DateOfBirth = new DateTime(2017, 8, 14), Gender = "Male",
                MotherName = "Neha Yadav", StudentNumber = "S012",
                AdmissionDate = new DateTime(2024, 6, 1), CasteCategory = "OBC",
                Religion = "Hindu", IsBPL = true, IsSemiEnglish = false,
                Address = "109 Class Street, City", CityVillage = "Lucknow", ParentMobileNumber = "9876543228", ClassId = 6
            },
            new Student
            {
                Id = 13, SerialNo = 13, Standard = "1st", ClassDivision = "",
                FirstName = "Riya", FatherName = "Anil Verma", Surname = "Verma",
                DateOfBirth = new DateTime(2017, 5, 18), Gender = "Female",
                MotherName = "Seema Verma", StudentNumber = "S013",
                AdmissionDate = new DateTime(2024, 6, 1), CasteCategory = "General",
                Religion = "Hindu", IsBPL = false, IsSemiEnglish = true,
                Address = "110 Class Street, City", CityVillage = "Kanpur", ParentMobileNumber = "9876543229", ClassId = 6
            }
        );

        modelBuilder.Entity<Staff>().HasData(
            new Staff
            {
                Id = 1, EmployeeId = "ST001", FirstName = "Rajesh", LastName = "Kumar",
                PhoneNumber = "9876543213", JoiningDate = new DateTime(2020, 3, 15),
                Address = "101 Transport Ave, City", Position = "Driver", MonthlySalary = 25000,
                Email = "rajesh.kumar@school.edu", BankAccountNumber = "1234567890",
                AadharNumber = "123456789012", PANNumber = "ABCDE1234F"
            },
            new Staff
            {
                Id = 2, EmployeeId = "ST002", FirstName = "Kamala", LastName = "Devi",
                PhoneNumber = "9876543215", JoiningDate = new DateTime(2019, 7, 22),
                Address = "202 Clean St, City", Position = "Peon", MonthlySalary = 18000,
                Email = "kamala.devi@school.edu", BankAccountNumber = "2345678901",
                AadharNumber = "234567890123", PANNumber = "BCDEF2345G"
            },
            new Staff
            {
                Id = 3, EmployeeId = "ST003", FirstName = "Suresh", LastName = "Singh",
                PhoneNumber = "9876543217", JoiningDate = new DateTime(2021, 11, 8),
                Address = "303 Office Lane, City", Position = "Clerk", MonthlySalary = 22000,
                Email = "suresh.singh@school.edu", BankAccountNumber = "3456789012",
                AadharNumber = "345678901234", PANNumber = "CDEFG3456H"
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
            new FeeStructure { Id = 8, ClassId = 2, FeeType = IEMS.Core.Enums.FeeType.TRANSPORT, Amount = 12000, AcademicYear = "2024-25", Description = "Annual Transport Fees" },
            // Fee structures for Class 1 (Elementary level - lower fees)
            new FeeStructure { Id = 9, ClassId = 6, FeeType = IEMS.Core.Enums.FeeType.TUITION, Amount = 35000, AcademicYear = "2024-25", Description = "Annual Tuition Fees for Class 1" },
            new FeeStructure { Id = 10, ClassId = 6, FeeType = IEMS.Core.Enums.FeeType.ADMISSION, Amount = 3000, AcademicYear = "2024-25", Description = "One-time Admission Fees for Class 1" },
            new FeeStructure { Id = 11, ClassId = 6, FeeType = IEMS.Core.Enums.FeeType.EXAM, Amount = 1000, AcademicYear = "2024-25", Description = "Examination Fees for Class 1" },
            new FeeStructure { Id = 12, ClassId = 6, FeeType = IEMS.Core.Enums.FeeType.TRANSPORT, Amount = 8000, AcademicYear = "2024-25", Description = "Annual Transport Fees for Class 1" },
            // Fee structures for Class 2 (Elementary level - lower fees)
            new FeeStructure { Id = 13, ClassId = 7, FeeType = IEMS.Core.Enums.FeeType.TUITION, Amount = 38000, AcademicYear = "2024-25", Description = "Annual Tuition Fees for Class 2" },
            new FeeStructure { Id = 14, ClassId = 7, FeeType = IEMS.Core.Enums.FeeType.ADMISSION, Amount = 3000, AcademicYear = "2024-25", Description = "One-time Admission Fees for Class 2" },
            new FeeStructure { Id = 15, ClassId = 7, FeeType = IEMS.Core.Enums.FeeType.EXAM, Amount = 1200, AcademicYear = "2024-25", Description = "Examination Fees for Class 2" },
            new FeeStructure { Id = 16, ClassId = 7, FeeType = IEMS.Core.Enums.FeeType.TRANSPORT, Amount = 8000, AcademicYear = "2024-25", Description = "Annual Transport Fees for Class 2" }
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

        modelBuilder.Entity<ElectricityBill>().HasData(
            new ElectricityBill { Id = 1, BillNumber = "EB001", BillMonth = 8, BillYear = 2024, Amount = 8500, DueDate = new DateTime(2024, 9, 15), Units = 180, UnitsRate = 4.5m, IsPaid = true, PaidDate = new DateTime(2024, 9, 10), PaymentMethod = IEMS.Core.Enums.PaymentMethod.CASH, Notes = "August 2024 electricity bill", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new ElectricityBill { Id = 2, BillNumber = "EB002", BillMonth = 9, BillYear = 2024, Amount = 9200, DueDate = new DateTime(2024, 10, 15), Units = 195, UnitsRate = 4.6m, IsPaid = false, Notes = "September 2024 electricity bill", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new ElectricityBill { Id = 3, BillNumber = "EB003", BillMonth = 7, BillYear = 2024, Amount = 7800, DueDate = new DateTime(2024, 8, 15), Units = 165, UnitsRate = 4.4m, IsPaid = true, PaidDate = new DateTime(2024, 8, 12), PaymentMethod = IEMS.Core.Enums.PaymentMethod.ONLINE, TransactionId = "TXN789123", Notes = "July 2024 electricity bill", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        );

        modelBuilder.Entity<OtherExpense>().HasData(
            new OtherExpense { Id = 1, Category = IEMS.Core.Enums.OtherExpenseCategory.STATIONERY, ExpenseType = "Office Supplies", Description = "Books, pens, papers for office use", Amount = 2500, ExpenseDate = DateTime.Today.AddDays(-15), PaymentMethod = IEMS.Core.Enums.PaymentMethod.CASH, VendorName = "Shree Stationery Mart", InvoiceNumber = "INV001", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new OtherExpense { Id = 2, Category = IEMS.Core.Enums.OtherExpenseCategory.EVENT, ExpenseType = "Independence Day Celebration", Description = "Decorations, refreshments, and prizes for Independence Day", Amount = 15000, ExpenseDate = DateTime.Today.AddDays(-25), PaymentMethod = IEMS.Core.Enums.PaymentMethod.ONLINE, TransactionId = "TXN456789", VendorName = "Event Decorators", InvoiceNumber = "INV002", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new OtherExpense { Id = 3, Category = IEMS.Core.Enums.OtherExpenseCategory.MAINTENANCE, ExpenseType = "Classroom Repair", Description = "Repair of desks and chairs in Class 10 classroom", Amount = 5500, ExpenseDate = DateTime.Today.AddDays(-8), PaymentMethod = IEMS.Core.Enums.PaymentMethod.CHEQUE, ChequeNumber = "123456", BankName = "SBI Bank", VendorName = "Repair Services", InvoiceNumber = "INV003", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        );

        modelBuilder.Entity<AcademicYear>().HasData(
            new AcademicYear { Id = 1, Year = "2022-23", StartDate = new DateTime(2022, 6, 1), EndDate = new DateTime(2023, 5, 31), IsCurrent = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new AcademicYear { Id = 2, Year = "2023-24", StartDate = new DateTime(2023, 6, 1), EndDate = new DateTime(2024, 5, 31), IsCurrent = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new AcademicYear { Id = 3, Year = "2024-25", StartDate = new DateTime(2024, 6, 1), EndDate = new DateTime(2025, 5, 31), IsCurrent = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new AcademicYear { Id = 4, Year = "2025-26", StartDate = new DateTime(2025, 6, 1), EndDate = new DateTime(2026, 5, 31), IsCurrent = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        );
    }
}