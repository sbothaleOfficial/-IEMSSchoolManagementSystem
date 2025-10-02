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
    public DbSet<SystemSetting> SystemSettings { get; set; }
    public DbSet<User> Users { get; set; }

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

        modelBuilder.Entity<SystemSetting>(entity =>
        {
            entity.HasKey(e => e.Key);
            entity.Property(e => e.Key).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Value).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Category).IsRequired().HasMaxLength(50);
            entity.Property(e => e.DataType).IsRequired().HasMaxLength(20);
            entity.Property(e => e.DefaultValue).HasMaxLength(500);
            entity.Property(e => e.IsReadOnly).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
            entity.Property(e => e.ModifiedAt);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
            entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(500);
            entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Role).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.IsActive).IsRequired();
            entity.Property(e => e.CreatedDate).IsRequired();
            entity.Property(e => e.CreatedBy).IsRequired().HasMaxLength(50);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.HasIndex(e => e.Username).IsUnique();
        });

        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        // 10 Teachers
        modelBuilder.Entity<Teacher>().HasData(
            new Teacher { Id = 1, EmployeeId = "T001", FirstName = "Priya", LastName = "Sharma", PhoneNumber = "9876543201", Address = "123 Teachers Colony, Mumbai", JoiningDate = new DateTime(2020, 6, 15), MonthlySalary = 55000, Email = "priya.sharma@iemsschool.edu.in", BankAccountNumber = "SBI1234567890", AadharNumber = "1234-5678-9012", PANNumber = "ABCDE1234F", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Teacher { Id = 2, EmployeeId = "T002", FirstName = "Rajesh", LastName = "Patel", PhoneNumber = "9876543202", Address = "456 Gandhi Nagar, Pune", JoiningDate = new DateTime(2019, 4, 10), MonthlySalary = 62000, Email = "rajesh.patel@iemsschool.edu.in", BankAccountNumber = "HDFC9876543210", AadharNumber = "2345-6789-0123", PANNumber = "FGHIJ5678K", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Teacher { Id = 3, EmployeeId = "T003", FirstName = "Anita", LastName = "Kulkarni", PhoneNumber = "9876543203", Address = "789 Shivaji Park, Nashik", JoiningDate = new DateTime(2021, 8, 25), MonthlySalary = 48000, Email = "anita.kulkarni@iemsschool.edu.in", BankAccountNumber = "ICICI5432109876", AadharNumber = "3456-7890-1234", PANNumber = "LMNOP9012Q", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Teacher { Id = 4, EmployeeId = "T004", FirstName = "Suresh", LastName = "Gupta", PhoneNumber = "9876543204", Address = "101 Nehru Colony, Nagpur", JoiningDate = new DateTime(2018, 3, 12), MonthlySalary = 68000, Email = "suresh.gupta@iemsschool.edu.in", BankAccountNumber = "AXIS6789012345", AadharNumber = "4567-8901-2345", PANNumber = "RSTUV3456W", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Teacher { Id = 5, EmployeeId = "T005", FirstName = "Kavita", LastName = "Singh", PhoneNumber = "9876543205", Address = "202 Laxmi Nagar, Aurangabad", JoiningDate = new DateTime(2022, 1, 18), MonthlySalary = 45000, Email = "kavita.singh@iemsschool.edu.in", BankAccountNumber = "PNB3456789012", AadharNumber = "5678-9012-3456", PANNumber = "WXYZ7890A", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Teacher { Id = 6, EmployeeId = "T006", FirstName = "Amit", LastName = "Verma", PhoneNumber = "9876543206", Address = "303 Saraswati Vihar, Delhi", JoiningDate = new DateTime(2020, 9, 20), MonthlySalary = 52000, Email = "amit.verma@iemsschool.edu.in", BankAccountNumber = "BOI4567890123", AadharNumber = "6789-0123-4567", PANNumber = "BCDEF8901B", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Teacher { Id = 7, EmployeeId = "T007", FirstName = "Sunita", LastName = "Joshi", PhoneNumber = "9876543207", Address = "404 Indira Nagar, Jaipur", JoiningDate = new DateTime(2019, 11, 5), MonthlySalary = 58000, Email = "sunita.joshi@iemsschool.edu.in", BankAccountNumber = "UCO5678901234", AadharNumber = "7890-1234-5678", PANNumber = "CDEFG9012C", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Teacher { Id = 8, EmployeeId = "T008", FirstName = "Vikram", LastName = "Yadav", PhoneNumber = "9876543208", Address = "505 Vasant Kunj, Lucknow", JoiningDate = new DateTime(2021, 2, 14), MonthlySalary = 46000, Email = "vikram.yadav@iemsschool.edu.in", BankAccountNumber = "CBI6789012345", AadharNumber = "8901-2345-6789", PANNumber = "DEFGH0123D", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Teacher { Id = 9, EmployeeId = "T009", FirstName = "Meera", LastName = "Agarwal", PhoneNumber = "9876543209", Address = "606 MG Road, Bangalore", JoiningDate = new DateTime(2020, 7, 30), MonthlySalary = 54000, Email = "meera.agarwal@iemsschool.edu.in", BankAccountNumber = "IOB7890123456", AadharNumber = "9012-3456-7890", PANNumber = "EFGHI1234E", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Teacher { Id = 10, EmployeeId = "T010", FirstName = "Rohit", LastName = "Mishra", PhoneNumber = "9876543210", Address = "707 Park Street, Kolkata", JoiningDate = new DateTime(2018, 12, 10), MonthlySalary = 65000, Email = "rohit.mishra@iemsschool.edu.in", BankAccountNumber = "UNION8901234567", AadharNumber = "0123-4567-8901", PANNumber = "FGHIJ2345F", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        );

        // 10 Classes across different standards
        modelBuilder.Entity<Class>().HasData(
            new Class { Id = 1, Name = "Class 10", Section = "A", TeacherId = 1 },
            new Class { Id = 2, Name = "Class 10", Section = "B", TeacherId = 2 },
            new Class { Id = 3, Name = "Class 9", Section = "A", TeacherId = 3 },
            new Class { Id = 4, Name = "Class 9", Section = "B", TeacherId = 4 },
            new Class { Id = 5, Name = "Class 8", Section = "A", TeacherId = 5 },
            new Class { Id = 6, Name = "Class 8", Section = "B", TeacherId = 6 },
            new Class { Id = 7, Name = "Class 7", Section = "A", TeacherId = 7 },
            new Class { Id = 8, Name = "Class 6", Section = "A", TeacherId = 8 },
            new Class { Id = 9, Name = "Class 5", Section = "A", TeacherId = 9 },
            new Class { Id = 10, Name = "Class 1", Section = "A", TeacherId = 10 }
        );

        // 100+ Students distributed across 10 classes
        var students = new List<Student>();
        var firstNames = new[] { "Aarav", "Ananya", "Arjun", "Diya", "Ishaan", "Kavya", "Karan", "Myra", "Riya", "Vihaan", "Saanvi", "Reyansh", "Anvi", "Vivaan", "Aadya", "Aayan", "Pihu", "Krishna", "Advik", "Samaira", "Kiaan", "Avni", "Aryan", "Pari", "Sai", "Atharv", "Ira", "Ayaan", "Navya", "Rudra", "Anaya", "Om", "Tara", "Shaurya", "Kashvi", "Mihir", "Prisha", "Aadhya", "Dev", "Krisha", "Arnav", "Janvi", "Yug", "Shanaya", "Arjun", "Anika", "Vedant", "Reet", "Aarush", "Khushi" };
        var surnames = new[] { "Sharma", "Patel", "Singh", "Kumar", "Gupta", "Agarwal", "Verma", "Jain", "Shah", "Yadav", "Reddy", "Khan", "Mishra", "Chopra", "Bansal", "Agrawal", "Malhotra", "Kapoor", "Mittal", "Joshi", "Saxena", "Srivastava", "Pandey", "Tiwari", "Dubey" };
        var cities = new[] { "Mumbai", "Delhi", "Pune", "Bangalore", "Chennai", "Kolkata", "Hyderabad", "Ahmedabad", "Jaipur", "Lucknow", "Kanpur", "Nagpur", "Indore", "Bhopal", "Patna", "Vadodara", "Ludhiana", "Agra", "Nashik", "Faridabad", "Meerut", "Rajkot", "Kalyan", "Vasai", "Varanasi" };
        var religions = new[] { "Hindu", "Muslim", "Christian", "Sikh", "Jain", "Buddhist" };
        var casteCategories = new[] { "General", "OBC", "SC", "ST" };

        int studentId = 1;
        for (int classId = 1; classId <= 10; classId++)
        {
            string className = classId == 1 ? "10th" : classId == 2 ? "10th" : classId == 3 ? "9th" : classId == 4 ? "9th" : classId == 5 ? "8th" : classId == 6 ? "8th" : classId == 7 ? "7th" : classId == 8 ? "6th" : classId == 9 ? "5th" : "1st";
            string section = classId == 1 ? "A" : classId == 2 ? "B" : classId == 3 ? "A" : classId == 4 ? "B" : classId == 5 ? "A" : classId == 6 ? "B" : classId == 7 ? "A" : classId == 8 ? "A" : classId == 9 ? "A" : "A";

            int studentsPerClass = classId <= 2 ? 15 : classId <= 4 ? 12 : 10; // More students in higher classes

            for (int i = 0; i < studentsPerClass; i++)
            {
                var firstName = firstNames[(studentId - 1) % firstNames.Length];
                var surname = surnames[(studentId - 1) % surnames.Length];
                var city = cities[(studentId - 1) % cities.Length];
                var religion = religions[(studentId - 1) % religions.Length];
                var caste = casteCategories[(studentId - 1) % casteCategories.Length];

                students.Add(new Student
                {
                    Id = studentId,
                    SerialNo = studentId,
                    Standard = className,
                    ClassDivision = section,
                    FirstName = firstName,
                    FatherName = $"{surnames[(studentId + 10) % surnames.Length]} {surnames[(studentId + 5) % surnames.Length]}",
                    Surname = surname,
                    DateOfBirth = className == "10th" ? new DateTime(2008, (studentId % 12) + 1, (studentId % 28) + 1) :
                                  className == "9th" ? new DateTime(2009, (studentId % 12) + 1, (studentId % 28) + 1) :
                                  className == "8th" ? new DateTime(2010, (studentId % 12) + 1, (studentId % 28) + 1) :
                                  className == "7th" ? new DateTime(2011, (studentId % 12) + 1, (studentId % 28) + 1) :
                                  className == "6th" ? new DateTime(2012, (studentId % 12) + 1, (studentId % 28) + 1) :
                                  className == "5th" ? new DateTime(2013, (studentId % 12) + 1, (studentId % 28) + 1) :
                                  new DateTime(2017, (studentId % 12) + 1, (studentId % 28) + 1),
                    Gender = studentId % 2 == 0 ? "Female" : "Male",
                    MotherName = $"{firstNames[(studentId + 15) % firstNames.Length]} {surname}",
                    StudentNumber = $"S{studentId:D3}",
                    AdmissionDate = new DateTime(2024, 6, 1),
                    CasteCategory = caste,
                    Religion = religion,
                    IsBPL = studentId % 5 == 0,
                    IsSemiEnglish = studentId % 3 != 0,
                    Address = $"{studentId * 10 + 1} Test Street, {city}",
                    CityVillage = city,
                    ParentMobileNumber = $"98765{(43210 + studentId):D5}",
                    ClassId = classId
                });

                studentId++;
                if (studentId > 120) break; // Ensure we don't exceed reasonable limits
            }
            if (studentId > 120) break;
        }

        modelBuilder.Entity<Student>().HasData(students.ToArray());

        // 10 Staff members
        modelBuilder.Entity<Staff>().HasData(
            new Staff { Id = 1, EmployeeId = "ST001", FirstName = "Rajesh", LastName = "Kumar", PhoneNumber = "9876543213", JoiningDate = new DateTime(2020, 3, 15), Address = "101 Transport Ave, Mumbai", Position = "Driver", MonthlySalary = 25000, Email = "rajesh.kumar@school.edu", BankAccountNumber = "1234567890", AadharNumber = "123456789012", PANNumber = "ABCDE1234F" },
            new Staff { Id = 2, EmployeeId = "ST002", FirstName = "Kamala", LastName = "Devi", PhoneNumber = "9876543215", JoiningDate = new DateTime(2019, 7, 22), Address = "202 Clean St, Delhi", Position = "Peon", MonthlySalary = 18000, Email = "kamala.devi@school.edu", BankAccountNumber = "2345678901", AadharNumber = "234567890123", PANNumber = "BCDEF2345G" },
            new Staff { Id = 3, EmployeeId = "ST003", FirstName = "Suresh", LastName = "Singh", PhoneNumber = "9876543217", JoiningDate = new DateTime(2021, 11, 8), Address = "303 Office Lane, Pune", Position = "Clerk", MonthlySalary = 22000, Email = "suresh.singh@school.edu", BankAccountNumber = "3456789012", AadharNumber = "345678901234", PANNumber = "CDEFG3456H" },
            new Staff { Id = 4, EmployeeId = "ST004", FirstName = "Priya", LastName = "Mehta", PhoneNumber = "9876543218", JoiningDate = new DateTime(2020, 5, 12), Address = "404 Support St, Bangalore", Position = "Lab Assistant", MonthlySalary = 20000, Email = "priya.mehta@school.edu", BankAccountNumber = "4567890123", AadharNumber = "456789012345", PANNumber = "DEFGH4567I" },
            new Staff { Id = 5, EmployeeId = "ST005", FirstName = "Mohan", LastName = "Rao", PhoneNumber = "9876543219", JoiningDate = new DateTime(2018, 9, 3), Address = "505 Maintenance Rd, Chennai", Position = "Electrician", MonthlySalary = 28000, Email = "mohan.rao@school.edu", BankAccountNumber = "5678901234", AadharNumber = "567890123456", PANNumber = "EFGHI5678J" },
            new Staff { Id = 6, EmployeeId = "ST006", FirstName = "Sunita", LastName = "Nair", PhoneNumber = "9876543220", JoiningDate = new DateTime(2021, 2, 18), Address = "606 Admin Block, Kolkata", Position = "Office Assistant", MonthlySalary = 19000, Email = "sunita.nair@school.edu", BankAccountNumber = "6789012345", AadharNumber = "678901234567", PANNumber = "FGHIJ6789K" },
            new Staff { Id = 7, EmployeeId = "ST007", FirstName = "Vinod", LastName = "Patil", PhoneNumber = "9876543221", JoiningDate = new DateTime(2019, 12, 25), Address = "707 Security Gate, Hyderabad", Position = "Security Guard", MonthlySalary = 16000, Email = "vinod.patil@school.edu", BankAccountNumber = "7890123456", AadharNumber = "789012345678", PANNumber = "GHIJK7890L" },
            new Staff { Id = 8, EmployeeId = "ST008", FirstName = "Lata", LastName = "Desai", PhoneNumber = "9876543222", JoiningDate = new DateTime(2020, 8, 14), Address = "808 Library Block, Ahmedabad", Position = "Librarian", MonthlySalary = 24000, Email = "lata.desai@school.edu", BankAccountNumber = "8901234567", AadharNumber = "890123456789", PANNumber = "HIJKL8901M" },
            new Staff { Id = 9, EmployeeId = "ST009", FirstName = "Ravi", LastName = "Iyer", PhoneNumber = "9876543223", JoiningDate = new DateTime(2017, 4, 6), Address = "909 Transport Yard, Jaipur", Position = "Mechanic", MonthlySalary = 26000, Email = "ravi.iyer@school.edu", BankAccountNumber = "9012345678", AadharNumber = "901234567890", PANNumber = "IJKLM9012N" },
            new Staff { Id = 10, EmployeeId = "ST010", FirstName = "Geeta", LastName = "Sharma", PhoneNumber = "9876543224", JoiningDate = new DateTime(2022, 1, 20), Address = "101 Canteen Block, Lucknow", Position = "Cook", MonthlySalary = 17000, Email = "geeta.sharma@school.edu", BankAccountNumber = "0123456789", AadharNumber = "012345678901", PANNumber = "JKLMN0123O" }
        );

        // 10 FeeStructure records across different classes and fee types
        modelBuilder.Entity<FeeStructure>().HasData(
            new FeeStructure { Id = 1, ClassId = 1, FeeType = IEMS.Core.Enums.FeeType.TUITION, Amount = 60000, AcademicYear = "2024-25", Description = "Annual Tuition Fees for Class 10-A" },
            new FeeStructure { Id = 2, ClassId = 2, FeeType = IEMS.Core.Enums.FeeType.TUITION, Amount = 60000, AcademicYear = "2024-25", Description = "Annual Tuition Fees for Class 10-B" },
            new FeeStructure { Id = 3, ClassId = 3, FeeType = IEMS.Core.Enums.FeeType.TUITION, Amount = 55000, AcademicYear = "2024-25", Description = "Annual Tuition Fees for Class 9-A" },
            new FeeStructure { Id = 4, ClassId = 4, FeeType = IEMS.Core.Enums.FeeType.TUITION, Amount = 55000, AcademicYear = "2024-25", Description = "Annual Tuition Fees for Class 9-B" },
            new FeeStructure { Id = 5, ClassId = 5, FeeType = IEMS.Core.Enums.FeeType.TUITION, Amount = 50000, AcademicYear = "2024-25", Description = "Annual Tuition Fees for Class 8-A" },
            new FeeStructure { Id = 6, ClassId = 6, FeeType = IEMS.Core.Enums.FeeType.TUITION, Amount = 50000, AcademicYear = "2024-25", Description = "Annual Tuition Fees for Class 8-B" },
            new FeeStructure { Id = 7, ClassId = 7, FeeType = IEMS.Core.Enums.FeeType.TUITION, Amount = 45000, AcademicYear = "2024-25", Description = "Annual Tuition Fees for Class 7-A" },
            new FeeStructure { Id = 8, ClassId = 8, FeeType = IEMS.Core.Enums.FeeType.TUITION, Amount = 40000, AcademicYear = "2024-25", Description = "Annual Tuition Fees for Class 6-A" },
            new FeeStructure { Id = 9, ClassId = 9, FeeType = IEMS.Core.Enums.FeeType.TUITION, Amount = 38000, AcademicYear = "2024-25", Description = "Annual Tuition Fees for Class 5-A" },
            new FeeStructure { Id = 10, ClassId = 10, FeeType = IEMS.Core.Enums.FeeType.TUITION, Amount = 35000, AcademicYear = "2024-25", Description = "Annual Tuition Fees for Class 1-A" }
        );

        // 10 Vehicles for transport
        modelBuilder.Entity<Vehicle>().HasData(
            new Vehicle { Id = 1, VehicleNumber = "MH12AB1234", VehicleType = IEMS.Core.Enums.VehicleType.BUS, DriverName = "Rajesh Kumar", DriverPhone = "9876543213", Route = "Main Street - School", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Vehicle { Id = 2, VehicleNumber = "MH12CD5678", VehicleType = IEMS.Core.Enums.VehicleType.AUTO, DriverName = "Suresh Patil", DriverPhone = "9876543214", Route = "Park Road - School", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Vehicle { Id = 3, VehicleNumber = "MH12EF9012", VehicleType = IEMS.Core.Enums.VehicleType.TRAVELLER, DriverName = "Mohan Singh", DriverPhone = "9876543215", Route = "Highway - School", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Vehicle { Id = 4, VehicleNumber = "DL8CAB9876", VehicleType = IEMS.Core.Enums.VehicleType.BUS, DriverName = "Ashok Yadav", DriverPhone = "9876543216", Route = "South Delhi - School", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Vehicle { Id = 5, VehicleNumber = "UP16GH3456", VehicleType = IEMS.Core.Enums.VehicleType.AUTO, DriverName = "Ramesh Gupta", DriverPhone = "9876543217", Route = "Lucknow City - School", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Vehicle { Id = 6, VehicleNumber = "KA05JK7890", VehicleType = IEMS.Core.Enums.VehicleType.TRAVELLER, DriverName = "Prakash Nair", DriverPhone = "9876543218", Route = "Bangalore North - School", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Vehicle { Id = 7, VehicleNumber = "TN07LM2345", VehicleType = IEMS.Core.Enums.VehicleType.BUS, DriverName = "Murugan Pillai", DriverPhone = "9876543219", Route = "Chennai Central - School", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Vehicle { Id = 8, VehicleNumber = "WB10NO6789", VehicleType = IEMS.Core.Enums.VehicleType.AUTO, DriverName = "Biswajit Das", DriverPhone = "9876543220", Route = "Kolkata East - School", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Vehicle { Id = 9, VehicleNumber = "RJ14PQ0123", VehicleType = IEMS.Core.Enums.VehicleType.TRAVELLER, DriverName = "Dinesh Sharma", DriverPhone = "9876543221", Route = "Jaipur Pink City - School", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Vehicle { Id = 10, VehicleNumber = "GJ01RS4567", VehicleType = IEMS.Core.Enums.VehicleType.BUS, DriverName = "Kiran Patel", DriverPhone = "9876543222", Route = "Ahmedabad West - School", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        );

        // 10 TransportExpense records across different vehicles
        modelBuilder.Entity<TransportExpense>().HasData(
            new TransportExpense { Id = 1, VehicleId = 1, Category = IEMS.Core.Enums.ExpenseCategory.FUEL, FuelType = IEMS.Core.Enums.FuelType.DIESEL, Amount = 5000, Quantity = 50, ExpenseDate = DateTime.Today.AddDays(-5), DriverName = "Rajesh Kumar", Description = "Fuel refill for bus", InvoiceNumber = "F001", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new TransportExpense { Id = 2, VehicleId = 2, Category = IEMS.Core.Enums.ExpenseCategory.FUEL, FuelType = IEMS.Core.Enums.FuelType.CNG, Amount = 1200, Quantity = 20, ExpenseDate = DateTime.Today.AddDays(-3), DriverName = "Suresh Patil", Description = "CNG refill for auto", InvoiceNumber = "F002", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new TransportExpense { Id = 3, VehicleId = 3, Category = IEMS.Core.Enums.ExpenseCategory.MAINTENANCE, FuelType = null, Amount = 3500, Quantity = 1, ExpenseDate = DateTime.Today.AddDays(-7), DriverName = "Mohan Singh", Description = "Brake pad replacement", InvoiceNumber = "M001", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new TransportExpense { Id = 4, VehicleId = 4, Category = IEMS.Core.Enums.ExpenseCategory.FUEL, FuelType = IEMS.Core.Enums.FuelType.DIESEL, Amount = 6200, Quantity = 65, ExpenseDate = DateTime.Today.AddDays(-2), DriverName = "Ashok Yadav", Description = "Weekly diesel refill", InvoiceNumber = "F003", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new TransportExpense { Id = 5, VehicleId = 5, Category = IEMS.Core.Enums.ExpenseCategory.FUEL, FuelType = IEMS.Core.Enums.FuelType.CNG, Amount = 980, Quantity = 15, ExpenseDate = DateTime.Today.AddDays(-4), DriverName = "Ramesh Gupta", Description = "CNG refill", InvoiceNumber = "F004", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new TransportExpense { Id = 6, VehicleId = 6, Category = IEMS.Core.Enums.ExpenseCategory.MAINTENANCE, FuelType = null, Amount = 2800, Quantity = 1, ExpenseDate = DateTime.Today.AddDays(-12), DriverName = "Prakash Nair", Description = "Tire replacement", InvoiceNumber = "M002", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new TransportExpense { Id = 7, VehicleId = 7, Category = IEMS.Core.Enums.ExpenseCategory.FUEL, FuelType = IEMS.Core.Enums.FuelType.DIESEL, Amount = 4800, Quantity = 45, ExpenseDate = DateTime.Today.AddDays(-1), DriverName = "Murugan Pillai", Description = "Daily diesel supply", InvoiceNumber = "F005", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new TransportExpense { Id = 8, VehicleId = 8, Category = IEMS.Core.Enums.ExpenseCategory.FUEL, FuelType = IEMS.Core.Enums.FuelType.CNG, Amount = 1400, Quantity = 22, ExpenseDate = DateTime.Today.AddDays(-6), DriverName = "Biswajit Das", Description = "Auto CNG refill", InvoiceNumber = "F006", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new TransportExpense { Id = 9, VehicleId = 9, Category = IEMS.Core.Enums.ExpenseCategory.MAINTENANCE, FuelType = null, Amount = 4200, Quantity = 1, ExpenseDate = DateTime.Today.AddDays(-15), DriverName = "Dinesh Sharma", Description = "Engine service and oil change", InvoiceNumber = "M003", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new TransportExpense { Id = 10, VehicleId = 10, Category = IEMS.Core.Enums.ExpenseCategory.FUEL, FuelType = IEMS.Core.Enums.FuelType.DIESEL, Amount = 5500, Quantity = 55, ExpenseDate = DateTime.Today.AddDays(-8), DriverName = "Kiran Patel", Description = "Bus fuel refill", InvoiceNumber = "F007", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        );

        // 10 ElectricityBill records for different months
        modelBuilder.Entity<ElectricityBill>().HasData(
            new ElectricityBill { Id = 1, BillNumber = "EB001", BillMonth = 1, BillYear = 2024, Amount = 7200, DueDate = new DateTime(2024, 2, 15), Units = 150, UnitsRate = 4.8m, IsPaid = true, PaidDate = new DateTime(2024, 2, 10), PaymentMethod = IEMS.Core.Enums.PaymentMethod.CASH, Notes = "January 2024 electricity bill", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new ElectricityBill { Id = 2, BillNumber = "EB002", BillMonth = 2, BillYear = 2024, Amount = 6800, DueDate = new DateTime(2024, 3, 15), Units = 140, UnitsRate = 4.8m, IsPaid = true, PaidDate = new DateTime(2024, 3, 12), PaymentMethod = IEMS.Core.Enums.PaymentMethod.ONLINE, TransactionId = "TXN123456", Notes = "February 2024 electricity bill", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new ElectricityBill { Id = 3, BillNumber = "EB003", BillMonth = 3, BillYear = 2024, Amount = 7500, DueDate = new DateTime(2024, 4, 15), Units = 155, UnitsRate = 4.8m, IsPaid = true, PaidDate = new DateTime(2024, 4, 8), PaymentMethod = IEMS.Core.Enums.PaymentMethod.CHEQUE, ChequeNumber = "CH001", BankName = "SBI Bank", Notes = "March 2024 electricity bill", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new ElectricityBill { Id = 4, BillNumber = "EB004", BillMonth = 4, BillYear = 2024, Amount = 8200, DueDate = new DateTime(2024, 5, 15), Units = 170, UnitsRate = 4.8m, IsPaid = true, PaidDate = new DateTime(2024, 5, 14), PaymentMethod = IEMS.Core.Enums.PaymentMethod.CASH, Notes = "April 2024 electricity bill", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new ElectricityBill { Id = 5, BillNumber = "EB005", BillMonth = 5, BillYear = 2024, Amount = 9500, DueDate = new DateTime(2024, 6, 15), Units = 200, UnitsRate = 4.75m, IsPaid = true, PaidDate = new DateTime(2024, 6, 10), PaymentMethod = IEMS.Core.Enums.PaymentMethod.ONLINE, TransactionId = "TXN234567", Notes = "May 2024 electricity bill - High consumption due to summer", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new ElectricityBill { Id = 6, BillNumber = "EB006", BillMonth = 6, BillYear = 2024, Amount = 10200, DueDate = new DateTime(2024, 7, 15), Units = 220, UnitsRate = 4.6m, IsPaid = true, PaidDate = new DateTime(2024, 7, 12), PaymentMethod = IEMS.Core.Enums.PaymentMethod.CASH, Notes = "June 2024 electricity bill - Peak summer consumption", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new ElectricityBill { Id = 7, BillNumber = "EB007", BillMonth = 7, BillYear = 2024, Amount = 7800, DueDate = new DateTime(2024, 8, 15), Units = 165, UnitsRate = 4.7m, IsPaid = true, PaidDate = new DateTime(2024, 8, 12), PaymentMethod = IEMS.Core.Enums.PaymentMethod.ONLINE, TransactionId = "TXN789123", Notes = "July 2024 electricity bill", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new ElectricityBill { Id = 8, BillNumber = "EB008", BillMonth = 8, BillYear = 2024, Amount = 8500, DueDate = new DateTime(2024, 9, 15), Units = 180, UnitsRate = 4.7m, IsPaid = true, PaidDate = new DateTime(2024, 9, 10), PaymentMethod = IEMS.Core.Enums.PaymentMethod.CASH, Notes = "August 2024 electricity bill", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new ElectricityBill { Id = 9, BillNumber = "EB009", BillMonth = 9, BillYear = 2024, Amount = 9200, DueDate = new DateTime(2024, 10, 15), Units = 195, UnitsRate = 4.7m, IsPaid = false, Notes = "September 2024 electricity bill - Pending payment", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new ElectricityBill { Id = 10, BillNumber = "EB010", BillMonth = 10, BillYear = 2024, Amount = 8800, DueDate = new DateTime(2024, 11, 15), Units = 185, UnitsRate = 4.75m, IsPaid = false, Notes = "October 2024 electricity bill - Current month", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        );

        // 10 OtherExpense records across different categories
        modelBuilder.Entity<OtherExpense>().HasData(
            new OtherExpense { Id = 1, Category = IEMS.Core.Enums.OtherExpenseCategory.STATIONERY, ExpenseType = "Office Supplies", Description = "Books, pens, papers for office use", Amount = 2500, ExpenseDate = DateTime.Today.AddDays(-15), PaymentMethod = IEMS.Core.Enums.PaymentMethod.CASH, VendorName = "Shree Stationery Mart", InvoiceNumber = "INV001", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new OtherExpense { Id = 2, Category = IEMS.Core.Enums.OtherExpenseCategory.EVENT, ExpenseType = "Independence Day Celebration", Description = "Decorations, refreshments, and prizes for Independence Day", Amount = 15000, ExpenseDate = DateTime.Today.AddDays(-25), PaymentMethod = IEMS.Core.Enums.PaymentMethod.ONLINE, TransactionId = "TXN456789", VendorName = "Event Decorators", InvoiceNumber = "INV002", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new OtherExpense { Id = 3, Category = IEMS.Core.Enums.OtherExpenseCategory.MAINTENANCE, ExpenseType = "Classroom Repair", Description = "Repair of desks and chairs in Class 10 classroom", Amount = 5500, ExpenseDate = DateTime.Today.AddDays(-8), PaymentMethod = IEMS.Core.Enums.PaymentMethod.CHEQUE, ChequeNumber = "123456", BankName = "SBI Bank", VendorName = "Repair Services", InvoiceNumber = "INV003", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new OtherExpense { Id = 4, Category = IEMS.Core.Enums.OtherExpenseCategory.STATIONERY, ExpenseType = "Teaching Materials", Description = "Charts, models, and laboratory equipment", Amount = 8200, ExpenseDate = DateTime.Today.AddDays(-20), PaymentMethod = IEMS.Core.Enums.PaymentMethod.CASH, VendorName = "Educational Supplies Co", InvoiceNumber = "INV004", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new OtherExpense { Id = 5, Category = IEMS.Core.Enums.OtherExpenseCategory.EVENT, ExpenseType = "Annual Sports Day", Description = "Sports equipment, prizes, and refreshments for annual sports day", Amount = 22000, ExpenseDate = DateTime.Today.AddDays(-45), PaymentMethod = IEMS.Core.Enums.PaymentMethod.ONLINE, TransactionId = "TXN567890", VendorName = "Sports Events Org", InvoiceNumber = "INV005", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new OtherExpense { Id = 6, Category = IEMS.Core.Enums.OtherExpenseCategory.MAINTENANCE, ExpenseType = "Plumbing Work", Description = "Repair of washroom facilities and water pipeline", Amount = 12000, ExpenseDate = DateTime.Today.AddDays(-12), PaymentMethod = IEMS.Core.Enums.PaymentMethod.CHEQUE, ChequeNumber = "234567", BankName = "HDFC Bank", VendorName = "City Plumbers", InvoiceNumber = "INV006", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new OtherExpense { Id = 7, Category = IEMS.Core.Enums.OtherExpenseCategory.STATIONERY, ExpenseType = "Computer Accessories", Description = "Keyboards, mouse, cables for computer lab", Amount = 4500, ExpenseDate = DateTime.Today.AddDays(-30), PaymentMethod = IEMS.Core.Enums.PaymentMethod.CASH, VendorName = "Tech Solutions", InvoiceNumber = "INV007", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new OtherExpense { Id = 8, Category = IEMS.Core.Enums.OtherExpenseCategory.EVENT, ExpenseType = "Teachers Day Celebration", Description = "Flowers, gifts, and refreshments for teachers day", Amount = 3500, ExpenseDate = DateTime.Today.AddDays(-35), PaymentMethod = IEMS.Core.Enums.PaymentMethod.CASH, VendorName = "Local Florist", InvoiceNumber = "INV008", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new OtherExpense { Id = 9, Category = IEMS.Core.Enums.OtherExpenseCategory.MAINTENANCE, ExpenseType = "Garden Maintenance", Description = "Plant care, fertilizers, and gardening tools", Amount = 6800, ExpenseDate = DateTime.Today.AddDays(-18), PaymentMethod = IEMS.Core.Enums.PaymentMethod.ONLINE, TransactionId = "TXN678901", VendorName = "Green Gardens", InvoiceNumber = "INV009", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new OtherExpense { Id = 10, Category = IEMS.Core.Enums.OtherExpenseCategory.STATIONERY, ExpenseType = "Library Books", Description = "New textbooks and reference books for library", Amount = 18500, ExpenseDate = DateTime.Today.AddDays(-40), PaymentMethod = IEMS.Core.Enums.PaymentMethod.CHEQUE, ChequeNumber = "345678", BankName = "SBI Bank", VendorName = "Academic Publishers", InvoiceNumber = "INV010", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        );

        // 10 FeePayment records across different students
        modelBuilder.Entity<FeePayment>().HasData(
            new FeePayment { Id = 1, StudentId = 1, ReceiptNumber = "REC001", FeeType = IEMS.Core.Enums.FeeType.TUITION, AmountPaid = 15000, PaymentDate = DateTime.Today.AddDays(-20), PreviousBalance = 60000, RemainingBalance = 45000, LateFee = 0, Discount = 0, PaymentMethod = IEMS.Core.Enums.PaymentMethod.CASH, AcademicYear = "2024-25", GeneratedBy = "Admin", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new FeePayment { Id = 2, StudentId = 2, ReceiptNumber = "REC002", FeeType = IEMS.Core.Enums.FeeType.TUITION, AmountPaid = 20000, PaymentDate = DateTime.Today.AddDays(-18), PreviousBalance = 60000, RemainingBalance = 40000, LateFee = 0, Discount = 0, PaymentMethod = IEMS.Core.Enums.PaymentMethod.ONLINE, TransactionId = "TXN112233", AcademicYear = "2024-25", GeneratedBy = "Admin", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new FeePayment { Id = 3, StudentId = 3, ReceiptNumber = "REC003", FeeType = IEMS.Core.Enums.FeeType.TUITION, AmountPaid = 18000, PaymentDate = DateTime.Today.AddDays(-15), PreviousBalance = 60000, RemainingBalance = 42500, LateFee = 500, Discount = 0, PaymentMethod = IEMS.Core.Enums.PaymentMethod.CHEQUE, ChequeNumber = "CH445566", BankName = "HDFC Bank", AcademicYear = "2024-25", GeneratedBy = "Admin", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new FeePayment { Id = 4, StudentId = 10, ReceiptNumber = "REC004", FeeType = IEMS.Core.Enums.FeeType.TUITION, AmountPaid = 10000, PaymentDate = DateTime.Today.AddDays(-25), PreviousBalance = 35000, RemainingBalance = 24000, LateFee = 0, Discount = 1000, PaymentMethod = IEMS.Core.Enums.PaymentMethod.CASH, AcademicYear = "2024-25", GeneratedBy = "Admin", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new FeePayment { Id = 5, StudentId = 15, ReceiptNumber = "REC005", FeeType = IEMS.Core.Enums.FeeType.TUITION, AmountPaid = 12000, PaymentDate = DateTime.Today.AddDays(-12), PreviousBalance = 55000, RemainingBalance = 43000, LateFee = 0, Discount = 0, PaymentMethod = IEMS.Core.Enums.PaymentMethod.ONLINE, TransactionId = "TXN223344", AcademicYear = "2024-25", GeneratedBy = "Admin", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new FeePayment { Id = 6, StudentId = 20, ReceiptNumber = "REC006", FeeType = IEMS.Core.Enums.FeeType.ADMISSION, AmountPaid = 5000, PaymentDate = DateTime.Today.AddDays(-30), PreviousBalance = 5000, RemainingBalance = 0, LateFee = 0, Discount = 0, PaymentMethod = IEMS.Core.Enums.PaymentMethod.CASH, AcademicYear = "2024-25", GeneratedBy = "Admin", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new FeePayment { Id = 7, StudentId = 25, ReceiptNumber = "REC007", FeeType = IEMS.Core.Enums.FeeType.TRANSPORT, AmountPaid = 4000, PaymentDate = DateTime.Today.AddDays(-22), PreviousBalance = 12000, RemainingBalance = 8000, LateFee = 0, Discount = 0, PaymentMethod = IEMS.Core.Enums.PaymentMethod.ONLINE, TransactionId = "TXN334455", AcademicYear = "2024-25", GeneratedBy = "Admin", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new FeePayment { Id = 8, StudentId = 30, ReceiptNumber = "REC008", FeeType = IEMS.Core.Enums.FeeType.EXAM, AmountPaid = 2000, PaymentDate = DateTime.Today.AddDays(-5), PreviousBalance = 2000, RemainingBalance = 0, LateFee = 0, Discount = 0, PaymentMethod = IEMS.Core.Enums.PaymentMethod.CASH, AcademicYear = "2024-25", GeneratedBy = "Admin", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new FeePayment { Id = 9, StudentId = 35, ReceiptNumber = "REC009", FeeType = IEMS.Core.Enums.FeeType.TUITION, AmountPaid = 8000, PaymentDate = DateTime.Today.AddDays(-8), PreviousBalance = 38000, RemainingBalance = 29700, LateFee = 200, Discount = 500, PaymentMethod = IEMS.Core.Enums.PaymentMethod.CHEQUE, ChequeNumber = "CH556677", BankName = "SBI Bank", AcademicYear = "2024-25", GeneratedBy = "Admin", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new FeePayment { Id = 10, StudentId = 40, ReceiptNumber = "REC010", FeeType = IEMS.Core.Enums.FeeType.TUITION, AmountPaid = 16000, PaymentDate = DateTime.Today.AddDays(-3), PreviousBalance = 50000, RemainingBalance = 34000, LateFee = 0, Discount = 0, PaymentMethod = IEMS.Core.Enums.PaymentMethod.ONLINE, TransactionId = "TXN445566", AcademicYear = "2024-25", GeneratedBy = "Admin", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        );

        modelBuilder.Entity<AcademicYear>().HasData(
            new AcademicYear { Id = 1, Year = "2022-23", StartDate = new DateTime(2022, 6, 1), EndDate = new DateTime(2023, 5, 31), IsCurrent = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new AcademicYear { Id = 2, Year = "2023-24", StartDate = new DateTime(2023, 6, 1), EndDate = new DateTime(2024, 5, 31), IsCurrent = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new AcademicYear { Id = 3, Year = "2024-25", StartDate = new DateTime(2024, 6, 1), EndDate = new DateTime(2025, 5, 31), IsCurrent = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new AcademicYear { Id = 4, Year = "2025-26", StartDate = new DateTime(2025, 6, 1), EndDate = new DateTime(2026, 5, 31), IsCurrent = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        );

        // SystemSettings seed data - Only Academic Year and Backup Settings
        modelBuilder.Entity<SystemSetting>().HasData(
            // Academic Settings
            new SystemSetting { Key = "Academic.CurrentYear", Value = "2024-25", Description = "Current academic year", Category = "Academic", DataType = "String", DefaultValue = "2024-25", IsReadOnly = false, CreatedAt = DateTime.UtcNow },

            // Backup Settings
            new SystemSetting { Key = "Backup.AutoBackupEnabled", Value = "true", Description = "Enable automatic backup", Category = "Backup", DataType = "Boolean", DefaultValue = "true", IsReadOnly = false, CreatedAt = DateTime.UtcNow },
            new SystemSetting { Key = "Backup.RetentionDays", Value = "30", Description = "Days to retain backup files", Category = "Backup", DataType = "Integer", DefaultValue = "30", IsReadOnly = false, CreatedAt = DateTime.UtcNow },
            new SystemSetting { Key = "Backup.BackupPath", Value = "C:\\Users\\SP\\Documents\\IEMS_Backups", Description = "Default backup directory path", Category = "Backup", DataType = "DirectoryPath", DefaultValue = "", IsReadOnly = false, CreatedAt = DateTime.UtcNow }
        );
    }
}