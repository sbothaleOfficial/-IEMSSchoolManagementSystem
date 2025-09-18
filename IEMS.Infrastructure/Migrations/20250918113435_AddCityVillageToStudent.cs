using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IEMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCityVillageToStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MonthlySalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Position = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    BankAccountNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    AadharNumber = table.Column<string>(type: "TEXT", maxLength: 12, nullable: true),
                    PANNumber = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MonthlySalary = table.Column<decimal>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    BankAccountNumber = table.Column<string>(type: "TEXT", nullable: true),
                    AadharNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PANNumber = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VehicleNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    VehicleType = table.Column<int>(type: "INTEGER", nullable: false),
                    DriverName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DriverPhone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Route = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Section = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransportExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    FuelType = table.Column<int>(type: "INTEGER", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpenseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DriverName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    InvoiceNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportExpenses_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeeStructures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    FeeType = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AcademicYear = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeStructures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeeStructures_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SerialNo = table.Column<int>(type: "INTEGER", nullable: false),
                    Standard = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    ClassDivision = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    FatherName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    MotherName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    StudentNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CasteCategory = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Religion = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    IsBPL = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsSemiEnglish = table.Column<bool>(type: "INTEGER", nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CityVillage = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ParentMobileNumber = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeePayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReceiptNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    FeeType = table.Column<int>(type: "INTEGER", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "INTEGER", nullable: false),
                    TransactionId = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ChequeNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    BankName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    PaymentNotes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    PreviousBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemainingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LateFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InstallmentNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    NextDueDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AcademicYear = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    GeneratedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeePayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeePayments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "AadharNumber", "Address", "BankAccountNumber", "CreatedAt", "Email", "EmployeeId", "FirstName", "JoiningDate", "LastName", "MonthlySalary", "PANNumber", "PhoneNumber", "Position", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "123456789012", "101 Transport Ave, City", "1234567890", new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6895), "rajesh.kumar@school.edu", "ST001", "Rajesh", new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kumar", 25000m, "ABCDE1234F", "9876543213", "Driver", new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6895) },
                    { 2, "234567890123", "202 Clean St, City", "2345678901", new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6905), "kamala.devi@school.edu", "ST002", "Kamala", new DateTime(2019, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Devi", 18000m, "BCDEF2345G", "9876543215", "Peon", new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6905) },
                    { 3, "345678901234", "303 Office Lane, City", "3456789012", new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6909), "suresh.singh@school.edu", "ST003", "Suresh", new DateTime(2021, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singh", 22000m, "CDEFG3456H", "9876543217", "Clerk", new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6909) }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "AadharNumber", "Address", "BankAccountNumber", "CreatedAt", "Email", "EmployeeId", "FirstName", "JoiningDate", "LastName", "MonthlySalary", "PANNumber", "PhoneNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "1234-5678-9012", "123 Teachers Colony, Mumbai, Maharashtra", "SBI1234567890", new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6647), "priya.sharma@iemsschool.edu.in", "T001", "Priya", new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sharma", 55000m, "ABCDE1234F", "9876543201", new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6647) },
                    { 2, "2345-6789-0123", "456 Gandhi Nagar, Pune, Maharashtra", "HDFC9876543210", new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6652), "rajesh.patel@iemsschool.edu.in", "T002", "Rajesh", new DateTime(2019, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patel", 62000m, "FGHIJ5678K", "9876543202", new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6653) },
                    { 3, "3456-7890-1234", "789 Shivaji Park, Nashik, Maharashtra", "ICICI5432109876", new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6657), "anita.kulkarni@iemsschool.edu.in", "T003", "Anita", new DateTime(2021, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kulkarni", 48000m, "LMNOP9012Q", "9876543203", new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6657) },
                    { 4, "4567-8901-2345", "101 Nehru Colony, Nagpur, Maharashtra", "AXIS6789012345", new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6661), "suresh.gupta@iemsschool.edu.in", "T004", "Suresh", new DateTime(2018, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gupta", 68000m, "RSTUV3456W", "9876543204", new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6661) },
                    { 5, "5678-9012-3456", "202 Laxmi Nagar, Aurangabad, Maharashtra", null, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6664), null, "T005", "Kavita", new DateTime(2022, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singh", 45000m, null, "9876543205", new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6665) }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CreatedAt", "DriverName", "DriverPhone", "Route", "UpdatedAt", "VehicleNumber", "VehicleType" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6984), "Rajesh Kumar", "9876543213", "Main Street - School", new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6984), "MH12AB1234", 1 },
                    { 2, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6987), "Suresh Patil", "9876543214", "Park Road - School", new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6988), "MH12CD5678", 2 },
                    { 3, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6990), "Mohan Singh", "9876543215", "Highway - School", new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6990), "MH12EF9012", 3 }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "CreatedAt", "Name", "Section", "TeacherId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6816), "Grade 10", "A", 1, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6817) },
                    { 2, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6820), "Grade 10", "B", 2, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6821) },
                    { 3, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6822), "Grade 9", "A", 3, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6822) },
                    { 4, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6824), "Grade 9", "B", 4, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6824) },
                    { 5, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6825), "Grade 8", "A", 5, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6826) }
                });

            migrationBuilder.InsertData(
                table: "TransportExpenses",
                columns: new[] { "Id", "Amount", "Category", "CreatedAt", "Description", "DriverName", "ExpenseDate", "FuelType", "InvoiceNumber", "Quantity", "UpdatedAt", "VehicleId" },
                values: new object[,]
                {
                    { 1, 5000m, 1, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(7054), "Fuel refill for bus", "Rajesh Kumar", new DateTime(2025, 9, 13, 0, 0, 0, 0, DateTimeKind.Local), 1, "F001", 50m, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(7054), 1 },
                    { 2, 2500m, 2, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(7059), "Engine oil change", "Rajesh Kumar", new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "M001", 1m, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(7059), 1 },
                    { 3, 1200m, 1, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(7063), "CNG refill for auto", "Suresh Patil", new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Local), 3, "F002", 20m, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(7063), 2 }
                });

            migrationBuilder.InsertData(
                table: "FeeStructures",
                columns: new[] { "Id", "AcademicYear", "Amount", "ClassId", "CreatedAt", "Description", "FeeType", "IsActive", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "2024-25", 60000m, 1, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6934), "Annual Tuition Fees", 0, true, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6934) },
                    { 2, "2024-25", 5000m, 1, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6940), "One-time Admission Fees", 1, true, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6940) },
                    { 3, "2024-25", 2000m, 1, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6942), "Examination Fees", 2, true, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6942) },
                    { 4, "2024-25", 12000m, 1, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6943), "Annual Transport Fees", 3, true, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6943) },
                    { 5, "2024-25", 60000m, 2, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6945), "Annual Tuition Fees", 0, true, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6945) },
                    { 6, "2024-25", 5000m, 2, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6947), "One-time Admission Fees", 1, true, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6947) },
                    { 7, "2024-25", 2000m, 2, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6948), "Examination Fees", 2, true, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6948) },
                    { 8, "2024-25", 12000m, 2, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6950), "Annual Transport Fees", 3, true, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6950) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "AdmissionDate", "CasteCategory", "CityVillage", "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "FatherName", "FirstName", "Gender", "IsBPL", "IsSemiEnglish", "MotherName", "ParentMobileNumber", "Religion", "SerialNo", "Standard", "StudentNumber", "Surname", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "123 Main St, City", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Mumbai", "A", 1, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6852), new DateTime(2008, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Brown", "Alice", "Female", false, true, "Mary Brown", "9876543210", "Christian", 1, "10th", "S001", "Brown", new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6852) },
                    { 2, "456 Oak Ave, City", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Pune", "A", 1, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6864), new DateTime(2008, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "David Wilson", "Bob", "Male", true, false, "Susan Wilson", "9876543211", "Hindu", 2, "10th", "S002", "Wilson", new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6864) },
                    { 3, "789 Pine Rd, City", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Nashik", "B", 2, new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6869), new DateTime(2008, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael Davis", "Charlie", "Male", true, true, "Jennifer Davis", "9876543212", "Hindu", 3, "10th", "S003", "Davis", new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6869) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TeacherId",
                table: "Classes",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_FeePayments_ReceiptNumber",
                table: "FeePayments",
                column: "ReceiptNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeePayments_StudentId",
                table: "FeePayments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeStructures_ClassId_FeeType_AcademicYear",
                table: "FeeStructures",
                columns: new[] { "ClassId", "FeeType", "AcademicYear" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_EmployeeId",
                table: "Staff",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SerialNo",
                table: "Students",
                column: "SerialNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentNumber",
                table: "Students",
                column: "StudentNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_EmployeeId",
                table: "Teachers",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransportExpenses_VehicleId",
                table: "TransportExpenses",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleNumber",
                table: "Vehicles",
                column: "VehicleNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeePayments");

            migrationBuilder.DropTable(
                name: "FeeStructures");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "TransportExpenses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
