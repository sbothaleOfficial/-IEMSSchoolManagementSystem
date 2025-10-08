using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IEMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSchoolContactSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9873), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9874) });

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9876), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9877) });

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9879), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9879) });

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9881), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9882) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7005), "Nursery", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7006) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "Section", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7011), "KG1", "A", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7011) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7012), "KG2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7013) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "Section", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7014), "Class 1", "A", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7014) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7015), "Class 2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7016) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Name", "Section", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7017), "Class 3", "A", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7017) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7018), "Class 4", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7019) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7020), "Class 5", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7020) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7022), "Class 6", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7022) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7023), "Class 7", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7023) });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "CreatedAt", "Name", "Section", "TeacherId", "UpdatedAt" },
                values: new object[,]
                {
                    { 11, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7025), "Class 8", "A", 1, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7026) },
                    { 12, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7027), "Class 9", "A", 2, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7027) },
                    { 13, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7029), "Class 10", "A", 3, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7029) }
                });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9640), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9641) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9646), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9647) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9651), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9651) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9655), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9655) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9659), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9659) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9662), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9663) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9666), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9667) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9671), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9671) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9674), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9674) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9677), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9678) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9794), new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9795) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9800), new DateTime(2025, 9, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9801) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9807), new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9807) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9811), new DateTime(2025, 9, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9812) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9816), new DateTime(2025, 9, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9816) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9821), new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9821) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9825), new DateTime(2025, 9, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9826) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9831), new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9831) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9836), new DateTime(2025, 9, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9836) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9840), new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9841) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9372), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9372) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9376), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9377) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9379), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9379) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9380), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9380) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9382), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9383) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9384), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9384) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9385), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9386) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9387), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9387) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9388), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9389) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9390), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9390) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9392), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9392) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9393), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9393) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9395), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9395) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9396), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9397) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9398), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9398) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9399), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9400) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9401), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9401) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9403), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9403) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9404), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9404) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9406), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9406) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9407), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9408) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9417), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9417) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9418), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9418) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9420), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9420) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9421), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9421) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9423), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9423) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9712), new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9712) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9716), new DateTime(2025, 9, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9717) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9721), new DateTime(2025, 9, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9721) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9724), new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9725) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9728), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9728) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9732), new DateTime(2025, 9, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9732) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9742), new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9742) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9745), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9745) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9748), new DateTime(2025, 9, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9749) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9752), new DateTime(2025, 8, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9753) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9301), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9301) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9310), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9311) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9314), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9314) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9317), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9317) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9320), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9320) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9323), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9323) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9327), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9327) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9330), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9330) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9333), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9333) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9335), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9336) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7059), new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursery", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7059) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7124), new DateTime(2021, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursery", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7124) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7133), new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursery", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7133) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7140), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursery", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7140) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7147), new DateTime(2021, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursery", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7148) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7155), new DateTime(2021, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursery", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7155) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7162), new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursery", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7162) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7178), new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursery", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7178) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7184), new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursery", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7184) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7196), new DateTime(2021, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursery", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7196) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7203), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursery", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7203) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7210), new DateTime(2021, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursery", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7216), new DateTime(2021, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursery", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7217) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7223), new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursery", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7223) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7229), new DateTime(2021, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursery", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7230) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 1, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7236), new DateTime(2021, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursery", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7236) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 1, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7243), new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursery", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7243) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 1, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7250), new DateTime(2021, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursery", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7250) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 1, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7257), new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursery", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7257) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 1, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7263), new DateTime(2021, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursery", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7263) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ClassDivision", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7270), new DateTime(2020, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG1", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7271) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ClassDivision", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7279), new DateTime(2020, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG1", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7279) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ClassDivision", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7293), new DateTime(2020, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG1", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7293) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ClassDivision", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7300), new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG1", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7300) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ClassDivision", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7307), new DateTime(2020, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG1", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7307) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ClassDivision", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7313), new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG1", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7314) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ClassDivision", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7320), new DateTime(2020, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG1", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7320) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ClassDivision", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7327), new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG1", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7327) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ClassDivision", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7333), new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG1", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7333) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ClassDivision", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7340), new DateTime(2020, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG1", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7340) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7347), new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG1", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7347) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7353), new DateTime(2020, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG1", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7353) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7360), new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG1", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7360) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7367), new DateTime(2020, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG1", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7368) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7374), new DateTime(2020, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG1", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7374) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7381), new DateTime(2020, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG1", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7381) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7395), new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG1", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7395) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7402), new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG1", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7402) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7408), new DateTime(2020, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG1", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7408) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7415), new DateTime(2020, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG1", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7415) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7422), new DateTime(2019, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7422) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7431), new DateTime(2019, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7431) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 3, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7438), new DateTime(2019, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7438) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 3, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7444), new DateTime(2019, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7445) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 3, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7451), new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7451) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 3, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7458), new DateTime(2019, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7458) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 3, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7465), new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7465) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 3, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7472), new DateTime(2019, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7472) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 3, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7479), new DateTime(2019, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7479) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 3, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7485), new DateTime(2019, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7486) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 3, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7493), new DateTime(2019, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7493) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 3, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7499), new DateTime(2019, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7500) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 3, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7513), new DateTime(2019, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7513) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 3, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7520), new DateTime(2019, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7520) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7527), new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7527) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7534), new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7534) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7541), new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7541) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7547), new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7548) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7554), new DateTime(2019, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7554) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7561), new DateTime(2019, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG2", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7561) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 4, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7568), new DateTime(2018, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7569) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 4, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7577), new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7577) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 4, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7584), new DateTime(2018, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7584) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 4, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7591), new DateTime(2018, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7591) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 4, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7598), new DateTime(2018, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7598) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 4, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7605), new DateTime(2018, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7606) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 4, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7620), new DateTime(2018, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7620) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 4, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7627), new DateTime(2018, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7627) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 4, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7634), new DateTime(2018, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7634) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 4, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7641), new DateTime(2018, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7641) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 4, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7647), new DateTime(2018, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7648) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 4, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7655), new DateTime(2018, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7655) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 4, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7662), new DateTime(2018, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7662) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "A", 4, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7669), new DateTime(2018, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7669) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 4, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7676), new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7676) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 4, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7683), new DateTime(2018, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7683) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 4, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7689), new DateTime(2018, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7690) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 4, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7696), new DateTime(2018, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7697) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 4, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7703), new DateTime(2018, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7703) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 4, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7710), new DateTime(2018, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7710) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7717), new DateTime(2017, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "2nd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7717) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7732), new DateTime(2017, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "2nd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7732) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7740), new DateTime(2017, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "2nd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7740) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7746), new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2nd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7747) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7753), new DateTime(2017, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "2nd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7753) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7760), new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "2nd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7760) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7767), new DateTime(2017, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "2nd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7767) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7773), new DateTime(2017, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "2nd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7774) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7780), new DateTime(2017, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "2nd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7780) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7787), new DateTime(2017, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "2nd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7787) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7793), new DateTime(2017, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "2nd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7794) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7800), new DateTime(2017, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "2nd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7800) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7807), new DateTime(2017, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "2nd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7807) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7814), new DateTime(2017, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "2nd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7814) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7821), new DateTime(2017, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "2nd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7821) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7827), new DateTime(2017, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "2nd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7828) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7834), new DateTime(2017, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "2nd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7834) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7848), new DateTime(2017, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "2nd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7848) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7855), new DateTime(2017, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "2nd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7855) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7861), new DateTime(2017, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "2nd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7862) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 6, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7870), new DateTime(2016, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "3rd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7870) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 6, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7879), new DateTime(2016, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "3rd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7879) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 6, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7886), new DateTime(2016, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "3rd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7887) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 6, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7893), new DateTime(2016, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "3rd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7894) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 6, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7900), new DateTime(2016, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "3rd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7901) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 6, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7907), new DateTime(2016, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "3rd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7907) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 6, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7914), new DateTime(2016, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "3rd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7914) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 6, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7921), new DateTime(2016, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "3rd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7921) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 6, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7928), new DateTime(2016, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "3rd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7928) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 6, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7935), new DateTime(2016, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "3rd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7935) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 6, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7942), new DateTime(2016, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "3rd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7942) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 6, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7949), new DateTime(2016, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3rd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7949) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 6, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7956), new DateTime(2016, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "3rd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7956) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 6, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7969), new DateTime(2016, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "3rd", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7970) });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AadhaarNumber", "Address", "AdmissionDate", "CasteCategory", "CityVillage", "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "FatherName", "FirstName", "Gender", "IsBPL", "IsSemiEnglish", "MotherName", "ParentMobileNumber", "Religion", "SerialNo", "Standard", "StudentNumber", "Surname", "UpdatedAt" },
                values: new object[,]
                {
                    { 115, "111551159115", "1151 Test Street, Patna", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Patna", "A", 6, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7976), new DateTime(2016, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sharma Saxena", "Aadya", "Male", true, true, "Anaya Bansal", "9876543325", "Hindu", 115, "3rd", "S115", "Bansal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7977) },
                    { 116, "111651169116", "1161 Test Street, Vadodara", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Vadodara", "A", 6, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7983), new DateTime(2016, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patel Srivastava", "Aayan", "Female", false, true, "Om Agrawal", "9876543326", "Muslim", 116, "3rd", "S116", "Agrawal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7984) },
                    { 117, "111751179117", "1171 Test Street, Ludhiana", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Ludhiana", "A", 6, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7990), new DateTime(2016, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singh Pandey", "Pihu", "Male", false, false, "Tara Malhotra", "9876543327", "Christian", 117, "3rd", "S117", "Malhotra", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7991) },
                    { 118, "111851189118", "1181 Test Street, Agra", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Agra", "A", 6, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7997), new DateTime(2016, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kumar Tiwari", "Krishna", "Female", false, true, "Shaurya Kapoor", "9876543328", "Sikh", 118, "3rd", "S118", "Kapoor", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(7998) },
                    { 119, "111951199119", "1191 Test Street, Nashik", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Nashik", "A", 6, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8005), new DateTime(2016, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gupta Dubey", "Advik", "Male", false, true, "Kashvi Mittal", "9876543329", "Jain", 119, "3rd", "S119", "Mittal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8005) },
                    { 120, "112051209120", "1201 Test Street, Faridabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Faridabad", "A", 6, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8011), new DateTime(2016, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agarwal Sharma", "Samaira", "Female", true, false, "Mihir Joshi", "9876543330", "Buddhist", 120, "3rd", "S120", "Joshi", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8012) },
                    { 121, "112151219121", "1211 Test Street, Meerut", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Meerut", "A", 7, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8019), new DateTime(2015, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Verma Patel", "Kiaan", "Male", false, true, "Prisha Saxena", "9876543331", "Hindu", 121, "4th", "S121", "Saxena", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8019) },
                    { 122, "112251229122", "1221 Test Street, Rajkot", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Rajkot", "A", 7, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8027), new DateTime(2015, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jain Singh", "Avni", "Female", false, true, "Aadhya Srivastava", "9876543332", "Muslim", 122, "4th", "S122", "Srivastava", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8027) },
                    { 123, "112351239123", "1231 Test Street, Kalyan", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Kalyan", "A", 7, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8034), new DateTime(2015, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shah Kumar", "Aryan", "Male", false, false, "Dev Pandey", "9876543333", "Christian", 123, "4th", "S123", "Pandey", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8035) },
                    { 124, "112451249124", "1241 Test Street, Vasai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Vasai", "A", 7, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8041), new DateTime(2015, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yadav Gupta", "Pari", "Female", false, true, "Krisha Tiwari", "9876543334", "Sikh", 124, "4th", "S124", "Tiwari", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8042) },
                    { 125, "112551259125", "1251 Test Street, Varanasi", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Varanasi", "A", 7, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8048), new DateTime(2015, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reddy Agarwal", "Sai", "Male", true, true, "Arnav Dubey", "9876543335", "Jain", 125, "4th", "S125", "Dubey", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8049) },
                    { 126, "112651269126", "1261 Test Street, Mumbai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Mumbai", "A", 7, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8056), new DateTime(2015, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khan Verma", "Atharv", "Female", false, false, "Janvi Sharma", "9876543336", "Buddhist", 126, "4th", "S126", "Sharma", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8056) },
                    { 127, "112751279127", "1271 Test Street, Delhi", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Delhi", "A", 7, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8062), new DateTime(2015, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mishra Jain", "Ira", "Male", false, true, "Yug Patel", "9876543337", "Hindu", 127, "4th", "S127", "Patel", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8063) },
                    { 128, "112851289128", "1281 Test Street, Pune", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Pune", "A", 7, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8069), new DateTime(2015, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chopra Shah", "Ayaan", "Female", false, true, "Shanaya Singh", "9876543338", "Muslim", 128, "4th", "S128", "Singh", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8070) },
                    { 129, "112951299129", "1291 Test Street, Bangalore", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Bangalore", "A", 7, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8083), new DateTime(2015, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bansal Yadav", "Navya", "Male", false, false, "Arjun Kumar", "9876543339", "Christian", 129, "4th", "S129", "Kumar", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8084) },
                    { 130, "113051309130", "1301 Test Street, Chennai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Chennai", "A", 7, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8093), new DateTime(2015, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agrawal Reddy", "Rudra", "Female", true, true, "Anika Gupta", "9876543340", "Sikh", 130, "4th", "S130", "Gupta", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8093) },
                    { 131, "113151319131", "1311 Test Street, Kolkata", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Kolkata", "A", 7, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8100), new DateTime(2015, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malhotra Khan", "Anaya", "Male", false, true, "Vedant Agarwal", "9876543341", "Jain", 131, "4th", "S131", "Agarwal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8100) },
                    { 132, "113251329132", "1321 Test Street, Hyderabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Hyderabad", "A", 7, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8107), new DateTime(2015, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kapoor Mishra", "Om", "Female", false, false, "Reet Verma", "9876543342", "Buddhist", 132, "4th", "S132", "Verma", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8107) },
                    { 133, "113351339133", "1331 Test Street, Ahmedabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Ahmedabad", "A", 7, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8113), new DateTime(2015, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mittal Chopra", "Tara", "Male", false, true, "Aarush Jain", "9876543343", "Hindu", 133, "4th", "S133", "Jain", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8114) },
                    { 134, "113451349134", "1341 Test Street, Jaipur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Jaipur", "A", 7, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8120), new DateTime(2015, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joshi Bansal", "Shaurya", "Female", false, true, "Khushi Shah", "9876543344", "Muslim", 134, "4th", "S134", "Shah", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8121) },
                    { 135, "113551359135", "1351 Test Street, Lucknow", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Lucknow", "A", 7, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8127), new DateTime(2015, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saxena Agrawal", "Kashvi", "Male", true, false, "Aarav Yadav", "9876543345", "Christian", 135, "4th", "S135", "Yadav", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8128) },
                    { 136, "113651369136", "1361 Test Street, Kanpur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Kanpur", "A", 7, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8134), new DateTime(2015, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Srivastava Malhotra", "Mihir", "Female", false, true, "Ananya Reddy", "9876543346", "Sikh", 136, "4th", "S136", "Reddy", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8135) },
                    { 137, "113751379137", "1371 Test Street, Nagpur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Nagpur", "A", 7, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8141), new DateTime(2015, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pandey Kapoor", "Prisha", "Male", false, true, "Arjun Khan", "9876543347", "Jain", 137, "4th", "S137", "Khan", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8142) },
                    { 138, "113851389138", "1381 Test Street, Indore", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Indore", "A", 7, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8148), new DateTime(2015, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiwari Mittal", "Aadhya", "Female", false, false, "Diya Mishra", "9876543348", "Buddhist", 138, "4th", "S138", "Mishra", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8148) },
                    { 139, "113951399139", "1391 Test Street, Bhopal", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Bhopal", "A", 7, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8155), new DateTime(2015, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dubey Joshi", "Dev", "Male", false, true, "Ishaan Chopra", "9876543349", "Hindu", 139, "4th", "S139", "Chopra", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8155) },
                    { 140, "114051409140", "1401 Test Street, Patna", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Patna", "A", 7, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8162), new DateTime(2015, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sharma Saxena", "Krisha", "Female", true, true, "Kavya Bansal", "9876543350", "Muslim", 140, "4th", "S140", "Bansal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8162) },
                    { 141, "114151419141", "1411 Test Street, Vadodara", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Vadodara", "A", 8, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8175), new DateTime(2014, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patel Srivastava", "Arnav", "Male", false, false, "Karan Agrawal", "9876543351", "Christian", 141, "5th", "S141", "Agrawal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8175) },
                    { 142, "114251429142", "1421 Test Street, Ludhiana", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Ludhiana", "A", 8, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8184), new DateTime(2014, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singh Pandey", "Janvi", "Female", false, true, "Myra Malhotra", "9876543352", "Sikh", 142, "5th", "S142", "Malhotra", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8184) },
                    { 143, "114351439143", "1431 Test Street, Agra", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Agra", "A", 8, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8191), new DateTime(2014, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kumar Tiwari", "Yug", "Male", false, true, "Riya Kapoor", "9876543353", "Jain", 143, "5th", "S143", "Kapoor", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8191) },
                    { 144, "114451449144", "1441 Test Street, Nashik", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Nashik", "A", 8, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8198), new DateTime(2014, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gupta Dubey", "Shanaya", "Female", false, false, "Vihaan Mittal", "9876543354", "Buddhist", 144, "5th", "S144", "Mittal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8198) },
                    { 145, "114551459145", "1451 Test Street, Faridabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Faridabad", "A", 8, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8205), new DateTime(2014, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agarwal Sharma", "Arjun", "Male", true, true, "Saanvi Joshi", "9876543355", "Hindu", 145, "5th", "S145", "Joshi", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8205) },
                    { 146, "114651469146", "1461 Test Street, Meerut", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Meerut", "A", 8, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8212), new DateTime(2014, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Verma Patel", "Anika", "Female", false, true, "Reyansh Saxena", "9876543356", "Muslim", 146, "5th", "S146", "Saxena", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8213) },
                    { 147, "114751479147", "1471 Test Street, Rajkot", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Rajkot", "A", 8, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8220), new DateTime(2014, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jain Singh", "Vedant", "Male", false, false, "Anvi Srivastava", "9876543357", "Christian", 147, "5th", "S147", "Srivastava", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8220) },
                    { 148, "114851489148", "1481 Test Street, Kalyan", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Kalyan", "A", 8, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8227), new DateTime(2014, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shah Kumar", "Reet", "Female", false, true, "Vivaan Pandey", "9876543358", "Sikh", 148, "5th", "S148", "Pandey", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8227) },
                    { 149, "114951499149", "1491 Test Street, Vasai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Vasai", "A", 8, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8234), new DateTime(2014, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yadav Gupta", "Aarush", "Male", false, true, "Aadya Tiwari", "9876543359", "Jain", 149, "5th", "S149", "Tiwari", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8234) },
                    { 150, "115051509150", "1501 Test Street, Varanasi", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Varanasi", "A", 8, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8241), new DateTime(2014, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reddy Agarwal", "Khushi", "Female", true, false, "Aayan Dubey", "9876543360", "Buddhist", 150, "5th", "S150", "Dubey", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8241) },
                    { 151, "115151519151", "1511 Test Street, Mumbai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Mumbai", "A", 8, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8248), new DateTime(2014, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khan Verma", "Aarav", "Male", false, true, "Pihu Sharma", "9876543361", "Hindu", 151, "5th", "S151", "Sharma", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8248) },
                    { 152, "115251529152", "1521 Test Street, Delhi", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Delhi", "A", 8, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8255), new DateTime(2014, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mishra Jain", "Ananya", "Female", false, true, "Krishna Patel", "9876543362", "Muslim", 152, "5th", "S152", "Patel", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8255) },
                    { 153, "115351539153", "1531 Test Street, Pune", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Pune", "A", 8, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8262), new DateTime(2014, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chopra Shah", "Arjun", "Male", false, false, "Advik Singh", "9876543363", "Christian", 153, "5th", "S153", "Singh", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8262) },
                    { 154, "115451549154", "1541 Test Street, Bangalore", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Bangalore", "A", 8, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8269), new DateTime(2014, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bansal Yadav", "Diya", "Female", false, true, "Samaira Kumar", "9876543364", "Sikh", 154, "5th", "S154", "Kumar", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8269) },
                    { 155, "115551559155", "1551 Test Street, Chennai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Chennai", "A", 8, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8276), new DateTime(2014, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agrawal Reddy", "Ishaan", "Male", true, true, "Kiaan Gupta", "9876543365", "Jain", 155, "5th", "S155", "Gupta", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8276) },
                    { 156, "115651569156", "1561 Test Street, Kolkata", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Kolkata", "A", 8, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8283), new DateTime(2014, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malhotra Khan", "Kavya", "Female", false, false, "Avni Agarwal", "9876543366", "Buddhist", 156, "5th", "S156", "Agarwal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8283) },
                    { 157, "115751579157", "1571 Test Street, Hyderabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Hyderabad", "A", 8, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8297), new DateTime(2014, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kapoor Mishra", "Karan", "Male", false, true, "Aryan Verma", "9876543367", "Hindu", 157, "5th", "S157", "Verma", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8297) },
                    { 158, "115851589158", "1581 Test Street, Ahmedabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Ahmedabad", "A", 8, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8305), new DateTime(2014, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mittal Chopra", "Myra", "Female", false, true, "Pari Jain", "9876543368", "Muslim", 158, "5th", "S158", "Jain", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8305) },
                    { 159, "115951599159", "1591 Test Street, Jaipur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Jaipur", "A", 8, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8312), new DateTime(2014, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joshi Bansal", "Riya", "Male", false, false, "Sai Shah", "9876543369", "Christian", 159, "5th", "S159", "Shah", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8312) },
                    { 160, "116051609160", "1601 Test Street, Lucknow", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Lucknow", "A", 8, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8320), new DateTime(2014, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saxena Agrawal", "Vihaan", "Female", true, true, "Atharv Yadav", "9876543370", "Sikh", 160, "5th", "S160", "Yadav", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8320) },
                    { 161, "116151619161", "1611 Test Street, Kanpur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Kanpur", "A", 9, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8327), new DateTime(2013, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Srivastava Malhotra", "Saanvi", "Male", false, true, "Ira Reddy", "9876543371", "Jain", 161, "6th", "S161", "Reddy", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8327) },
                    { 162, "116251629162", "1621 Test Street, Nagpur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Nagpur", "A", 9, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8336), new DateTime(2013, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pandey Kapoor", "Reyansh", "Female", false, false, "Ayaan Khan", "9876543372", "Buddhist", 162, "6th", "S162", "Khan", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8336) },
                    { 163, "116351639163", "1631 Test Street, Indore", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Indore", "A", 9, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8344), new DateTime(2013, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiwari Mittal", "Anvi", "Male", false, true, "Navya Mishra", "9876543373", "Hindu", 163, "6th", "S163", "Mishra", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8344) },
                    { 164, "116451649164", "1641 Test Street, Bhopal", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Bhopal", "A", 9, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8351), new DateTime(2013, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dubey Joshi", "Vivaan", "Female", false, true, "Rudra Chopra", "9876543374", "Muslim", 164, "6th", "S164", "Chopra", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8351) },
                    { 165, "116551659165", "1651 Test Street, Patna", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Patna", "A", 9, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8358), new DateTime(2013, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sharma Saxena", "Aadya", "Male", true, false, "Anaya Bansal", "9876543375", "Christian", 165, "6th", "S165", "Bansal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8359) },
                    { 166, "116651669166", "1661 Test Street, Vadodara", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Vadodara", "A", 9, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8366), new DateTime(2013, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patel Srivastava", "Aayan", "Female", false, true, "Om Agrawal", "9876543376", "Sikh", 166, "6th", "S166", "Agrawal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8366) },
                    { 167, "116751679167", "1671 Test Street, Ludhiana", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Ludhiana", "A", 9, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8373), new DateTime(2013, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singh Pandey", "Pihu", "Male", false, true, "Tara Malhotra", "9876543377", "Jain", 167, "6th", "S167", "Malhotra", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8374) },
                    { 168, "116851689168", "1681 Test Street, Agra", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Agra", "A", 9, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8381), new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kumar Tiwari", "Krishna", "Female", false, false, "Shaurya Kapoor", "9876543378", "Buddhist", 168, "6th", "S168", "Kapoor", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8381) },
                    { 169, "116951699169", "1691 Test Street, Nashik", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Nashik", "A", 9, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8388), new DateTime(2013, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gupta Dubey", "Advik", "Male", false, true, "Kashvi Mittal", "9876543379", "Hindu", 169, "6th", "S169", "Mittal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8388) },
                    { 170, "117051709170", "1701 Test Street, Faridabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Faridabad", "A", 9, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8395), new DateTime(2013, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agarwal Sharma", "Samaira", "Female", true, true, "Mihir Joshi", "9876543380", "Muslim", 170, "6th", "S170", "Joshi", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8395) },
                    { 171, "117151719171", "1711 Test Street, Meerut", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Meerut", "A", 9, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8402), new DateTime(2013, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Verma Patel", "Kiaan", "Male", false, false, "Prisha Saxena", "9876543381", "Christian", 171, "6th", "S171", "Saxena", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8403) },
                    { 172, "117251729172", "1721 Test Street, Rajkot", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Rajkot", "A", 9, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8416), new DateTime(2013, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jain Singh", "Avni", "Female", false, true, "Aadhya Srivastava", "9876543382", "Sikh", 172, "6th", "S172", "Srivastava", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8416) },
                    { 173, "117351739173", "1731 Test Street, Kalyan", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Kalyan", "A", 9, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8423), new DateTime(2013, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shah Kumar", "Aryan", "Male", false, true, "Dev Pandey", "9876543383", "Jain", 173, "6th", "S173", "Pandey", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8423) },
                    { 174, "117451749174", "1741 Test Street, Vasai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Vasai", "A", 9, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8430), new DateTime(2013, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yadav Gupta", "Pari", "Female", false, false, "Krisha Tiwari", "9876543384", "Buddhist", 174, "6th", "S174", "Tiwari", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8431) },
                    { 175, "117551759175", "1751 Test Street, Varanasi", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Varanasi", "A", 9, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8437), new DateTime(2013, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reddy Agarwal", "Sai", "Male", true, true, "Arnav Dubey", "9876543385", "Hindu", 175, "6th", "S175", "Dubey", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8438) },
                    { 176, "117651769176", "1761 Test Street, Mumbai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Mumbai", "A", 9, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8445), new DateTime(2013, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khan Verma", "Atharv", "Female", false, true, "Janvi Sharma", "9876543386", "Muslim", 176, "6th", "S176", "Sharma", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8445) },
                    { 177, "117751779177", "1771 Test Street, Delhi", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Delhi", "A", 9, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8452), new DateTime(2013, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mishra Jain", "Ira", "Male", false, false, "Yug Patel", "9876543387", "Christian", 177, "6th", "S177", "Patel", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8452) },
                    { 178, "117851789178", "1781 Test Street, Pune", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Pune", "A", 9, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8460), new DateTime(2013, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chopra Shah", "Ayaan", "Female", false, true, "Shanaya Singh", "9876543388", "Sikh", 178, "6th", "S178", "Singh", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8460) },
                    { 179, "117951799179", "1791 Test Street, Bangalore", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Bangalore", "A", 9, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8467), new DateTime(2013, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bansal Yadav", "Navya", "Male", false, true, "Arjun Kumar", "9876543389", "Jain", 179, "6th", "S179", "Kumar", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8467) },
                    { 180, "118051809180", "1801 Test Street, Chennai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Chennai", "A", 9, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8474), new DateTime(2013, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agrawal Reddy", "Rudra", "Female", true, false, "Anika Gupta", "9876543390", "Buddhist", 180, "6th", "S180", "Gupta", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8474) },
                    { 181, "118151819181", "1811 Test Street, Kolkata", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Kolkata", "A", 10, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8482), new DateTime(2012, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malhotra Khan", "Anaya", "Male", false, true, "Vedant Agarwal", "9876543391", "Hindu", 181, "7th", "S181", "Agarwal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8482) },
                    { 182, "118251829182", "1821 Test Street, Hyderabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Hyderabad", "A", 10, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8490), new DateTime(2012, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kapoor Mishra", "Om", "Female", false, true, "Reet Verma", "9876543392", "Muslim", 182, "7th", "S182", "Verma", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8490) },
                    { 183, "118351839183", "1831 Test Street, Ahmedabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Ahmedabad", "A", 10, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8498), new DateTime(2012, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mittal Chopra", "Tara", "Male", false, false, "Aarush Jain", "9876543393", "Christian", 183, "7th", "S183", "Jain", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8498) },
                    { 184, "118451849184", "1841 Test Street, Jaipur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Jaipur", "A", 10, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8505), new DateTime(2012, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joshi Bansal", "Shaurya", "Female", false, true, "Khushi Shah", "9876543394", "Sikh", 184, "7th", "S184", "Shah", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8505) },
                    { 185, "118551859185", "1851 Test Street, Lucknow", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Lucknow", "A", 10, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8513), new DateTime(2012, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saxena Agrawal", "Kashvi", "Male", true, true, "Aarav Yadav", "9876543395", "Jain", 185, "7th", "S185", "Yadav", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8513) },
                    { 186, "118651869186", "1861 Test Street, Kanpur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Kanpur", "A", 10, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8520), new DateTime(2012, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Srivastava Malhotra", "Mihir", "Female", false, false, "Ananya Reddy", "9876543396", "Buddhist", 186, "7th", "S186", "Reddy", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8520) },
                    { 187, "118751879187", "1871 Test Street, Nagpur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Nagpur", "A", 10, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8527), new DateTime(2012, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pandey Kapoor", "Prisha", "Male", false, true, "Arjun Khan", "9876543397", "Hindu", 187, "7th", "S187", "Khan", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8528) },
                    { 188, "118851889188", "1881 Test Street, Indore", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Indore", "A", 10, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8542), new DateTime(2012, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiwari Mittal", "Aadhya", "Female", false, true, "Diya Mishra", "9876543398", "Muslim", 188, "7th", "S188", "Mishra", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8542) },
                    { 189, "118951899189", "1891 Test Street, Bhopal", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Bhopal", "A", 10, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8549), new DateTime(2012, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dubey Joshi", "Dev", "Male", false, false, "Ishaan Chopra", "9876543399", "Christian", 189, "7th", "S189", "Chopra", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8549) },
                    { 190, "119051909190", "1901 Test Street, Patna", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Patna", "A", 10, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8556), new DateTime(2012, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sharma Saxena", "Krisha", "Female", true, true, "Kavya Bansal", "9876543400", "Sikh", 190, "7th", "S190", "Bansal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8556) },
                    { 191, "119151919191", "1911 Test Street, Vadodara", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Vadodara", "A", 10, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8563), new DateTime(2012, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patel Srivastava", "Arnav", "Male", false, true, "Karan Agrawal", "9876543401", "Jain", 191, "7th", "S191", "Agrawal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8564) },
                    { 192, "119251929192", "1921 Test Street, Ludhiana", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Ludhiana", "A", 10, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8571), new DateTime(2012, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singh Pandey", "Janvi", "Female", false, false, "Myra Malhotra", "9876543402", "Buddhist", 192, "7th", "S192", "Malhotra", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8571) },
                    { 193, "119351939193", "1931 Test Street, Agra", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Agra", "A", 10, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8578), new DateTime(2012, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kumar Tiwari", "Yug", "Male", false, true, "Riya Kapoor", "9876543403", "Hindu", 193, "7th", "S193", "Kapoor", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8579) },
                    { 194, "119451949194", "1941 Test Street, Nashik", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Nashik", "A", 10, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8586), new DateTime(2012, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gupta Dubey", "Shanaya", "Female", false, true, "Vihaan Mittal", "9876543404", "Muslim", 194, "7th", "S194", "Mittal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8586) },
                    { 195, "119551959195", "1951 Test Street, Faridabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Faridabad", "A", 10, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8594), new DateTime(2012, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agarwal Sharma", "Arjun", "Male", true, false, "Saanvi Joshi", "9876543405", "Christian", 195, "7th", "S195", "Joshi", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8594) },
                    { 196, "119651969196", "1961 Test Street, Meerut", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Meerut", "A", 10, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8601), new DateTime(2012, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Verma Patel", "Anika", "Female", false, true, "Reyansh Saxena", "9876543406", "Sikh", 196, "7th", "S196", "Saxena", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8601) },
                    { 197, "119751979197", "1971 Test Street, Rajkot", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Rajkot", "A", 10, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8609), new DateTime(2012, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jain Singh", "Vedant", "Male", false, true, "Anvi Srivastava", "9876543407", "Jain", 197, "7th", "S197", "Srivastava", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8609) },
                    { 198, "119851989198", "1981 Test Street, Kalyan", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Kalyan", "A", 10, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8616), new DateTime(2012, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shah Kumar", "Reet", "Female", false, false, "Vivaan Pandey", "9876543408", "Buddhist", 198, "7th", "S198", "Pandey", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8616) },
                    { 199, "119951999199", "1991 Test Street, Vasai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Vasai", "A", 10, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8623), new DateTime(2012, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yadav Gupta", "Aarush", "Male", false, true, "Aadya Tiwari", "9876543409", "Hindu", 199, "7th", "S199", "Tiwari", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8623) },
                    { 200, "120052009200", "2001 Test Street, Varanasi", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Varanasi", "A", 10, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8630), new DateTime(2012, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reddy Agarwal", "Khushi", "Female", true, true, "Aayan Dubey", "9876543410", "Muslim", 200, "7th", "S200", "Dubey", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8630) }
                });

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "Academic.CurrentYear",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 14, 47, 691, DateTimeKind.Utc).AddTicks(4354));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "Backup.AutoBackupEnabled",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 14, 47, 691, DateTimeKind.Utc).AddTicks(4358));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "Backup.BackupPath",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 14, 47, 691, DateTimeKind.Utc).AddTicks(4361));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "Backup.RetentionDays",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 14, 47, 691, DateTimeKind.Utc).AddTicks(4359));

            migrationBuilder.InsertData(
                table: "SystemSettings",
                columns: new[] { "Key", "Category", "CreatedAt", "DataType", "DefaultValue", "Description", "IsReadOnly", "ModifiedAt", "Value" },
                values: new object[,]
                {
                    { "School.AccreditationNumber", "School", new DateTime(2025, 10, 6, 9, 14, 47, 691, DateTimeKind.Utc).AddTicks(4370), "String", "115381/2016", "School accreditation number", false, null, "115381/2016" },
                    { "School.AddressLine1", "School", new DateTime(2025, 10, 6, 9, 14, 47, 691, DateTimeKind.Utc).AddTicks(4367), "String", "Tah. Maregaon, Dist. Yavatmal (Maharashtra)", "School address line 1", false, null, "Tah. Maregaon, Dist. Yavatmal (Maharashtra)" },
                    { "School.AlternatePhone", "School", new DateTime(2025, 10, 6, 9, 14, 47, 691, DateTimeKind.Utc).AddTicks(4378), "String", "", "School alternate phone number", false, null, "" },
                    { "School.Board", "School", new DateTime(2025, 10, 6, 9, 14, 47, 691, DateTimeKind.Utc).AddTicks(4373), "String", "State", "Educational board affiliation", false, null, "State" },
                    { "School.Email", "School", new DateTime(2025, 10, 6, 9, 14, 47, 691, DateTimeKind.Utc).AddTicks(4379), "String", "inspire.mardi@gmail.com", "School official email address", false, null, "inspire.mardi@gmail.com" },
                    { "School.ManagementName", "School", new DateTime(2025, 10, 6, 9, 14, 47, 691, DateTimeKind.Utc).AddTicks(4363), "String", "Mahalakmi Bahuddeshiy Sanstha, Chikhalgaon", "Name of school management organization", false, null, "Mahalakmi Bahuddeshiy Sanstha, Chikhalgaon" },
                    { "School.Name", "School", new DateTime(2025, 10, 6, 9, 14, 47, 691, DateTimeKind.Utc).AddTicks(4365), "String", "Inspire English Medium School, Mardi", "Official school name", false, null, "Inspire English Medium School, Mardi" },
                    { "School.Phone", "School", new DateTime(2025, 10, 6, 9, 14, 47, 691, DateTimeKind.Utc).AddTicks(4376), "String", "8483949981", "School primary phone number", false, null, "8483949981" },
                    { "School.PinCode", "School", new DateTime(2025, 10, 6, 9, 14, 47, 691, DateTimeKind.Utc).AddTicks(4368), "String", "445303", "School pin code", false, null, "445303" },
                    { "School.UDISECode", "School", new DateTime(2025, 10, 6, 9, 14, 47, 691, DateTimeKind.Utc).AddTicks(4372), "String", "27140806704", "U-DISE code for school", false, null, "27140806704" },
                    { "School.Website", "School", new DateTime(2025, 10, 6, 9, 14, 47, 691, DateTimeKind.Utc).AddTicks(4382), "String", "", "School website URL", false, null, "" }
                });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(6806), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(6807) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(6812), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(6812) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(6816), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(6817) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(6820), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(6821) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(6824), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(6824) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(6838), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(6839) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(6842), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(6843) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(6846), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(6846) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(6850), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(6854), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(6854) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9552), new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9553) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9558), new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9558) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9562), new DateTime(2025, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9563) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9567), new DateTime(2025, 10, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9568) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9571), new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9572) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9575), new DateTime(2025, 9, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9576) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9580), new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9581) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9585), new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9585) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9589), new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9589) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9593), new DateTime(2025, 9, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9594) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 6, 14, 44, 47, 691, DateTimeKind.Local).AddTicks(4179));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9468), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9469) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9472), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9473) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9475), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9475) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9477), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9478) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9480), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9480) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9482), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9483) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9485), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9485) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9487), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9488) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9490), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9490) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9493), new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9493) });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AadhaarNumber", "Address", "AdmissionDate", "CasteCategory", "CityVillage", "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "FatherName", "FirstName", "Gender", "IsBPL", "IsSemiEnglish", "MotherName", "ParentMobileNumber", "Religion", "SerialNo", "Standard", "StudentNumber", "Surname", "UpdatedAt" },
                values: new object[,]
                {
                    { 201, "120152019201", "2011 Test Street, Mumbai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Mumbai", "A", 11, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8638), new DateTime(2011, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khan Verma", "Aarav", "Male", false, false, "Pihu Sharma", "9876543411", "Christian", 201, "8th", "S201", "Sharma", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8638) },
                    { 202, "120252029202", "2021 Test Street, Delhi", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Delhi", "A", 11, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8646), new DateTime(2011, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mishra Jain", "Ananya", "Female", false, true, "Krishna Patel", "9876543412", "Sikh", 202, "8th", "S202", "Patel", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8646) },
                    { 203, "120352039203", "2031 Test Street, Pune", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Pune", "A", 11, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8653), new DateTime(2011, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chopra Shah", "Arjun", "Male", false, true, "Advik Singh", "9876543413", "Jain", 203, "8th", "S203", "Singh", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8653) },
                    { 204, "120452049204", "2041 Test Street, Bangalore", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Bangalore", "A", 11, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8666), new DateTime(2011, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bansal Yadav", "Diya", "Female", false, false, "Samaira Kumar", "9876543414", "Buddhist", 204, "8th", "S204", "Kumar", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8667) },
                    { 205, "120552059205", "2051 Test Street, Chennai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Chennai", "A", 11, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8674), new DateTime(2011, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agrawal Reddy", "Ishaan", "Male", true, true, "Kiaan Gupta", "9876543415", "Hindu", 205, "8th", "S205", "Gupta", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8674) },
                    { 206, "120652069206", "2061 Test Street, Kolkata", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Kolkata", "A", 11, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8681), new DateTime(2011, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malhotra Khan", "Kavya", "Female", false, true, "Avni Agarwal", "9876543416", "Muslim", 206, "8th", "S206", "Agarwal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8681) },
                    { 207, "120752079207", "2071 Test Street, Hyderabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Hyderabad", "A", 11, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8688), new DateTime(2011, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kapoor Mishra", "Karan", "Male", false, false, "Aryan Verma", "9876543417", "Christian", 207, "8th", "S207", "Verma", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8688) },
                    { 208, "120852089208", "2081 Test Street, Ahmedabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Ahmedabad", "A", 11, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8695), new DateTime(2011, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mittal Chopra", "Myra", "Female", false, true, "Pari Jain", "9876543418", "Sikh", 208, "8th", "S208", "Jain", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8695) },
                    { 209, "120952099209", "2091 Test Street, Jaipur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Jaipur", "A", 11, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8703), new DateTime(2011, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joshi Bansal", "Riya", "Male", false, true, "Sai Shah", "9876543419", "Jain", 209, "8th", "S209", "Shah", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8703) },
                    { 210, "121052109210", "2101 Test Street, Lucknow", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Lucknow", "A", 11, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8710), new DateTime(2011, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saxena Agrawal", "Vihaan", "Female", true, false, "Atharv Yadav", "9876543420", "Buddhist", 210, "8th", "S210", "Yadav", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8710) },
                    { 211, "121152119211", "2111 Test Street, Kanpur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Kanpur", "A", 11, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8717), new DateTime(2011, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Srivastava Malhotra", "Saanvi", "Male", false, true, "Ira Reddy", "9876543421", "Hindu", 211, "8th", "S211", "Reddy", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8717) },
                    { 212, "121252129212", "2121 Test Street, Nagpur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Nagpur", "A", 11, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8724), new DateTime(2011, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pandey Kapoor", "Reyansh", "Female", false, true, "Ayaan Khan", "9876543422", "Muslim", 212, "8th", "S212", "Khan", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8725) },
                    { 213, "121352139213", "2131 Test Street, Indore", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Indore", "A", 11, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8732), new DateTime(2011, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiwari Mittal", "Anvi", "Male", false, false, "Navya Mishra", "9876543423", "Christian", 213, "8th", "S213", "Mishra", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8732) },
                    { 214, "121452149214", "2141 Test Street, Bhopal", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Bhopal", "A", 11, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8739), new DateTime(2011, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dubey Joshi", "Vivaan", "Female", false, true, "Rudra Chopra", "9876543424", "Sikh", 214, "8th", "S214", "Chopra", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8739) },
                    { 215, "121552159215", "2151 Test Street, Patna", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Patna", "A", 11, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8746), new DateTime(2011, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sharma Saxena", "Aadya", "Male", true, true, "Anaya Bansal", "9876543425", "Jain", 215, "8th", "S215", "Bansal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8746) },
                    { 216, "121652169216", "2161 Test Street, Vadodara", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Vadodara", "A", 11, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8753), new DateTime(2011, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patel Srivastava", "Aayan", "Female", false, false, "Om Agrawal", "9876543426", "Buddhist", 216, "8th", "S216", "Agrawal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8753) },
                    { 217, "121752179217", "2171 Test Street, Ludhiana", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Ludhiana", "A", 11, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8760), new DateTime(2011, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singh Pandey", "Pihu", "Male", false, true, "Tara Malhotra", "9876543427", "Hindu", 217, "8th", "S217", "Malhotra", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8761) },
                    { 218, "121852189218", "2181 Test Street, Agra", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Agra", "A", 11, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8768), new DateTime(2011, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kumar Tiwari", "Krishna", "Female", false, true, "Shaurya Kapoor", "9876543428", "Muslim", 218, "8th", "S218", "Kapoor", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8768) },
                    { 219, "121952199219", "2191 Test Street, Nashik", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Nashik", "A", 11, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8782), new DateTime(2011, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gupta Dubey", "Advik", "Male", false, false, "Kashvi Mittal", "9876543429", "Christian", 219, "8th", "S219", "Mittal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8782) },
                    { 220, "122052209220", "2201 Test Street, Faridabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Faridabad", "A", 11, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8790), new DateTime(2011, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agarwal Sharma", "Samaira", "Female", true, true, "Mihir Joshi", "9876543430", "Sikh", 220, "8th", "S220", "Joshi", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8790) },
                    { 221, "122152219221", "2211 Test Street, Meerut", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Meerut", "A", 12, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8798), new DateTime(2010, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Verma Patel", "Kiaan", "Male", false, true, "Prisha Saxena", "9876543431", "Jain", 221, "9th", "S221", "Saxena", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8798) },
                    { 222, "122252229222", "2221 Test Street, Rajkot", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Rajkot", "A", 12, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8806), new DateTime(2010, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jain Singh", "Avni", "Female", false, false, "Aadhya Srivastava", "9876543432", "Buddhist", 222, "9th", "S222", "Srivastava", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8806) },
                    { 223, "122352239223", "2231 Test Street, Kalyan", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Kalyan", "A", 12, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8813), new DateTime(2010, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shah Kumar", "Aryan", "Male", false, true, "Dev Pandey", "9876543433", "Hindu", 223, "9th", "S223", "Pandey", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8813) },
                    { 224, "122452249224", "2241 Test Street, Vasai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Vasai", "A", 12, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8821), new DateTime(2010, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yadav Gupta", "Pari", "Female", false, true, "Krisha Tiwari", "9876543434", "Muslim", 224, "9th", "S224", "Tiwari", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8821) },
                    { 225, "122552259225", "2251 Test Street, Varanasi", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Varanasi", "A", 12, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8828), new DateTime(2010, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reddy Agarwal", "Sai", "Male", true, false, "Arnav Dubey", "9876543435", "Christian", 225, "9th", "S225", "Dubey", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8828) },
                    { 226, "122652269226", "2261 Test Street, Mumbai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Mumbai", "A", 12, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8836), new DateTime(2010, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khan Verma", "Atharv", "Female", false, true, "Janvi Sharma", "9876543436", "Sikh", 226, "9th", "S226", "Sharma", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8836) },
                    { 227, "122752279227", "2271 Test Street, Delhi", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Delhi", "A", 12, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8843), new DateTime(2010, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mishra Jain", "Ira", "Male", false, true, "Yug Patel", "9876543437", "Jain", 227, "9th", "S227", "Patel", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8843) },
                    { 228, "122852289228", "2281 Test Street, Pune", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Pune", "A", 12, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8850), new DateTime(2010, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chopra Shah", "Ayaan", "Female", false, false, "Shanaya Singh", "9876543438", "Buddhist", 228, "9th", "S228", "Singh", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8851) },
                    { 229, "122952299229", "2291 Test Street, Bangalore", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Bangalore", "A", 12, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8857), new DateTime(2010, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bansal Yadav", "Navya", "Male", false, true, "Arjun Kumar", "9876543439", "Hindu", 229, "9th", "S229", "Kumar", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8858) },
                    { 230, "123052309230", "2301 Test Street, Chennai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Chennai", "A", 12, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8865), new DateTime(2010, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agrawal Reddy", "Rudra", "Female", true, true, "Anika Gupta", "9876543440", "Muslim", 230, "9th", "S230", "Gupta", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8865) },
                    { 231, "123152319231", "2311 Test Street, Kolkata", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Kolkata", "A", 12, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8872), new DateTime(2010, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malhotra Khan", "Anaya", "Male", false, false, "Vedant Agarwal", "9876543441", "Christian", 231, "9th", "S231", "Agarwal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8873) },
                    { 232, "123252329232", "2321 Test Street, Hyderabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Hyderabad", "A", 12, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8880), new DateTime(2010, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kapoor Mishra", "Om", "Female", false, true, "Reet Verma", "9876543442", "Sikh", 232, "9th", "S232", "Verma", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8880) },
                    { 233, "123352339233", "2331 Test Street, Ahmedabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Ahmedabad", "A", 12, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8887), new DateTime(2010, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mittal Chopra", "Tara", "Male", false, true, "Aarush Jain", "9876543443", "Jain", 233, "9th", "S233", "Jain", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8888) },
                    { 234, "123452349234", "2341 Test Street, Jaipur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Jaipur", "A", 12, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8895), new DateTime(2010, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joshi Bansal", "Shaurya", "Female", false, false, "Khushi Shah", "9876543444", "Buddhist", 234, "9th", "S234", "Shah", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8895) },
                    { 235, "123552359235", "2351 Test Street, Lucknow", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Lucknow", "A", 12, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8908), new DateTime(2010, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saxena Agrawal", "Kashvi", "Male", true, true, "Aarav Yadav", "9876543445", "Hindu", 235, "9th", "S235", "Yadav", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8909) },
                    { 236, "123652369236", "2361 Test Street, Kanpur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Kanpur", "A", 12, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8916), new DateTime(2010, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Srivastava Malhotra", "Mihir", "Female", false, true, "Ananya Reddy", "9876543446", "Muslim", 236, "9th", "S236", "Reddy", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8916) },
                    { 237, "123752379237", "2371 Test Street, Nagpur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Nagpur", "A", 12, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8923), new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pandey Kapoor", "Prisha", "Male", false, false, "Arjun Khan", "9876543447", "Christian", 237, "9th", "S237", "Khan", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8923) },
                    { 238, "123852389238", "2381 Test Street, Indore", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Indore", "A", 12, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8930), new DateTime(2010, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiwari Mittal", "Aadhya", "Female", false, true, "Diya Mishra", "9876543448", "Sikh", 238, "9th", "S238", "Mishra", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8931) },
                    { 239, "123952399239", "2391 Test Street, Bhopal", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Bhopal", "A", 12, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8938), new DateTime(2010, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dubey Joshi", "Dev", "Male", false, true, "Ishaan Chopra", "9876543449", "Jain", 239, "9th", "S239", "Chopra", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8938) },
                    { 240, "124052409240", "2401 Test Street, Patna", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Patna", "A", 12, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8945), new DateTime(2010, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sharma Saxena", "Krisha", "Female", true, false, "Kavya Bansal", "9876543450", "Buddhist", 240, "9th", "S240", "Bansal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8945) },
                    { 241, "124152419241", "2411 Test Street, Vadodara", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Vadodara", "A", 13, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8952), new DateTime(2009, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patel Srivastava", "Arnav", "Male", false, true, "Karan Agrawal", "9876543451", "Hindu", 241, "10th", "S241", "Agrawal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8953) },
                    { 242, "124252429242", "2421 Test Street, Ludhiana", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Ludhiana", "A", 13, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8960), new DateTime(2009, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singh Pandey", "Janvi", "Female", false, true, "Myra Malhotra", "9876543452", "Muslim", 242, "10th", "S242", "Malhotra", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8960) },
                    { 243, "124352439243", "2431 Test Street, Agra", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Agra", "A", 13, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8967), new DateTime(2009, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kumar Tiwari", "Yug", "Male", false, false, "Riya Kapoor", "9876543453", "Christian", 243, "10th", "S243", "Kapoor", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8967) },
                    { 244, "124452449244", "2441 Test Street, Nashik", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Nashik", "A", 13, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8974), new DateTime(2009, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gupta Dubey", "Shanaya", "Female", false, true, "Vihaan Mittal", "9876543454", "Sikh", 244, "10th", "S244", "Mittal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8974) },
                    { 245, "124552459245", "2451 Test Street, Faridabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Faridabad", "A", 13, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8981), new DateTime(2009, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agarwal Sharma", "Arjun", "Male", true, true, "Saanvi Joshi", "9876543455", "Jain", 245, "10th", "S245", "Joshi", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8981) },
                    { 246, "124652469246", "2461 Test Street, Meerut", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Meerut", "A", 13, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8988), new DateTime(2009, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Verma Patel", "Anika", "Female", false, false, "Reyansh Saxena", "9876543456", "Buddhist", 246, "10th", "S246", "Saxena", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8988) },
                    { 247, "124752479247", "2471 Test Street, Rajkot", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Rajkot", "A", 13, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8995), new DateTime(2009, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jain Singh", "Vedant", "Male", false, true, "Anvi Srivastava", "9876543457", "Hindu", 247, "10th", "S247", "Srivastava", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(8995) },
                    { 248, "124852489248", "2481 Test Street, Kalyan", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Kalyan", "A", 13, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9002), new DateTime(2009, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shah Kumar", "Reet", "Female", false, true, "Vivaan Pandey", "9876543458", "Muslim", 248, "10th", "S248", "Pandey", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9003) },
                    { 249, "124952499249", "2491 Test Street, Vasai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Vasai", "A", 13, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9009), new DateTime(2009, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yadav Gupta", "Aarush", "Male", false, false, "Aadya Tiwari", "9876543459", "Christian", 249, "10th", "S249", "Tiwari", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9009) },
                    { 250, "125052509250", "2501 Test Street, Varanasi", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Varanasi", "A", 13, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9016), new DateTime(2009, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reddy Agarwal", "Khushi", "Female", true, true, "Aayan Dubey", "9876543460", "Sikh", 250, "10th", "S250", "Dubey", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9016) },
                    { 251, "125152519251", "2511 Test Street, Mumbai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Mumbai", "A", 13, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9031), new DateTime(2009, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khan Verma", "Aarav", "Male", false, true, "Pihu Sharma", "9876543461", "Jain", 251, "10th", "S251", "Sharma", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9031) },
                    { 252, "125252529252", "2521 Test Street, Delhi", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Delhi", "A", 13, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9037), new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mishra Jain", "Ananya", "Female", false, false, "Krishna Patel", "9876543462", "Buddhist", 252, "10th", "S252", "Patel", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9038) },
                    { 253, "125352539253", "2531 Test Street, Pune", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Pune", "A", 13, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9044), new DateTime(2009, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chopra Shah", "Arjun", "Male", false, true, "Advik Singh", "9876543463", "Hindu", 253, "10th", "S253", "Singh", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9044) },
                    { 254, "125452549254", "2541 Test Street, Bangalore", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Bangalore", "A", 13, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9051), new DateTime(2009, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bansal Yadav", "Diya", "Female", false, true, "Samaira Kumar", "9876543464", "Muslim", 254, "10th", "S254", "Kumar", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9051) },
                    { 255, "125552559255", "2551 Test Street, Chennai", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Chennai", "A", 13, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9058), new DateTime(2009, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agrawal Reddy", "Ishaan", "Male", true, false, "Kiaan Gupta", "9876543465", "Christian", 255, "10th", "S255", "Gupta", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9058) },
                    { 256, "125652569256", "2561 Test Street, Kolkata", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Kolkata", "A", 13, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9065), new DateTime(2009, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malhotra Khan", "Kavya", "Female", false, true, "Avni Agarwal", "9876543466", "Sikh", 256, "10th", "S256", "Agarwal", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9065) },
                    { 257, "125752579257", "2571 Test Street, Hyderabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General", "Hyderabad", "A", 13, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9072), new DateTime(2009, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kapoor Mishra", "Karan", "Male", false, true, "Aryan Verma", "9876543467", "Jain", 257, "10th", "S257", "Verma", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9072) },
                    { 258, "125852589258", "2581 Test Street, Ahmedabad", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OBC", "Ahmedabad", "A", 13, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9086), new DateTime(2009, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mittal Chopra", "Myra", "Female", false, false, "Pari Jain", "9876543468", "Buddhist", 258, "10th", "S258", "Jain", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9087) },
                    { 259, "125952599259", "2591 Test Street, Jaipur", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "Jaipur", "A", 13, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9094), new DateTime(2009, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joshi Bansal", "Riya", "Male", false, true, "Sai Shah", "9876543469", "Hindu", 259, "10th", "S259", "Shah", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9095) },
                    { 260, "126052609260", "2601 Test Street, Lucknow", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "Lucknow", "A", 13, new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9101), new DateTime(2009, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saxena Agrawal", "Vihaan", "Female", true, true, "Atharv Yadav", "9876543470", "Muslim", 260, "10th", "S260", "Yadav", new DateTime(2025, 10, 6, 9, 14, 47, 683, DateTimeKind.Utc).AddTicks(9102) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.AccreditationNumber");

            migrationBuilder.DeleteData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.AddressLine1");

            migrationBuilder.DeleteData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.AlternatePhone");

            migrationBuilder.DeleteData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.Board");

            migrationBuilder.DeleteData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.Email");

            migrationBuilder.DeleteData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.ManagementName");

            migrationBuilder.DeleteData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.Name");

            migrationBuilder.DeleteData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.Phone");

            migrationBuilder.DeleteData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.PinCode");

            migrationBuilder.DeleteData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.UDISECode");

            migrationBuilder.DeleteData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.Website");

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9339), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9339) });

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9342), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9342) });

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9345), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9345) });

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9347), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9347) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6952), "Class 10", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6952) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "Section", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6961), "Class 10", "B", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6961) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6963), "Class 9", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6963) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "Section", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6964), "Class 9", "B", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6965) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6966), "Class 8", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6966) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Name", "Section", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6967), "Class 8", "B", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6968) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6994), "Class 7", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6995) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6996), "Class 6", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6996) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6997), "Class 5", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6998) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6999), "Class 1", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6999) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9051), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9051) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9056), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9056) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9060), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9061) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9064), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9065) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9068), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9068) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9072), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9072) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9077), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9077) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9081), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9081) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9084), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9084) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9087), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9088) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9210), new DateTime(2025, 9, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9210) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9215), new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9216) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9221), new DateTime(2025, 9, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9222) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9226), new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9227) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9231), new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9232) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9236), new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9236) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9276), new DateTime(2025, 9, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9276) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9280), new DateTime(2025, 9, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9281) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9286), new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9286) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9293), new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9293) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8745), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8746) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8752), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8752) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8754), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8754) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8755), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8756) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8757), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8757) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8759), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8759) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8760), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8760) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8762), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8762) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8763), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8764) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8765), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8765) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8766), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8767) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8768), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8768) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8769), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8770) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8771), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8771) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8773), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8773) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8774), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8774) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8776), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8776) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8777), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8778) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8779), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8779) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8780), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8781) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8782), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8782) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8784), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8784) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8785), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8785) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8787), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8787) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8788), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8788) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8790), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8790) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9127), new DateTime(2025, 9, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9128) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9132), new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9132) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9137), new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9137) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9141), new DateTime(2025, 9, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9142) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9145), new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9145) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9149), new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9149) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9152), new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9152) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9155), new DateTime(2025, 8, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9156) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9159), new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9160) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9163), new DateTime(2025, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9163) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8665), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8666) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8675), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8675) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8678), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8679) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8681), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8682) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8685), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8685) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8688), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8688) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8691), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8691) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8694), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8694) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8697), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8697) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8700), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8700) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7063), new DateTime(2008, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7063) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7257), new DateTime(2008, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7257) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7267), new DateTime(2008, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7268) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7274), new DateTime(2008, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7274) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7280), new DateTime(2008, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7281) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7288), new DateTime(2008, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7288) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7300), new DateTime(2008, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7300) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7307), new DateTime(2008, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7307) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7534), new DateTime(2008, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7535) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7563), new DateTime(2008, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7564) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7576), new DateTime(2008, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7576) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7583), new DateTime(2008, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7584) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7621), new DateTime(2008, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7621) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7628), new DateTime(2008, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7628) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7634), new DateTime(2008, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7635) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 2, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7642), new DateTime(2008, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7642) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 2, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7649), new DateTime(2008, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7649) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 2, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7658), new DateTime(2008, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7658) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 2, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7665), new DateTime(2008, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7665) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 2, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7673), new DateTime(2008, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7673) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ClassDivision", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7679), new DateTime(2008, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7680) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ClassDivision", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7686), new DateTime(2008, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7687) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ClassDivision", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7693), new DateTime(2008, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7694) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ClassDivision", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7700), new DateTime(2008, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7700) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ClassDivision", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7707), new DateTime(2008, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7707) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ClassDivision", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7713), new DateTime(2008, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7713) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ClassDivision", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7719), new DateTime(2008, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7719) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ClassDivision", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7743), new DateTime(2008, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7743) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ClassDivision", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7750), new DateTime(2008, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7751) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ClassDivision", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7757), new DateTime(2008, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "10th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7757) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7765), new DateTime(2009, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7765) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7776), new DateTime(2009, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7776) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7783), new DateTime(2009, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7793), new DateTime(2009, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7794) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7800), new DateTime(2009, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7801) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7807), new DateTime(2009, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7807) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7814), new DateTime(2009, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7814) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7821), new DateTime(2009, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7821) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7828), new DateTime(2009, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7828) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7834), new DateTime(2009, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7835) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7850), new DateTime(2009, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7850) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7875), new DateTime(2009, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7875) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 4, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7882), new DateTime(2009, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7883) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 4, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7889), new DateTime(2009, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7889) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 4, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7896), new DateTime(2009, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7896) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 4, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7903), new DateTime(2009, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7903) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 4, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7909), new DateTime(2009, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7910) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 4, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7916), new DateTime(2009, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7917) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 4, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7923), new DateTime(2009, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7923) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 4, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7930), new DateTime(2009, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 4, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7937), new DateTime(2009, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7937) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 4, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7943), new DateTime(2009, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7943) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 4, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7950), new DateTime(2009, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7950) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 4, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7956), new DateTime(2009, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "9th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7957) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7964), new DateTime(2010, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "8th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7964) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7974), new DateTime(2010, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7974) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7981), new DateTime(2010, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "8th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(7981) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8007), new DateTime(2010, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "8th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8007) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8014), new DateTime(2010, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "8th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8015) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8022), new DateTime(2010, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "8th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8022) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8029), new DateTime(2010, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "8th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8029) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8036), new DateTime(2010, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "8th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8036) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8042), new DateTime(2010, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "8th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8043) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8049), new DateTime(2010, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "8th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8049) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 6, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8056), new DateTime(2010, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "8th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8056) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 6, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8064), new DateTime(2010, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "8th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8064) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 6, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8071), new DateTime(2010, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "8th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8071) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 6, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8078), new DateTime(2010, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "8th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8078) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 6, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8085), new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "8th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8085) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 6, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8092), new DateTime(2010, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "8th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8092) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 6, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8099), new DateTime(2010, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "8th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8099) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 6, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8120), new DateTime(2010, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "8th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8120) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 6, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8127), new DateTime(2010, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "8th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8128) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "ClassDivision", "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { "B", 6, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8134), new DateTime(2010, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "8th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8135) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 7, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8142), new DateTime(2011, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "7th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8142) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 7, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8150), new DateTime(2011, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "7th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8150) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 7, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8157), new DateTime(2011, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "7th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8157) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 7, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8164), new DateTime(2011, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "7th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8164) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 7, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8171), new DateTime(2011, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "7th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8171) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 7, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8177), new DateTime(2011, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "7th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8178) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 7, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8185), new DateTime(2011, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "7th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8185) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 7, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8192), new DateTime(2011, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "7th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8192) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 7, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8199), new DateTime(2011, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "7th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8199) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 7, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8206), new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8206) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 8, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8213), new DateTime(2012, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "6th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8214) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 8, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8221), new DateTime(2012, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "6th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8221) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 8, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8228), new DateTime(2012, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "6th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8228) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 8, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8250), new DateTime(2012, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "6th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8250) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 8, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8257), new DateTime(2012, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "6th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8258) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 8, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8264), new DateTime(2012, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "6th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8265) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 8, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8271), new DateTime(2012, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "6th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8272) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 8, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8278), new DateTime(2012, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "6th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8279) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 8, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8286), new DateTime(2012, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "6th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8286) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 8, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8293), new DateTime(2012, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "6th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8293) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 9, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8300), new DateTime(2013, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "5th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8301) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 9, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8308), new DateTime(2013, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "5th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8308) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 9, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8316), new DateTime(2013, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "5th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8316) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 9, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8323), new DateTime(2013, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "5th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8323) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 9, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8330), new DateTime(2013, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "5th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8331) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 9, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8338), new DateTime(2013, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "5th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8338) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 9, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8345), new DateTime(2013, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "5th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8345) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 9, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8353), new DateTime(2013, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "5th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8353) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 9, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8367), new DateTime(2013, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "5th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8368) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 9, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8375), new DateTime(2013, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "5th", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8375) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8382), new DateTime(2017, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8382) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8390), new DateTime(2017, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8390) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8397), new DateTime(2017, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8397) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8404), new DateTime(2017, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8404) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8411), new DateTime(2017, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8411) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8418), new DateTime(2017, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8418) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8426), new DateTime(2017, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8426) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8433), new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8433) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8440), new DateTime(2017, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8440) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "ClassId", "CreatedAt", "DateOfBirth", "Standard", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8447), new DateTime(2017, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st", new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8447) });

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "Academic.CurrentYear",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 56, 14, 384, DateTimeKind.Utc).AddTicks(3751));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "Backup.AutoBackupEnabled",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 56, 14, 384, DateTimeKind.Utc).AddTicks(3755));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "Backup.BackupPath",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 56, 14, 384, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "Backup.RetentionDays",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 56, 14, 384, DateTimeKind.Utc).AddTicks(3758));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6653), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6654) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6663), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6663) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6670), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6671) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6674), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6675) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6678), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6678) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6683), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6684) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6687), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6687) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6691), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6691) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6696), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6696) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6700), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(6700) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8959), new DateTime(2025, 9, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8959) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8964), new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8964) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8969), new DateTime(2025, 9, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8970) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8974), new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8974) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8978), new DateTime(2025, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8978) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8985), new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8985) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8989), new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8989) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8993), new DateTime(2025, 9, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8994) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8997), new DateTime(2025, 9, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8998) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9001), new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(9002) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 3, 12, 26, 14, 384, DateTimeKind.Local).AddTicks(3659));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8844), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8844) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8847), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8847) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8849), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8850) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8852), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8852) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8855), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8855) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8857), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8858) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8860), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8861) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8863), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8863) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8865), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8866) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8868), new DateTime(2025, 10, 3, 6, 56, 14, 376, DateTimeKind.Utc).AddTicks(8868) });
        }
    }
}
