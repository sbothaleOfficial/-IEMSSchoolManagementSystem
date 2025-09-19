using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IEMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddExpenseManagementEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElectricityBills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BillNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    BillMonth = table.Column<int>(type: "INTEGER", nullable: false),
                    BillYear = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Units = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitsRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "INTEGER", nullable: true),
                    TransactionId = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    BankName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ChequeNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    IsPaid = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityBills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    ExpenseType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpenseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PaymentMethod = table.Column<int>(type: "INTEGER", nullable: false),
                    TransactionId = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    BankName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ChequeNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    InvoiceNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    VendorName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherExpenses", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1957), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1958) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1963), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1963) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1965), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1965) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1966), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1967) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1968), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1968) });

            migrationBuilder.InsertData(
                table: "ElectricityBills",
                columns: new[] { "Id", "Amount", "BankName", "BillMonth", "BillNumber", "BillYear", "ChequeNumber", "CreatedAt", "DueDate", "IsPaid", "Notes", "PaidDate", "PaymentMethod", "TransactionId", "Units", "UnitsRate", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 8500m, null, 8, "EB001", 2024, null, new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2239), new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "August 2024 electricity bill", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 180m, 4.5m, new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2239) },
                    { 2, 9200m, null, 9, "EB002", 2024, null, new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2244), new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "September 2024 electricity bill", null, null, null, 195m, 4.6m, new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2244) },
                    { 3, 7800m, null, 7, "EB003", 2024, null, new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2248), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "July 2024 electricity bill", new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TXN789123", 165m, 4.4m, new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2248) }
                });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2083), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2083) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2086), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2087) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2089), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2089) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2090), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2091) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2092), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2092) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2094), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2094) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2096), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2096) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2098), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2098) });

            migrationBuilder.InsertData(
                table: "OtherExpenses",
                columns: new[] { "Id", "Amount", "BankName", "Category", "ChequeNumber", "CreatedAt", "Description", "ExpenseDate", "ExpenseType", "InvoiceNumber", "Notes", "PaymentMethod", "TransactionId", "UpdatedAt", "VendorName" },
                values: new object[,]
                {
                    { 1, 2500m, null, 0, null, new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2277), "Books, pens, papers for office use", new DateTime(2025, 9, 4, 0, 0, 0, 0, DateTimeKind.Local), "Office Supplies", "INV001", null, 0, null, new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2278), "Shree Stationery Mart" },
                    { 2, 15000m, null, 1, null, new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2283), "Decorations, refreshments, and prizes for Independence Day", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), "Independence Day Celebration", "INV002", null, 1, "TXN456789", new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2283), "Event Decorators" },
                    { 3, 5500m, "SBI Bank", 2, "123456", new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2287), "Repair of desks and chairs in Grade 10 classroom", new DateTime(2025, 9, 11, 0, 0, 0, 0, DateTimeKind.Local), "Classroom Repair", "INV003", null, 2, null, new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2287), "Repair Services" }
                });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2039), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2039) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2049), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2049) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2052), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2053) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1995), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1995) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2004), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2004) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2009), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2009) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1781), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1782) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1787), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1787) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1791), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1792) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1795), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1796) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1799), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(1800) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2191), new DateTime(2025, 9, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2192) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2197), new DateTime(2025, 9, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2198) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2201), new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2202) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2130), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2131) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2134), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2134) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2136), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2137) });

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityBills_BillMonth_BillYear",
                table: "ElectricityBills",
                columns: new[] { "BillMonth", "BillYear" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityBills_BillNumber",
                table: "ElectricityBills",
                column: "BillNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricityBills");

            migrationBuilder.DropTable(
                name: "OtherExpenses");

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5143), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5143) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5148), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5148) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5150), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5150) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5152), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5152) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5153), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5154) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5259), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5260) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5264), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5265) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5266), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5267) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5268), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5269) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5270), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5270) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5272), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5272) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5273), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5274) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5275), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5275) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5225), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5225) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5230), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5230) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5233), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5233) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5182), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5183) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5199), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5199) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(4979), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(4987), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(4988) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(4991), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(4992) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(4995), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(4996) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5000), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5000) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5366), new DateTime(2025, 9, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5366) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5374), new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5375) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5379), new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5379) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5311), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5311) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5314), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5314) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5317), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5317) });
        }
    }
}
