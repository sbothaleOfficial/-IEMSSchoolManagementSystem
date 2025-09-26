using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IEMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAcademicYearsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Year = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsCurrent = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYears", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AcademicYears",
                columns: new[] { "Id", "CreatedAt", "EndDate", "IsCurrent", "StartDate", "UpdatedAt", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2724), new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2725), "2022-23" },
                    { 2, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2727), new DateTime(2024, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2728), "2023-24" },
                    { 3, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2730), new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2731), "2024-25" },
                    { 4, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2733), new DateTime(2026, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2733), "2025-26" }
                });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1001), "Class 10", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1001) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1006), "Class 10", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1006) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1008), "Class 9", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1008) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1010), "Class 9", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1022), "Class 8", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1024) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Amount", "BillMonth", "CreatedAt", "DueDate", "Notes", "PaidDate", "Units", "UnitsRate", "UpdatedAt" },
                values: new object[] { 7200m, 1, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2463), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "January 2024 electricity bill", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 150m, 4.8m, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2464) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Amount", "BillMonth", "CreatedAt", "DueDate", "IsPaid", "Notes", "PaidDate", "PaymentMethod", "TransactionId", "Units", "UnitsRate", "UpdatedAt" },
                values: new object[] { 6800m, 2, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2468), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "February 2024 electricity bill", new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TXN123456", 140m, 4.8m, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2469) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Amount", "BankName", "BillMonth", "ChequeNumber", "CreatedAt", "DueDate", "Notes", "PaidDate", "PaymentMethod", "TransactionId", "Units", "UnitsRate", "UpdatedAt" },
                values: new object[] { 7500m, "SBI Bank", 3, "CH001", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2473), new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "March 2024 electricity bill", new DateTime(2024, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 155m, 4.8m, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2474) });

            migrationBuilder.InsertData(
                table: "ElectricityBills",
                columns: new[] { "Id", "Amount", "BankName", "BillMonth", "BillNumber", "BillYear", "ChequeNumber", "CreatedAt", "DueDate", "IsPaid", "Notes", "PaidDate", "PaymentMethod", "TransactionId", "Units", "UnitsRate", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, 8200m, null, 4, "EB004", 2024, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2477), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "April 2024 electricity bill", new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 170m, 4.8m, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2478) },
                    { 5, 9500m, null, 5, "EB005", 2024, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2483), new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "May 2024 electricity bill - High consumption due to summer", new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TXN234567", 200m, 4.75m, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2483) },
                    { 6, 10200m, null, 6, "EB006", 2024, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2487), new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "June 2024 electricity bill - Peak summer consumption", new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 220m, 4.6m, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2487) },
                    { 7, 7800m, null, 7, "EB007", 2024, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2491), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "July 2024 electricity bill", new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TXN789123", 165m, 4.7m, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2491) },
                    { 8, 8500m, null, 8, "EB008", 2024, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2496), new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "August 2024 electricity bill", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 180m, 4.7m, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2497) },
                    { 9, 9200m, null, 9, "EB009", 2024, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2500), new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "September 2024 electricity bill - Pending payment", null, null, null, 195m, 4.7m, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2500) },
                    { 10, 8800m, null, 10, "EB010", 2024, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2503), new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "October 2024 electricity bill - Current month", null, null, null, 185m, 4.75m, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2504) }
                });

            migrationBuilder.InsertData(
                table: "FeePayments",
                columns: new[] { "Id", "AcademicYear", "AmountPaid", "BankName", "ChequeNumber", "CreatedAt", "Discount", "FeeType", "GeneratedBy", "InstallmentNumber", "LateFee", "NextDueDate", "PaymentDate", "PaymentMethod", "PaymentNotes", "PreviousBalance", "ReceiptNumber", "RemainingBalance", "StudentId", "TransactionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "2024-25", 15000m, null, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2625), 0m, 0, "Admin", null, 0m, null, new DateTime(2025, 9, 4, 0, 0, 0, 0, DateTimeKind.Local), 0, null, 60000m, "REC001", 45000m, 1, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2625) },
                    { 2, "2024-25", 20000m, null, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2631), 0m, 0, "Admin", null, 0m, null, new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Local), 1, null, 60000m, "REC002", 40000m, 2, "TXN112233", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2631) },
                    { 3, "2024-25", 18000m, "HDFC Bank", "CH445566", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2646), 0m, 0, "Admin", null, 500m, null, new DateTime(2025, 9, 9, 0, 0, 0, 0, DateTimeKind.Local), 2, null, 60000m, "REC003", 42000m, 3, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2646) }
                });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2186), "Annual Tuition Fees for Class 10-A", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2186) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Amount", "ClassId", "CreatedAt", "Description", "FeeType", "UpdatedAt" },
                values: new object[] { 60000m, 2, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2191), "Annual Tuition Fees for Class 10-B", 0, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2191) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Amount", "ClassId", "CreatedAt", "Description", "FeeType", "UpdatedAt" },
                values: new object[] { 55000m, 3, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2193), "Annual Tuition Fees for Class 9-A", 0, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2193) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Amount", "ClassId", "CreatedAt", "Description", "FeeType", "UpdatedAt" },
                values: new object[] { 55000m, 4, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2194), "Annual Tuition Fees for Class 9-B", 0, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2195) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Amount", "ClassId", "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { 50000m, 5, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2196), "Annual Tuition Fees for Class 8-A", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2196) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Amount", "ClassId", "CreatedAt", "Description", "FeeType", "UpdatedAt" },
                values: new object[] { 50000m, 6, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2199), "Annual Tuition Fees for Class 8-B", 0, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2199) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Amount", "ClassId", "CreatedAt", "Description", "FeeType", "UpdatedAt" },
                values: new object[] { 45000m, 7, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2201), "Annual Tuition Fees for Class 7-A", 0, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2201) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Amount", "ClassId", "CreatedAt", "Description", "FeeType", "UpdatedAt" },
                values: new object[] { 40000m, 8, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2204), "Annual Tuition Fees for Class 6-A", 0, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2204) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2542), new DateTime(2025, 9, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2542) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2547), new DateTime(2025, 8, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2547) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2553), "Repair of desks and chairs in Class 10 classroom", new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2554) });

            migrationBuilder.InsertData(
                table: "OtherExpenses",
                columns: new[] { "Id", "Amount", "BankName", "Category", "ChequeNumber", "CreatedAt", "Description", "ExpenseDate", "ExpenseType", "InvoiceNumber", "Notes", "PaymentMethod", "TransactionId", "UpdatedAt", "VendorName" },
                values: new object[,]
                {
                    { 4, 8200m, null, 0, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2557), "Charts, models, and laboratory equipment", new DateTime(2025, 9, 4, 0, 0, 0, 0, DateTimeKind.Local), "Teaching Materials", "INV004", null, 0, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2557), "Educational Supplies Co" },
                    { 5, 22000m, null, 1, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2560), "Sports equipment, prizes, and refreshments for annual sports day", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Local), "Annual Sports Day", "INV005", null, 1, "TXN567890", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2561), "Sports Events Org" },
                    { 6, 12000m, "HDFC Bank", 2, "234567", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2564), "Repair of washroom facilities and water pipeline", new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Local), "Plumbing Work", "INV006", null, 2, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2565), "City Plumbers" },
                    { 7, 4500m, null, 0, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2569), "Keyboards, mouse, cables for computer lab", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), "Computer Accessories", "INV007", null, 0, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2570), "Tech Solutions" },
                    { 8, 3500m, null, 1, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2573), "Flowers, gifts, and refreshments for teachers day", new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Local), "Teachers Day Celebration", "INV008", null, 0, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2573), "Local Florist" },
                    { 9, 6800m, null, 2, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2577), "Plant care, fertilizers, and gardening tools", new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Local), "Garden Maintenance", "INV009", null, 1, "TXN678901", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2577), "Green Gardens" },
                    { 10, 18500m, "SBI Bank", 0, "345678", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2580), "New textbooks and reference books for library", new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Local), "Library Books", "INV010", null, 2, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2581), "Academic Publishers" }
                });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "CreatedAt", "UpdatedAt" },
                values: new object[] { "101 Transport Ave, Mumbai", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2107), new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2107) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "CreatedAt", "UpdatedAt" },
                values: new object[] { "202 Clean St, Delhi", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2118), new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2119) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "CreatedAt", "UpdatedAt" },
                values: new object[] { "303 Office Lane, Pune", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2123), new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2123) });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "AadharNumber", "Address", "BankAccountNumber", "CreatedAt", "Email", "EmployeeId", "FirstName", "JoiningDate", "LastName", "MonthlySalary", "PANNumber", "PhoneNumber", "Position", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, "456789012345", "404 Support St, Bangalore", "4567890123", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2127), "priya.mehta@school.edu", "ST004", "Priya", new DateTime(2020, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mehta", 20000m, "DEFGH4567I", "9876543218", "Lab Assistant", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2127) },
                    { 5, "567890123456", "505 Maintenance Rd, Chennai", "5678901234", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2130), "mohan.rao@school.edu", "ST005", "Mohan", new DateTime(2018, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rao", 28000m, "EFGHI5678J", "9876543219", "Electrician", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2130) },
                    { 6, "678901234567", "606 Admin Block, Kolkata", "6789012345", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2133), "sunita.nair@school.edu", "ST006", "Sunita", new DateTime(2021, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nair", 19000m, "FGHIJ6789K", "9876543220", "Office Assistant", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2133) },
                    { 7, "789012345678", "707 Security Gate, Hyderabad", "7890123456", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2136), "vinod.patil@school.edu", "ST007", "Vinod", new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patil", 16000m, "GHIJK7890L", "9876543221", "Security Guard", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2136) },
                    { 8, "890123456789", "808 Library Block, Ahmedabad", "8901234567", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2139), "lata.desai@school.edu", "ST008", "Lata", new DateTime(2020, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desai", 24000m, "HIJKL8901M", "9876543222", "Librarian", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2139) },
                    { 9, "901234567890", "909 Transport Yard, Jaipur", "9012345678", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2143), "ravi.iyer@school.edu", "ST009", "Ravi", new DateTime(2017, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iyer", 26000m, "IJKLM9012N", "9876543223", "Mechanic", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2144) },
                    { 10, "012345678901", "101 Canteen Block, Lucknow", "0123456789", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2146), "geeta.sharma@school.edu", "ST010", "Geeta", new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sharma", 17000m, "JKLMN0123O", "9876543224", "Cook", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2147) }
                });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "AdmissionDate", "CreatedAt", "DateOfBirth", "FatherName", "FirstName", "Gender", "MotherName", "ParentMobileNumber", "Religion", "Surname", "UpdatedAt" },
                values: new object[] { "11 Test Street, Mumbai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1069), new DateTime(2008, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khan Verma", "Aarav", "Male", "Pihu Sharma", "9876543211", "Hindu", "Sharma", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "AdmissionDate", "CityVillage", "CreatedAt", "DateOfBirth", "FatherName", "FirstName", "Gender", "IsBPL", "IsSemiEnglish", "MotherName", "ParentMobileNumber", "Religion", "Surname", "UpdatedAt" },
                values: new object[] { "21 Test Street, Delhi", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delhi", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1165), new DateTime(2008, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mishra Jain", "Ananya", "Female", false, true, "Krishna Patel", "9876543212", "Muslim", "Patel", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1165) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "AdmissionDate", "CityVillage", "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "FatherName", "FirstName", "IsBPL", "IsSemiEnglish", "MotherName", "ParentMobileNumber", "Religion", "Surname", "UpdatedAt" },
                values: new object[] { "31 Test Street, Pune", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pune", "A", 1, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1173), new DateTime(2008, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chopra Shah", "Arjun", false, false, "Advik Singh", "9876543213", "Christian", "Singh", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1174) });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "AdmissionDate", "CasteCategory", "CityVillage", "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "FatherName", "FirstName", "Gender", "IsBPL", "IsSemiEnglish", "MotherName", "ParentMobileNumber", "Religion", "SerialNo", "Standard", "StudentNumber", "Surname", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, "41 Test Street, Bangalore", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Bangalore", "A", 1, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1180), new DateTime(2008, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bansal Yadav", "Diya", "Female", false, true, "Samaira Kumar", "9876543214", "Sikh", 4, "10th", "S004", "Kumar", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1181) },
                    { 5, "51 Test Street, Chennai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Chennai", "A", 1, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1187), new DateTime(2008, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agrawal Reddy", "Ishaan", "Male", true, true, "Kiaan Gupta", "9876543215", "Jain", 5, "10th", "S005", "Gupta", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1188) },
                    { 6, "61 Test Street, Kolkata", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Kolkata", "A", 1, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1195), new DateTime(2008, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malhotra Khan", "Kavya", "Female", false, false, "Avni Agarwal", "9876543216", "Buddhist", 6, "10th", "S006", "Agarwal", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1195) },
                    { 7, "71 Test Street, Hyderabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Hyderabad", "A", 1, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1201), new DateTime(2008, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kapoor Mishra", "Karan", "Male", false, true, "Aryan Verma", "9876543217", "Hindu", 7, "10th", "S007", "Verma", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1201) },
                    { 8, "81 Test Street, Ahmedabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Ahmedabad", "A", 1, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1206), new DateTime(2008, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mittal Chopra", "Myra", "Female", false, true, "Pari Jain", "9876543218", "Muslim", 8, "10th", "S008", "Jain", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1207) },
                    { 9, "91 Test Street, Jaipur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Jaipur", "A", 1, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1212), new DateTime(2008, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joshi Bansal", "Riya", "Male", false, false, "Sai Shah", "9876543219", "Christian", 9, "10th", "S009", "Shah", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1212) },
                    { 10, "101 Test Street, Lucknow", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Lucknow", "A", 1, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1219), new DateTime(2008, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saxena Agrawal", "Vihaan", "Female", true, true, "Atharv Yadav", "9876543220", "Sikh", 10, "10th", "S010", "Yadav", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1219) },
                    { 11, "111 Test Street, Kanpur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Kanpur", "A", 1, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1226), new DateTime(2008, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Srivastava Malhotra", "Saanvi", "Male", false, true, "Ira Reddy", "9876543221", "Jain", 11, "10th", "S011", "Reddy", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1226) },
                    { 12, "121 Test Street, Nagpur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Nagpur", "A", 1, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1245), new DateTime(2008, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pandey Kapoor", "Reyansh", "Female", false, false, "Ayaan Khan", "9876543222", "Buddhist", 12, "10th", "S012", "Khan", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1245) },
                    { 13, "131 Test Street, Indore", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Indore", "A", 1, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1251), new DateTime(2008, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiwari Mittal", "Anvi", "Male", false, true, "Navya Mishra", "9876543223", "Hindu", 13, "10th", "S013", "Mishra", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1252) },
                    { 14, "141 Test Street, Bhopal", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Bhopal", "A", 1, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1257), new DateTime(2008, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dubey Joshi", "Vivaan", "Female", false, true, "Rudra Chopra", "9876543224", "Muslim", 14, "10th", "S014", "Chopra", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1258) },
                    { 15, "151 Test Street, Patna", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Patna", "A", 1, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1263), new DateTime(2008, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sharma Saxena", "Aadya", "Male", true, false, "Anaya Bansal", "9876543225", "Christian", 15, "10th", "S015", "Bansal", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1263) },
                    { 16, "161 Test Street, Vadodara", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Vadodara", "B", 2, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1270), new DateTime(2008, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patel Srivastava", "Aayan", "Female", false, true, "Om Agrawal", "9876543226", "Sikh", 16, "10th", "S016", "Agrawal", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1270) },
                    { 17, "171 Test Street, Ludhiana", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Ludhiana", "B", 2, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1276), new DateTime(2008, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singh Pandey", "Pihu", "Male", false, true, "Tara Malhotra", "9876543227", "Jain", 17, "10th", "S017", "Malhotra", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1277) },
                    { 18, "181 Test Street, Agra", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Agra", "B", 2, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1283), new DateTime(2008, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kumar Tiwari", "Krishna", "Female", false, false, "Shaurya Kapoor", "9876543228", "Buddhist", 18, "10th", "S018", "Kapoor", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1284) },
                    { 19, "191 Test Street, Nashik", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Nashik", "B", 2, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1289), new DateTime(2008, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gupta Dubey", "Advik", "Male", false, true, "Kashvi Mittal", "9876543229", "Hindu", 19, "10th", "S019", "Mittal", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1290) },
                    { 20, "201 Test Street, Faridabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Faridabad", "B", 2, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1295), new DateTime(2008, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agarwal Sharma", "Samaira", "Female", true, true, "Mihir Joshi", "9876543230", "Muslim", 20, "10th", "S020", "Joshi", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1295) },
                    { 21, "211 Test Street, Meerut", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Meerut", "B", 2, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1301), new DateTime(2008, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Verma Patel", "Kiaan", "Male", false, false, "Prisha Saxena", "9876543231", "Christian", 21, "10th", "S021", "Saxena", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1301) },
                    { 22, "221 Test Street, Rajkot", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Rajkot", "B", 2, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1307), new DateTime(2008, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jain Singh", "Avni", "Female", false, true, "Aadhya Srivastava", "9876543232", "Sikh", 22, "10th", "S022", "Srivastava", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1307) },
                    { 23, "231 Test Street, Kalyan", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Kalyan", "B", 2, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1312), new DateTime(2008, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shah Kumar", "Aryan", "Male", false, true, "Dev Pandey", "9876543233", "Jain", 23, "10th", "S023", "Pandey", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1313) },
                    { 24, "241 Test Street, Vasai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Vasai", "B", 2, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1318), new DateTime(2008, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yadav Gupta", "Pari", "Female", false, false, "Krisha Tiwari", "9876543234", "Buddhist", 24, "10th", "S024", "Tiwari", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1318) },
                    { 25, "251 Test Street, Varanasi", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Varanasi", "B", 2, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1324), new DateTime(2008, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reddy Agarwal", "Sai", "Male", true, true, "Arnav Dubey", "9876543235", "Hindu", 25, "10th", "S025", "Dubey", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1324) },
                    { 26, "261 Test Street, Mumbai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Mumbai", "B", 2, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1330), new DateTime(2008, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khan Verma", "Atharv", "Female", false, true, "Janvi Sharma", "9876543236", "Muslim", 26, "10th", "S026", "Sharma", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1330) },
                    { 27, "271 Test Street, Delhi", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Delhi", "B", 2, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1335), new DateTime(2008, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mishra Jain", "Ira", "Male", false, false, "Yug Patel", "9876543237", "Christian", 27, "10th", "S027", "Patel", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1336) },
                    { 28, "281 Test Street, Pune", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Pune", "B", 2, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1341), new DateTime(2008, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chopra Shah", "Ayaan", "Female", false, true, "Shanaya Singh", "9876543238", "Sikh", 28, "10th", "S028", "Singh", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1341) },
                    { 29, "291 Test Street, Bangalore", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Bangalore", "B", 2, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1358), new DateTime(2008, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bansal Yadav", "Navya", "Male", false, true, "Arjun Kumar", "9876543239", "Jain", 29, "10th", "S029", "Kumar", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1359) },
                    { 30, "301 Test Street, Chennai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Chennai", "B", 2, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1365), new DateTime(2008, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agrawal Reddy", "Rudra", "Female", true, false, "Anika Gupta", "9876543240", "Buddhist", 30, "10th", "S030", "Gupta", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1365) },
                    { 31, "311 Test Street, Kolkata", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Kolkata", "A", 3, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1371), new DateTime(2009, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malhotra Khan", "Anaya", "Male", false, true, "Vedant Agarwal", "9876543241", "Hindu", 31, "9th", "S031", "Agarwal", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1372) },
                    { 32, "321 Test Street, Hyderabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Hyderabad", "A", 3, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1378), new DateTime(2009, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kapoor Mishra", "Om", "Female", false, true, "Reet Verma", "9876543242", "Muslim", 32, "9th", "S032", "Verma", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1379) },
                    { 33, "331 Test Street, Ahmedabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Ahmedabad", "A", 3, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1384), new DateTime(2009, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mittal Chopra", "Tara", "Male", false, false, "Aarush Jain", "9876543243", "Christian", 33, "9th", "S033", "Jain", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1385) },
                    { 34, "341 Test Street, Jaipur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Jaipur", "A", 3, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1391), new DateTime(2009, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joshi Bansal", "Shaurya", "Female", false, true, "Khushi Shah", "9876543244", "Sikh", 34, "9th", "S034", "Shah", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1391) },
                    { 35, "351 Test Street, Lucknow", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Lucknow", "A", 3, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1397), new DateTime(2009, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saxena Agrawal", "Kashvi", "Male", true, true, "Aarav Yadav", "9876543245", "Jain", 35, "9th", "S035", "Yadav", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1397) },
                    { 36, "361 Test Street, Kanpur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Kanpur", "A", 3, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1403), new DateTime(2009, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Srivastava Malhotra", "Mihir", "Female", false, false, "Ananya Reddy", "9876543246", "Buddhist", 36, "9th", "S036", "Reddy", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1403) },
                    { 37, "371 Test Street, Nagpur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Nagpur", "A", 3, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1409), new DateTime(2009, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pandey Kapoor", "Prisha", "Male", false, true, "Arjun Khan", "9876543247", "Hindu", 37, "9th", "S037", "Khan", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1409) },
                    { 38, "381 Test Street, Indore", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Indore", "A", 3, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1415), new DateTime(2009, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiwari Mittal", "Aadhya", "Female", false, true, "Diya Mishra", "9876543248", "Muslim", 38, "9th", "S038", "Mishra", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1415) },
                    { 39, "391 Test Street, Bhopal", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Bhopal", "A", 3, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1421), new DateTime(2009, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dubey Joshi", "Dev", "Male", false, false, "Ishaan Chopra", "9876543249", "Christian", 39, "9th", "S039", "Chopra", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1421) },
                    { 40, "401 Test Street, Patna", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Patna", "A", 3, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1426), new DateTime(2009, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sharma Saxena", "Krisha", "Female", true, true, "Kavya Bansal", "9876543250", "Sikh", 40, "9th", "S040", "Bansal", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1426) },
                    { 41, "411 Test Street, Vadodara", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Vadodara", "A", 3, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1432), new DateTime(2009, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patel Srivastava", "Arnav", "Male", false, true, "Karan Agrawal", "9876543251", "Jain", 41, "9th", "S041", "Agrawal", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1432) },
                    { 42, "421 Test Street, Ludhiana", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Ludhiana", "A", 3, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1438), new DateTime(2009, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singh Pandey", "Janvi", "Female", false, false, "Myra Malhotra", "9876543252", "Buddhist", 42, "9th", "S042", "Malhotra", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1438) },
                    { 43, "431 Test Street, Agra", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Agra", "B", 4, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1444), new DateTime(2009, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kumar Tiwari", "Yug", "Male", false, true, "Riya Kapoor", "9876543253", "Hindu", 43, "9th", "S043", "Kapoor", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1445) },
                    { 44, "441 Test Street, Nashik", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Nashik", "B", 4, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1450), new DateTime(2009, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gupta Dubey", "Shanaya", "Female", false, true, "Vihaan Mittal", "9876543254", "Muslim", 44, "9th", "S044", "Mittal", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1451) },
                    { 45, "451 Test Street, Faridabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Faridabad", "B", 4, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1456), new DateTime(2009, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agarwal Sharma", "Arjun", "Male", true, false, "Saanvi Joshi", "9876543255", "Christian", 45, "9th", "S045", "Joshi", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1456) },
                    { 46, "461 Test Street, Meerut", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Meerut", "B", 4, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1475), new DateTime(2009, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Verma Patel", "Anika", "Female", false, true, "Reyansh Saxena", "9876543256", "Sikh", 46, "9th", "S046", "Saxena", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1475) },
                    { 47, "471 Test Street, Rajkot", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Rajkot", "B", 4, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1482), new DateTime(2009, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jain Singh", "Vedant", "Male", false, true, "Anvi Srivastava", "9876543257", "Jain", 47, "9th", "S047", "Srivastava", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1482) },
                    { 48, "481 Test Street, Kalyan", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Kalyan", "B", 4, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1487), new DateTime(2009, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shah Kumar", "Reet", "Female", false, false, "Vivaan Pandey", "9876543258", "Buddhist", 48, "9th", "S048", "Pandey", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1488) },
                    { 49, "491 Test Street, Vasai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Vasai", "B", 4, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1493), new DateTime(2009, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yadav Gupta", "Aarush", "Male", false, true, "Aadya Tiwari", "9876543259", "Hindu", 49, "9th", "S049", "Tiwari", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1493) },
                    { 50, "501 Test Street, Varanasi", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Varanasi", "B", 4, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1499), new DateTime(2009, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reddy Agarwal", "Khushi", "Female", true, true, "Aayan Dubey", "9876543260", "Muslim", 50, "9th", "S050", "Dubey", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1499) },
                    { 51, "511 Test Street, Mumbai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Mumbai", "B", 4, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1505), new DateTime(2009, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khan Verma", "Aarav", "Male", false, false, "Pihu Sharma", "9876543261", "Christian", 51, "9th", "S051", "Sharma", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1505) },
                    { 52, "521 Test Street, Delhi", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Delhi", "B", 4, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1511), new DateTime(2009, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mishra Jain", "Ananya", "Female", false, true, "Krishna Patel", "9876543262", "Sikh", 52, "9th", "S052", "Patel", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1512) },
                    { 53, "531 Test Street, Pune", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Pune", "B", 4, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1517), new DateTime(2009, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chopra Shah", "Arjun", "Male", false, true, "Advik Singh", "9876543263", "Jain", 53, "9th", "S053", "Singh", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1518) },
                    { 54, "541 Test Street, Bangalore", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Bangalore", "B", 4, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1523), new DateTime(2009, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bansal Yadav", "Diya", "Female", false, false, "Samaira Kumar", "9876543264", "Buddhist", 54, "9th", "S054", "Kumar", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1523) },
                    { 55, "551 Test Street, Chennai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Chennai", "A", 5, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1529), new DateTime(2010, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agrawal Reddy", "Ishaan", "Male", true, true, "Kiaan Gupta", "9876543265", "Hindu", 55, "8th", "S055", "Gupta", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1530) },
                    { 56, "561 Test Street, Kolkata", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Kolkata", "A", 5, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1538), new DateTime(2010, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malhotra Khan", "Kavya", "Female", false, true, "Avni Agarwal", "9876543266", "Muslim", 56, "8th", "S056", "Agarwal", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1538) },
                    { 57, "571 Test Street, Hyderabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Hyderabad", "A", 5, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1544), new DateTime(2010, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kapoor Mishra", "Karan", "Male", false, false, "Aryan Verma", "9876543267", "Christian", 57, "8th", "S057", "Verma", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1544) },
                    { 58, "581 Test Street, Ahmedabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Ahmedabad", "A", 5, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1550), new DateTime(2010, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mittal Chopra", "Myra", "Female", false, true, "Pari Jain", "9876543268", "Sikh", 58, "8th", "S058", "Jain", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1550) },
                    { 59, "591 Test Street, Jaipur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Jaipur", "A", 5, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1556), new DateTime(2010, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joshi Bansal", "Riya", "Male", false, true, "Sai Shah", "9876543269", "Jain", 59, "8th", "S059", "Shah", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1556) },
                    { 60, "601 Test Street, Lucknow", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Lucknow", "A", 5, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1562), new DateTime(2010, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saxena Agrawal", "Vihaan", "Female", true, false, "Atharv Yadav", "9876543270", "Buddhist", 60, "8th", "S060", "Yadav", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1562) },
                    { 61, "611 Test Street, Kanpur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Kanpur", "A", 5, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1568), new DateTime(2010, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Srivastava Malhotra", "Saanvi", "Male", false, true, "Ira Reddy", "9876543271", "Hindu", 61, "8th", "S061", "Reddy", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1569) },
                    { 62, "621 Test Street, Nagpur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Nagpur", "A", 5, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1574), new DateTime(2010, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pandey Kapoor", "Reyansh", "Female", false, true, "Ayaan Khan", "9876543272", "Muslim", 62, "8th", "S062", "Khan", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1575) },
                    { 63, "631 Test Street, Indore", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Indore", "A", 5, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1596), new DateTime(2010, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiwari Mittal", "Anvi", "Male", false, false, "Navya Mishra", "9876543273", "Christian", 63, "8th", "S063", "Mishra", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1597) },
                    { 64, "641 Test Street, Bhopal", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Bhopal", "A", 5, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1603), new DateTime(2010, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dubey Joshi", "Vivaan", "Female", false, true, "Rudra Chopra", "9876543274", "Sikh", 64, "8th", "S064", "Chopra", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1603) }
                });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "CreatedAt", "UpdatedAt" },
                values: new object[] { "123 Teachers Colony, Mumbai", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(768), new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(769) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "CreatedAt", "UpdatedAt" },
                values: new object[] { "456 Gandhi Nagar, Pune", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(774), new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(774) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "CreatedAt", "UpdatedAt" },
                values: new object[] { "789 Shivaji Park, Nashik", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(779), new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(779) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "CreatedAt", "UpdatedAt" },
                values: new object[] { "101 Nehru Colony, Nagpur", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(783), new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(783) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "BankAccountNumber", "CreatedAt", "Email", "PANNumber", "UpdatedAt" },
                values: new object[] { "202 Laxmi Nagar, Aurangabad", "PNB3456789012", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(787), "kavita.singh@iemsschool.edu.in", "WXYZ7890A", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(788) });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "AadharNumber", "Address", "BankAccountNumber", "CreatedAt", "Email", "EmployeeId", "FirstName", "JoiningDate", "LastName", "MonthlySalary", "PANNumber", "PhoneNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 6, "6789-0123-4567", "303 Saraswati Vihar, Delhi", "BOI4567890123", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(791), "amit.verma@iemsschool.edu.in", "T006", "Amit", new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Verma", 52000m, "BCDEF8901B", "9876543206", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(792) },
                    { 7, "7890-1234-5678", "404 Indira Nagar, Jaipur", "UCO5678901234", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(795), "sunita.joshi@iemsschool.edu.in", "T007", "Sunita", new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joshi", 58000m, "CDEFG9012C", "9876543207", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(796) },
                    { 8, "8901-2345-6789", "505 Vasant Kunj, Lucknow", "CBI6789012345", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(799), "vikram.yadav@iemsschool.edu.in", "T008", "Vikram", new DateTime(2021, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yadav", 46000m, "DEFGH0123D", "9876543208", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(799) },
                    { 9, "9012-3456-7890", "606 MG Road, Bangalore", "IOB7890123456", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(803), "meera.agarwal@iemsschool.edu.in", "T009", "Meera", new DateTime(2020, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agarwal", 54000m, "EFGHI1234E", "9876543209", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(803) },
                    { 10, "0123-4567-8901", "707 Park Street, Kolkata", "UNION8901234567", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(807), "rohit.mishra@iemsschool.edu.in", "T010", "Rohit", new DateTime(2018, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mishra", 65000m, "FGHIJ2345F", "9876543210", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(807) }
                });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2366), new DateTime(2025, 9, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2366) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Amount", "Category", "CreatedAt", "Description", "DriverName", "ExpenseDate", "FuelType", "InvoiceNumber", "Quantity", "UpdatedAt", "VehicleId" },
                values: new object[] { 1200m, 1, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2371), "CNG refill for auto", "Suresh Patil", new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Local), 3, "F002", 20m, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2371), 2 });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Amount", "Category", "CreatedAt", "Description", "DriverName", "ExpenseDate", "FuelType", "InvoiceNumber", "Quantity", "UpdatedAt", "VehicleId" },
                values: new object[] { 3500m, 2, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2377), "Brake pad replacement", "Mohan Singh", new DateTime(2025, 9, 17, 0, 0, 0, 0, DateTimeKind.Local), null, "M001", 1m, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2377), 3 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2249), new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2249) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2252), new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2253) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2255), new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2255) });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CreatedAt", "DriverName", "DriverPhone", "Route", "UpdatedAt", "VehicleNumber", "VehicleType" },
                values: new object[,]
                {
                    { 4, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2271), "Ashok Yadav", "9876543216", "South Delhi - School", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2271), "DL8CAB9876", 1 },
                    { 5, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2273), "Ramesh Gupta", "9876543217", "Lucknow City - School", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2274), "UP16GH3456", 2 },
                    { 6, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2276), "Prakash Nair", "9876543218", "Bangalore North - School", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2276), "KA05JK7890", 3 },
                    { 7, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2278), "Murugan Pillai", "9876543219", "Chennai Central - School", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2279), "TN07LM2345", 1 },
                    { 8, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2281), "Biswajit Das", "9876543220", "Kolkata East - School", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2282), "WB10NO6789", 2 },
                    { 9, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2284), "Dinesh Sharma", "9876543221", "Jaipur Pink City - School", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2284), "RJ14PQ0123", 3 },
                    { 10, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2286), "Kiran Patel", "9876543222", "Ahmedabad West - School", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2287), "GJ01RS4567", 1 }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "CreatedAt", "Name", "Section", "TeacherId", "UpdatedAt" },
                values: new object[,]
                {
                    { 6, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1025), "Class 8", "B", 6, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1025) },
                    { 7, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1027), "Class 7", "A", 7, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1028) },
                    { 8, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1029), "Class 6", "A", 8, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1029) },
                    { 9, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1031), "Class 5", "A", 9, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1031) },
                    { 10, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1032), "Class 1", "A", 10, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1033) }
                });

            migrationBuilder.InsertData(
                table: "FeePayments",
                columns: new[] { "Id", "AcademicYear", "AmountPaid", "BankName", "ChequeNumber", "CreatedAt", "Discount", "FeeType", "GeneratedBy", "InstallmentNumber", "LateFee", "NextDueDate", "PaymentDate", "PaymentMethod", "PaymentNotes", "PreviousBalance", "ReceiptNumber", "RemainingBalance", "StudentId", "TransactionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, "2024-25", 10000m, null, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2651), 1000m, 0, "Admin", null, 0m, null, new DateTime(2025, 8, 30, 0, 0, 0, 0, DateTimeKind.Local), 0, null, 35000m, "REC004", 25000m, 10, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2651) },
                    { 5, "2024-25", 12000m, null, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2656), 0m, 0, "Admin", null, 0m, null, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Local), 1, null, 55000m, "REC005", 43000m, 15, "TXN223344", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2657) },
                    { 6, "2024-25", 5000m, null, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2661), 0m, 1, "Admin", null, 0m, null, new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), 0, null, 5000m, "REC006", 0m, 20, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2661) },
                    { 7, "2024-25", 4000m, null, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2666), 0m, 3, "Admin", null, 0m, null, new DateTime(2025, 9, 2, 0, 0, 0, 0, DateTimeKind.Local), 1, null, 12000m, "REC007", 8000m, 25, "TXN334455", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2667) },
                    { 8, "2024-25", 2000m, null, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2671), 0m, 2, "Admin", null, 0m, null, new DateTime(2025, 9, 19, 0, 0, 0, 0, DateTimeKind.Local), 0, null, 2000m, "REC008", 0m, 30, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2671) },
                    { 9, "2024-25", 8000m, "SBI Bank", "CH556677", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2676), 500m, 0, "Admin", null, 200m, null, new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Local), 2, null, 38000m, "REC009", 30000m, 35, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2677) },
                    { 10, "2024-25", 16000m, null, null, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2684), 0m, 0, "Admin", null, 0m, null, new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Local), 1, null, 50000m, "REC010", 34000m, 40, "TXN445566", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2684) }
                });

            migrationBuilder.InsertData(
                table: "TransportExpenses",
                columns: new[] { "Id", "Amount", "Category", "CreatedAt", "Description", "DriverName", "ExpenseDate", "FuelType", "InvoiceNumber", "Quantity", "UpdatedAt", "VehicleId" },
                values: new object[,]
                {
                    { 4, 6200m, 1, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2383), "Weekly diesel refill", "Ashok Yadav", new DateTime(2025, 9, 22, 0, 0, 0, 0, DateTimeKind.Local), 1, "F003", 65m, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2384), 4 },
                    { 5, 980m, 1, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2390), "CNG refill", "Ramesh Gupta", new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 3, "F004", 15m, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2390), 5 },
                    { 6, 2800m, 2, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2394), "Tire replacement", "Prakash Nair", new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Local), null, "M002", 1m, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2394), 6 },
                    { 7, 4800m, 1, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2398), "Daily diesel supply", "Murugan Pillai", new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Local), 1, "F005", 45m, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2399), 7 },
                    { 8, 1400m, 1, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2402), "Auto CNG refill", "Biswajit Das", new DateTime(2025, 9, 18, 0, 0, 0, 0, DateTimeKind.Local), 3, "F006", 22m, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2403), 8 },
                    { 9, 4200m, 2, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2407), "Engine service and oil change", "Dinesh Sharma", new DateTime(2025, 9, 9, 0, 0, 0, 0, DateTimeKind.Local), null, "M003", 1m, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2407), 9 },
                    { 10, 5500m, 1, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2411), "Bus fuel refill", "Kiran Patel", new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Local), 1, "F007", 55m, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2411), 10 }
                });

            migrationBuilder.InsertData(
                table: "FeeStructures",
                columns: new[] { "Id", "AcademicYear", "Amount", "ClassId", "CreatedAt", "Description", "FeeType", "IsActive", "UpdatedAt" },
                values: new object[,]
                {
                    { 9, "2024-25", 38000m, 9, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2206), "Annual Tuition Fees for Class 5-A", 0, true, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2206) },
                    { 10, "2024-25", 35000m, 10, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2208), "Annual Tuition Fees for Class 1-A", 0, true, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(2208) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "AdmissionDate", "CasteCategory", "CityVillage", "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "FatherName", "FirstName", "Gender", "IsBPL", "IsSemiEnglish", "MotherName", "ParentMobileNumber", "Religion", "SerialNo", "Standard", "StudentNumber", "Surname", "UpdatedAt" },
                values: new object[,]
                {
                    { 65, "651 Test Street, Patna", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Patna", "B", 6, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1610), new DateTime(2010, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sharma Saxena", "Aadya", "Male", true, true, "Anaya Bansal", "9876543275", "Jain", 65, "8th", "S065", "Bansal", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1610) },
                    { 66, "661 Test Street, Vadodara", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Vadodara", "B", 6, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1617), new DateTime(2010, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patel Srivastava", "Aayan", "Female", false, false, "Om Agrawal", "9876543276", "Buddhist", 66, "8th", "S066", "Agrawal", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1617) },
                    { 67, "671 Test Street, Ludhiana", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Ludhiana", "B", 6, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1623), new DateTime(2010, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singh Pandey", "Pihu", "Male", false, true, "Tara Malhotra", "9876543277", "Hindu", 67, "8th", "S067", "Malhotra", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1623) },
                    { 68, "681 Test Street, Agra", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Agra", "B", 6, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1629), new DateTime(2010, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kumar Tiwari", "Krishna", "Female", false, true, "Shaurya Kapoor", "9876543278", "Muslim", 68, "8th", "S068", "Kapoor", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1629) },
                    { 69, "691 Test Street, Nashik", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Nashik", "B", 6, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1634), new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gupta Dubey", "Advik", "Male", false, false, "Kashvi Mittal", "9876543279", "Christian", 69, "8th", "S069", "Mittal", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1635) },
                    { 70, "701 Test Street, Faridabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Faridabad", "B", 6, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1640), new DateTime(2010, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agarwal Sharma", "Samaira", "Female", true, true, "Mihir Joshi", "9876543280", "Sikh", 70, "8th", "S070", "Joshi", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1641) },
                    { 71, "711 Test Street, Meerut", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Meerut", "B", 6, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1647), new DateTime(2010, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Verma Patel", "Kiaan", "Male", false, true, "Prisha Saxena", "9876543281", "Jain", 71, "8th", "S071", "Saxena", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1647) },
                    { 72, "721 Test Street, Rajkot", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Rajkot", "B", 6, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1652), new DateTime(2010, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jain Singh", "Avni", "Female", false, false, "Aadhya Srivastava", "9876543282", "Buddhist", 72, "8th", "S072", "Srivastava", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1653) },
                    { 73, "731 Test Street, Kalyan", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Kalyan", "B", 6, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1658), new DateTime(2010, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shah Kumar", "Aryan", "Male", false, true, "Dev Pandey", "9876543283", "Hindu", 73, "8th", "S073", "Pandey", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1659) },
                    { 74, "741 Test Street, Vasai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Vasai", "B", 6, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1664), new DateTime(2010, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yadav Gupta", "Pari", "Female", false, true, "Krisha Tiwari", "9876543284", "Muslim", 74, "8th", "S074", "Tiwari", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1664) },
                    { 75, "751 Test Street, Varanasi", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Varanasi", "A", 7, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1671), new DateTime(2011, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reddy Agarwal", "Sai", "Male", true, false, "Arnav Dubey", "9876543285", "Christian", 75, "7th", "S075", "Dubey", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1671) },
                    { 76, "761 Test Street, Mumbai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Mumbai", "A", 7, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1678), new DateTime(2011, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khan Verma", "Atharv", "Female", false, true, "Janvi Sharma", "9876543286", "Sikh", 76, "7th", "S076", "Sharma", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1679) },
                    { 77, "771 Test Street, Delhi", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Delhi", "A", 7, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1684), new DateTime(2011, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mishra Jain", "Ira", "Male", false, true, "Yug Patel", "9876543287", "Jain", 77, "7th", "S077", "Patel", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1685) },
                    { 78, "781 Test Street, Pune", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Pune", "A", 7, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1703), new DateTime(2011, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chopra Shah", "Ayaan", "Female", false, false, "Shanaya Singh", "9876543288", "Buddhist", 78, "7th", "S078", "Singh", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1705) },
                    { 79, "791 Test Street, Bangalore", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Bangalore", "A", 7, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1711), new DateTime(2011, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bansal Yadav", "Navya", "Male", false, true, "Arjun Kumar", "9876543289", "Hindu", 79, "7th", "S079", "Kumar", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1711) },
                    { 80, "801 Test Street, Chennai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Chennai", "A", 7, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1717), new DateTime(2011, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agrawal Reddy", "Rudra", "Female", true, true, "Anika Gupta", "9876543290", "Muslim", 80, "7th", "S080", "Gupta", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1718) },
                    { 81, "811 Test Street, Kolkata", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Kolkata", "A", 7, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1724), new DateTime(2011, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malhotra Khan", "Anaya", "Male", false, false, "Vedant Agarwal", "9876543291", "Christian", 81, "7th", "S081", "Agarwal", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1724) },
                    { 82, "821 Test Street, Hyderabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Hyderabad", "A", 7, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1730), new DateTime(2011, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kapoor Mishra", "Om", "Female", false, true, "Reet Verma", "9876543292", "Sikh", 82, "7th", "S082", "Verma", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1730) },
                    { 83, "831 Test Street, Ahmedabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Ahmedabad", "A", 7, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1736), new DateTime(2011, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mittal Chopra", "Tara", "Male", false, true, "Aarush Jain", "9876543293", "Jain", 83, "7th", "S083", "Jain", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1736) },
                    { 84, "841 Test Street, Jaipur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Jaipur", "A", 7, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1742), new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joshi Bansal", "Shaurya", "Female", false, false, "Khushi Shah", "9876543294", "Buddhist", 84, "7th", "S084", "Shah", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1742) },
                    { 85, "851 Test Street, Lucknow", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Lucknow", "A", 8, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1748), new DateTime(2012, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saxena Agrawal", "Kashvi", "Male", true, true, "Aarav Yadav", "9876543295", "Hindu", 85, "6th", "S085", "Yadav", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1749) },
                    { 86, "861 Test Street, Kanpur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Kanpur", "A", 8, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1756), new DateTime(2012, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Srivastava Malhotra", "Mihir", "Female", false, true, "Ananya Reddy", "9876543296", "Muslim", 86, "6th", "S086", "Reddy", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1756) },
                    { 87, "871 Test Street, Nagpur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Nagpur", "A", 8, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1762), new DateTime(2012, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pandey Kapoor", "Prisha", "Male", false, false, "Arjun Khan", "9876543297", "Christian", 87, "6th", "S087", "Khan", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1763) },
                    { 88, "881 Test Street, Indore", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Indore", "A", 8, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1768), new DateTime(2012, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiwari Mittal", "Aadhya", "Female", false, true, "Diya Mishra", "9876543298", "Sikh", 88, "6th", "S088", "Mishra", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1769) },
                    { 89, "891 Test Street, Bhopal", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Bhopal", "A", 8, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1774), new DateTime(2012, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dubey Joshi", "Dev", "Male", false, true, "Ishaan Chopra", "9876543299", "Jain", 89, "6th", "S089", "Chopra", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1775) },
                    { 90, "901 Test Street, Patna", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Patna", "A", 8, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1780), new DateTime(2012, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sharma Saxena", "Krisha", "Female", true, false, "Kavya Bansal", "9876543300", "Buddhist", 90, "6th", "S090", "Bansal", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1781) },
                    { 91, "911 Test Street, Vadodara", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Vadodara", "A", 8, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1786), new DateTime(2012, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patel Srivastava", "Arnav", "Male", false, true, "Karan Agrawal", "9876543301", "Hindu", 91, "6th", "S091", "Agrawal", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1786) },
                    { 92, "921 Test Street, Ludhiana", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Ludhiana", "A", 8, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1792), new DateTime(2012, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singh Pandey", "Janvi", "Female", false, true, "Myra Malhotra", "9876543302", "Muslim", 92, "6th", "S092", "Malhotra", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1793) },
                    { 93, "931 Test Street, Agra", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Agra", "A", 8, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1798), new DateTime(2012, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kumar Tiwari", "Yug", "Male", false, false, "Riya Kapoor", "9876543303", "Christian", 93, "6th", "S093", "Kapoor", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1799) },
                    { 94, "941 Test Street, Nashik", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Nashik", "A", 8, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1804), new DateTime(2012, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gupta Dubey", "Shanaya", "Female", false, true, "Vihaan Mittal", "9876543304", "Sikh", 94, "6th", "S094", "Mittal", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1805) },
                    { 95, "951 Test Street, Faridabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Faridabad", "A", 9, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1811), new DateTime(2013, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agarwal Sharma", "Arjun", "Male", true, true, "Saanvi Joshi", "9876543305", "Jain", 95, "5th", "S095", "Joshi", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1811) },
                    { 96, "961 Test Street, Meerut", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Meerut", "A", 9, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1836), new DateTime(2013, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Verma Patel", "Anika", "Female", false, false, "Reyansh Saxena", "9876543306", "Buddhist", 96, "5th", "S096", "Saxena", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1837) },
                    { 97, "971 Test Street, Rajkot", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Rajkot", "A", 9, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1843), new DateTime(2013, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jain Singh", "Vedant", "Male", false, true, "Anvi Srivastava", "9876543307", "Hindu", 97, "5th", "S097", "Srivastava", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1843) },
                    { 98, "981 Test Street, Kalyan", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Kalyan", "A", 9, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1849), new DateTime(2013, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shah Kumar", "Reet", "Female", false, true, "Vivaan Pandey", "9876543308", "Muslim", 98, "5th", "S098", "Pandey", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1849) },
                    { 99, "991 Test Street, Vasai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Vasai", "A", 9, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1856), new DateTime(2013, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yadav Gupta", "Aarush", "Male", false, false, "Aadya Tiwari", "9876543309", "Christian", 99, "5th", "S099", "Tiwari", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1856) },
                    { 100, "1001 Test Street, Varanasi", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Varanasi", "A", 9, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1862), new DateTime(2013, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reddy Agarwal", "Khushi", "Female", true, true, "Aayan Dubey", "9876543310", "Sikh", 100, "5th", "S100", "Dubey", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1862) },
                    { 101, "1011 Test Street, Mumbai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Mumbai", "A", 9, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1869), new DateTime(2013, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khan Verma", "Aarav", "Male", false, true, "Pihu Sharma", "9876543311", "Jain", 101, "5th", "S101", "Sharma", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1869) },
                    { 102, "1021 Test Street, Delhi", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Delhi", "A", 9, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1876), new DateTime(2013, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mishra Jain", "Ananya", "Female", false, false, "Krishna Patel", "9876543312", "Buddhist", 102, "5th", "S102", "Patel", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1876) },
                    { 103, "1031 Test Street, Pune", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Pune", "A", 9, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1882), new DateTime(2013, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chopra Shah", "Arjun", "Male", false, true, "Advik Singh", "9876543313", "Hindu", 103, "5th", "S103", "Singh", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1882) },
                    { 104, "1041 Test Street, Bangalore", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Bangalore", "A", 9, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1888), new DateTime(2013, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bansal Yadav", "Diya", "Female", false, true, "Samaira Kumar", "9876543314", "Muslim", 104, "5th", "S104", "Kumar", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1888) },
                    { 105, "1051 Test Street, Chennai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Chennai", "A", 10, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1895), new DateTime(2017, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agrawal Reddy", "Ishaan", "Male", true, false, "Kiaan Gupta", "9876543315", "Christian", 105, "1st", "S105", "Gupta", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1896) },
                    { 106, "1061 Test Street, Kolkata", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Kolkata", "A", 10, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1902), new DateTime(2017, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malhotra Khan", "Kavya", "Female", false, true, "Avni Agarwal", "9876543316", "Sikh", 106, "1st", "S106", "Agarwal", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1902) },
                    { 107, "1071 Test Street, Hyderabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Hyderabad", "A", 10, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1910), new DateTime(2017, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kapoor Mishra", "Karan", "Male", false, true, "Aryan Verma", "9876543317", "Jain", 107, "1st", "S107", "Verma", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1910) },
                    { 108, "1081 Test Street, Ahmedabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Ahmedabad", "A", 10, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1917), new DateTime(2017, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mittal Chopra", "Myra", "Female", false, false, "Pari Jain", "9876543318", "Buddhist", 108, "1st", "S108", "Jain", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1917) },
                    { 109, "1091 Test Street, Jaipur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Jaipur", "A", 10, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1923), new DateTime(2017, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joshi Bansal", "Riya", "Male", false, true, "Sai Shah", "9876543319", "Hindu", 109, "1st", "S109", "Shah", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1923) },
                    { 110, "1101 Test Street, Lucknow", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Lucknow", "A", 10, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1929), new DateTime(2017, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saxena Agrawal", "Vihaan", "Female", true, true, "Atharv Yadav", "9876543320", "Muslim", 110, "1st", "S110", "Yadav", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1930) },
                    { 111, "1111 Test Street, Kanpur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Kanpur", "A", 10, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1936), new DateTime(2017, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Srivastava Malhotra", "Saanvi", "Male", false, false, "Ira Reddy", "9876543321", "Christian", 111, "1st", "S111", "Reddy", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1936) },
                    { 112, "1121 Test Street, Nagpur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Nagpur", "A", 10, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1942), new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pandey Kapoor", "Reyansh", "Female", false, true, "Ayaan Khan", "9876543322", "Sikh", 112, "1st", "S112", "Khan", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1942) },
                    { 113, "1131 Test Street, Indore", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Indore", "A", 10, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1948), new DateTime(2017, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiwari Mittal", "Anvi", "Male", false, true, "Navya Mishra", "9876543323", "Jain", 113, "1st", "S113", "Mishra", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1949) },
                    { 114, "1141 Test Street, Bhopal", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Bhopal", "A", 10, new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1967), new DateTime(2017, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dubey Joshi", "Vivaan", "Female", false, false, "Rudra Chopra", "9876543324", "Buddhist", 114, "1st", "S114", "Chopra", new DateTime(2025, 9, 24, 17, 13, 45, 637, DateTimeKind.Utc).AddTicks(1967) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYears_IsCurrent",
                table: "AcademicYears",
                column: "IsCurrent");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYears_Year",
                table: "AcademicYears",
                column: "Year",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicYears");

            migrationBuilder.DeleteData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7493), "Grade 10", new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7493) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7503), "Grade 10", new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7503) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7505), "Grade 9", new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7505) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7506), "Grade 9", new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7507) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7508), "Grade 8", new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7508) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Amount", "BillMonth", "CreatedAt", "DueDate", "Notes", "PaidDate", "Units", "UnitsRate", "UpdatedAt" },
                values: new object[] { 8500m, 8, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7767), new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "August 2024 electricity bill", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 180m, 4.5m, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7768) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Amount", "BillMonth", "CreatedAt", "DueDate", "IsPaid", "Notes", "PaidDate", "PaymentMethod", "TransactionId", "Units", "UnitsRate", "UpdatedAt" },
                values: new object[] { 9200m, 9, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7772), new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "September 2024 electricity bill", null, null, null, 195m, 4.6m, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7773) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Amount", "BankName", "BillMonth", "ChequeNumber", "CreatedAt", "DueDate", "Notes", "PaidDate", "PaymentMethod", "TransactionId", "Units", "UnitsRate", "UpdatedAt" },
                values: new object[] { 7800m, null, 7, null, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7777), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "July 2024 electricity bill", new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TXN789123", 165m, 4.4m, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7777) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7616), "Annual Tuition Fees", new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7616) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Amount", "ClassId", "CreatedAt", "Description", "FeeType", "UpdatedAt" },
                values: new object[] { 5000m, 1, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7620), "One-time Admission Fees", 1, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7621) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Amount", "ClassId", "CreatedAt", "Description", "FeeType", "UpdatedAt" },
                values: new object[] { 2000m, 1, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7622), "Examination Fees", 2, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7623) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Amount", "ClassId", "CreatedAt", "Description", "FeeType", "UpdatedAt" },
                values: new object[] { 12000m, 1, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7624), "Annual Transport Fees", 3, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7624) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Amount", "ClassId", "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { 60000m, 2, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7625), "Annual Tuition Fees", new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7626) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Amount", "ClassId", "CreatedAt", "Description", "FeeType", "UpdatedAt" },
                values: new object[] { 5000m, 2, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7627), "One-time Admission Fees", 1, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7627) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Amount", "ClassId", "CreatedAt", "Description", "FeeType", "UpdatedAt" },
                values: new object[] { 2000m, 2, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7629), "Examination Fees", 2, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7629) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Amount", "ClassId", "CreatedAt", "Description", "FeeType", "UpdatedAt" },
                values: new object[] { 12000m, 2, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7630), "Annual Transport Fees", 3, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7631) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7819), new DateTime(2025, 9, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7819) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7824), new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7824) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7829), "Repair of desks and chairs in Grade 10 classroom", new DateTime(2025, 9, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7829) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "CreatedAt", "UpdatedAt" },
                values: new object[] { "101 Transport Ave, City", new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7583), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7583) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "CreatedAt", "UpdatedAt" },
                values: new object[] { "202 Clean St, City", new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7591), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7591) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "CreatedAt", "UpdatedAt" },
                values: new object[] { "303 Office Lane, City", new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7595), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7595) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "AdmissionDate", "CreatedAt", "DateOfBirth", "FatherName", "FirstName", "Gender", "MotherName", "ParentMobileNumber", "Religion", "Surname", "UpdatedAt" },
                values: new object[] { "123 Main St, City", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7538), new DateTime(2008, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Brown", "Alice", "Female", "Mary Brown", "9876543210", "Christian", "Brown", new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7538) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "AdmissionDate", "CityVillage", "CreatedAt", "DateOfBirth", "FatherName", "FirstName", "Gender", "IsBPL", "IsSemiEnglish", "MotherName", "ParentMobileNumber", "Religion", "Surname", "UpdatedAt" },
                values: new object[] { "456 Oak Ave, City", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pune", new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7551), new DateTime(2008, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "David Wilson", "Bob", "Male", true, false, "Susan Wilson", "9876543211", "Hindu", "Wilson", new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7551) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "AdmissionDate", "CityVillage", "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "FatherName", "FirstName", "IsBPL", "IsSemiEnglish", "MotherName", "ParentMobileNumber", "Religion", "Surname", "UpdatedAt" },
                values: new object[] { "789 Pine Rd, City", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nashik", "B", 2, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7556), new DateTime(2008, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael Davis", "Charlie", true, true, "Jennifer Davis", "9876543212", "Hindu", "Davis", new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7556) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "CreatedAt", "UpdatedAt" },
                values: new object[] { "123 Teachers Colony, Mumbai, Maharashtra", new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7324), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7325) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "CreatedAt", "UpdatedAt" },
                values: new object[] { "456 Gandhi Nagar, Pune, Maharashtra", new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7330), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7331) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "CreatedAt", "UpdatedAt" },
                values: new object[] { "789 Shivaji Park, Nashik, Maharashtra", new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7334), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7335) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "CreatedAt", "UpdatedAt" },
                values: new object[] { "101 Nehru Colony, Nagpur, Maharashtra", new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7338), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7339) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "BankAccountNumber", "CreatedAt", "Email", "PANNumber", "UpdatedAt" },
                values: new object[] { "202 Laxmi Nagar, Aurangabad, Maharashtra", null, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7342), null, null, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7343) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7719), new DateTime(2025, 9, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7720) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Amount", "Category", "CreatedAt", "Description", "DriverName", "ExpenseDate", "FuelType", "InvoiceNumber", "Quantity", "UpdatedAt", "VehicleId" },
                values: new object[] { 2500m, 2, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7725), "Engine oil change", "Rajesh Kumar", new DateTime(2025, 9, 9, 0, 0, 0, 0, DateTimeKind.Local), null, "M001", 1m, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7725), 1 });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Amount", "Category", "CreatedAt", "Description", "DriverName", "ExpenseDate", "FuelType", "InvoiceNumber", "Quantity", "UpdatedAt", "VehicleId" },
                values: new object[] { 1200m, 1, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7730), "CNG refill for auto", "Suresh Patil", new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Local), 3, "F002", 20m, new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7730), 2 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7662), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7662) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7666), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7666) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7668), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7669) });
        }
    }
}
