using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IEMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAcademicCurrentYearSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "Academic.CurrentYear");

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3409), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3410) });

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3412), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3413) });

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3415), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3416) });

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3418), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3419) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(172), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(173) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(179), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(179) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(181), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(181) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(182), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(183) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(184), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(184) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(185), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(186) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(187), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(187) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(189), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(189) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(190), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(190) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(192), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(192) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(193), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(194) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(195), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(195) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(197), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(197) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3150), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3151) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3157), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3158) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3162), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3163) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3167), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3167) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3171), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3172) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3177), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3178) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3182), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3182) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3186), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3186) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3190), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3190) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3193), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3194) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3322), new DateTime(2025, 9, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3323) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3331), new DateTime(2025, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3331) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3336), new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3337) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3341), new DateTime(2025, 9, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3341) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3346), new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3346) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3351), new DateTime(2025, 9, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3351) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3356), new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3357) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3361), new DateTime(2025, 10, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3362) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3366), new DateTime(2025, 10, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3367) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3371), new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3372) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2871), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2872) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2877), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2878) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2880), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2880) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2881), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2882) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2883), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2883) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2885), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2885) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2886), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2887) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2888), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2888) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2890), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2890) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2891), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2892) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2893), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2893) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2895), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2895) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2897) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2910), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2911) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2912), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2913) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2914), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2914) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2916), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2916) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2918), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2918) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2919), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2920) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2921), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2922) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2923), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2923) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2925), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2925) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2926), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2927) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2928), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2928) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2930), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2930) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2931), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2931) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3240), new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3241) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3246), new DateTime(2025, 9, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3246) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3250), new DateTime(2025, 10, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3251) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3254), new DateTime(2025, 9, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3254) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3258), new DateTime(2025, 9, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3258) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3262), new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3262) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3265), new DateTime(2025, 9, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3269), new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3269) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3273), new DateTime(2025, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3274) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3277), new DateTime(2025, 9, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3278) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2798), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2798) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2807), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2807) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2811), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2811) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2814), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2815) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2817), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2818) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2820), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2821) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2824), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2824) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2827), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2827) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2830), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2830) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2833), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2833) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(228), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(228) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(304), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(305) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(325), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(325) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(333), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(334) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(341), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(342) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(350), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(351) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(358), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(358) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(366), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(366) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(373), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(373) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(381), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(381) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(389), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(389) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(396), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(396) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(403), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(404) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(410), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(411) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(417), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(417) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(424), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(424) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(431), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(431) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(450), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(450) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(457), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(458) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(464), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(464) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(472), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(472) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(480), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(488), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(488) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(495), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(495) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(502), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(503) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(509), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(510) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(516), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(517) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(523), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(524) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(530), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(530) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(537), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(538) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(544), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(545) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(559), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(559) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(566), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(567) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(575), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(575) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(582), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(582) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(589), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(589) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(597), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(597) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(604), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(604) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(611), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(612) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(618), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(619) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(626), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(626) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(636), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(636) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(643), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(643) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(650), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(650) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(657), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(657) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(675), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(675) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(683), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(683) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(690), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(690) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(697), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(698) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(705), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(705) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(712), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(712) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(719), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(720) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(727), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(727) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(734), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(734) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(741), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(741) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(748), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(748) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(755), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(755) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(762), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(763) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(769), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(770) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(776), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(777) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(794), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(794) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(803), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(804) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(811), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(811) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(818), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(818) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(825), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(826) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(834), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(834) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(842), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(842) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(849), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(849) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(857), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(857) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(864), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(864) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(871), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(872) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(878), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(879) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(886), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(886) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(906), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(907) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(914), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(914) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(921), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(922) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(929), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(929) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(936), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(936) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(943), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(944) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(951), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(951) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(959), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(959) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(967), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(968) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(975), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(975) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(982), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(983) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(990), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(990) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(997), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(997) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1005), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1005) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1012), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1012) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1030), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1031) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1038), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1038) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1045), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1045) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1053), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1053) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1060), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1060) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1067), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1068) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1075), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1075) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1082), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1089), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1090) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1097), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1097) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1104), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1104) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1112), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1112) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1120), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1120) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1129), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1129) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1137), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1137) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1156), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1157) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1165), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1165) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1172), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1172) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1179), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1187), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1187) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1194), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1195) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1202), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1202) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1209), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1210) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1217), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1217) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1224), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1225) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1232), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1232) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1240), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1247), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1247) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1255), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1255) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1262), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1262) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1279), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1279) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1287), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1287) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1295), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1295) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1304), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1304) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1312), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1312) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1319), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1319) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1327), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1327) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1334), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1335) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1342), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1342) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1349), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1357), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1357) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1373), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1373) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1381), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1381) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1388), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1389) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1396), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1396) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1403), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1404) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1411), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1411) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1418), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1419) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1426), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1426) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1433), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1434) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1441), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1441) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1448), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1448) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1456), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1456) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1465), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1465) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1473), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1473) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1480), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1480) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1495), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1495) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1503), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1503) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1511), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1511) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1518), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1519) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1526), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1526) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1534), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1534) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1541), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1542) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1549), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1549) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1556), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1557) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1564), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1564) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1572), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1572) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1579), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1579) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1587), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1587) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1594), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1595) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1602), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1602) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1619), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1620) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1628), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1628) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1637), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1637) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1645), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1645) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1653), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1660), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1660) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1668), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1668) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1676), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1676) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1683), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1684) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1691), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1691) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1699), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1699) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1706), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1706) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1713), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1714) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1722), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1722) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1729), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1730) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1745), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1747) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1755), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1755) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1763), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1763) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1770), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1771) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1778), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1778) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1785), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1786) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1793), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1794) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1803), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1803) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1811), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1811) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1818), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1819) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1826), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1826) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1834), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1834) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1842), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1842) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1849), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1850) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1857), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1857) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1872), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1872) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1880), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1880) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1887), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1888) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1896), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1896) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1903), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1904) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1911), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1911) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1919), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1919) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1926), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1927) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1934), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1934) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1942), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1942) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1949), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1950) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1957), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1958) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1966), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1966) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1974), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1974) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1982), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1982) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1998), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(1998) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2006), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2006) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2014), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2014) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2021), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2022) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2029), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2029) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2037), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2037) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2045), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2045) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2053), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2053) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 213,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2060), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2061) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 214,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2068), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2069) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 215,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2077), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2077) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 216,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2084), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2085) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 217,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2092), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2092) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2100), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2100) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2108), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2108) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2124), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2124) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 221,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2132), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2132) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 222,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2141), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2141) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 223,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2149), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2149) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 224,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2157), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2157) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 225,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2165), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2165) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 226,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2172), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2173) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 227,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2180), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2181) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 228,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2188), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2189) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 229,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2196), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2196) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 230,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2204), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2204) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 231,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2212), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2212) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2220), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2220) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2228), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2228) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2236), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2236) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2273), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2274) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2282), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2282) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2290), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2290) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2298), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2298) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2306), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2306) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2313), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2313) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2321), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2321) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2330), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2330) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2337), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2338) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2345), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2345) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2352), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2353) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2360), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2360) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2368), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2368) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2375), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2376) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2383), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2383) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2431), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2431) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2439), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2439) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2446), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2446) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2454), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2454) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2461), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2462) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2469), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2469) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2477), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2477) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2484), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2485) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2542), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2542) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2550), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2550) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 260,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2557), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2558) });

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "Backup.AutoBackupEnabled",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 5, 54, 8, 62, DateTimeKind.Utc).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "Backup.BackupPath",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 5, 54, 8, 62, DateTimeKind.Utc).AddTicks(9503));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "Backup.RetentionDays",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 5, 54, 8, 62, DateTimeKind.Utc).AddTicks(9501));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.AccreditationNumber",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 5, 54, 8, 62, DateTimeKind.Utc).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.AddressLine1",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 5, 54, 8, 62, DateTimeKind.Utc).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.AlternatePhone",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 5, 54, 8, 62, DateTimeKind.Utc).AddTicks(9536));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.Board",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 5, 54, 8, 62, DateTimeKind.Utc).AddTicks(9516));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.Email",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 5, 54, 8, 62, DateTimeKind.Utc).AddTicks(9538));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.ManagementName",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 5, 54, 8, 62, DateTimeKind.Utc).AddTicks(9505));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.Name",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 5, 54, 8, 62, DateTimeKind.Utc).AddTicks(9507));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.Phone",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 5, 54, 8, 62, DateTimeKind.Utc).AddTicks(9518));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.PinCode",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 5, 54, 8, 62, DateTimeKind.Utc).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.UDISECode",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 5, 54, 8, 62, DateTimeKind.Utc).AddTicks(9514));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.Website",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 5, 54, 8, 62, DateTimeKind.Utc).AddTicks(9540));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 54, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 10, 17, 5, 54, 8, 54, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 54, DateTimeKind.Utc).AddTicks(9855), new DateTime(2025, 10, 17, 5, 54, 8, 54, DateTimeKind.Utc).AddTicks(9856) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 54, DateTimeKind.Utc).AddTicks(9860), new DateTime(2025, 10, 17, 5, 54, 8, 54, DateTimeKind.Utc).AddTicks(9860) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 54, DateTimeKind.Utc).AddTicks(9864), new DateTime(2025, 10, 17, 5, 54, 8, 54, DateTimeKind.Utc).AddTicks(9864) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 54, DateTimeKind.Utc).AddTicks(9870), new DateTime(2025, 10, 17, 5, 54, 8, 54, DateTimeKind.Utc).AddTicks(9870) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 54, DateTimeKind.Utc).AddTicks(9873), new DateTime(2025, 10, 17, 5, 54, 8, 54, DateTimeKind.Utc).AddTicks(9874) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 54, DateTimeKind.Utc).AddTicks(9877), new DateTime(2025, 10, 17, 5, 54, 8, 54, DateTimeKind.Utc).AddTicks(9878) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 54, DateTimeKind.Utc).AddTicks(9881), new DateTime(2025, 10, 17, 5, 54, 8, 54, DateTimeKind.Utc).AddTicks(9882) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 54, DateTimeKind.Utc).AddTicks(9885), new DateTime(2025, 10, 17, 5, 54, 8, 54, DateTimeKind.Utc).AddTicks(9886) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 54, DateTimeKind.Utc).AddTicks(9891), new DateTime(2025, 10, 17, 5, 54, 8, 54, DateTimeKind.Utc).AddTicks(9891) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3068), new DateTime(2025, 10, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3068) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3073), new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3074) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3078), new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3079) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3084), new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3084) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3088), new DateTime(2025, 10, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3088) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3092), new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3092) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3096), new DateTime(2025, 10, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3097) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3100), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3101) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3104), new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3105) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3108), new DateTime(2025, 10, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3109) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 17, 11, 24, 8, 62, DateTimeKind.Local).AddTicks(8529));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2983), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2983) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2986), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2986) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2989), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2989) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2991), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2992) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2994), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2994) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2996), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2996) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2999), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(2999) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3001), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3001) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3004), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3004) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3006), new DateTime(2025, 10, 17, 5, 54, 8, 55, DateTimeKind.Utc).AddTicks(3006) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9896), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9897) });

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9900), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9900) });

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9902), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9903) });

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9905), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9905) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6846), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6846) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6851), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6852) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6853), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6854) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6855), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6855) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6857), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6857) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6858), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6858) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6860), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6860) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6861), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6862) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6863), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6863) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6864), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6865) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6867), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6867) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6870), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6872), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6873) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9645), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9646) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9652), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9652) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9657), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9657) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9661), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9661) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9665), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9665) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9670), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9670) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9674), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9674) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9677), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9678) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9681), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9681) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9684), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9684) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9804), new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9805) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9811), new DateTime(2025, 9, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9812) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9817), new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9817) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9830), new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9830) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9835), new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9835) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9840), new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9840) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9845), new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9845) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9849), new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9855), new DateTime(2025, 10, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9856) });

            migrationBuilder.UpdateData(
                table: "FeePayments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9860), new DateTime(2025, 10, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9860) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9361), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9362) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9367), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9367) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9369), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9369) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9370), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9371) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9372), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9372) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9374), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9374) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9376), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9376) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9377), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9378) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9379), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9379) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9381), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9381) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9383), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9383) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9386), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9386) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9387), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9388) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9389), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9389) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9391), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9391) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9392), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9393) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9394), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9394) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9396), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9396) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9397), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9398) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9399), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9399) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9401), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9401) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9403), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9403) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9404), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9405) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9406), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9406) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9407), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9408) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9409), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9409) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9721), new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9722) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9728), new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9729) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9734), new DateTime(2025, 10, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9734) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9738), new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9739) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9743), new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9743) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9747), new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9747) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9750), new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9753), new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9754) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9757), new DateTime(2025, 9, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9758) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9761), new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9762) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9291), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9291) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9300), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9300) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9304), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9304) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9308), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9308) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9311), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9311) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9314), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9314) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9317), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9318) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9320), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9321) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9323), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9324) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9326), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9326) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6905), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6905) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6973), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6973) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6983), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6983) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6990), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6991) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6998), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6998) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7006), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7007) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7014), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7014) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7028), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7029) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7037), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7037) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7048), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7048) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7056), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7056) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7064), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7064) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7071), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7072) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7079), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7080) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7087), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7087) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7094), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7094) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7101), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7102) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7109), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7110) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7117), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7117) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7124), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7124) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7131), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7131) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7147), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7148) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7156), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7156) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7163), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7164) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7170), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7171) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7178), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7178) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7185), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7185) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7193), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7193) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7200), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7200) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7207), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7207) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7214), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7214) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7221), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7222) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7229), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7229) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7237), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7238) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7244), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7259), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7259) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7266), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7266) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7273), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7273) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7280), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7280) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7287), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7287) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7295), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7295) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7304), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7305) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7312), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7312) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7319), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7320) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7327), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7327) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7334), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7334) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7341), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7341) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7348), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7349) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7356), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7356) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7363), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7363) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7377), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7378) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7385), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7385) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7392), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7392) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7400), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7400) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7407), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7407) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7415), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7415) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7421), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7422) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7429), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7429) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7436), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7437) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7444), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7445) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7452), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7452) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7461), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7461) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7468), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7468) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7475), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7475) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7482), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7483) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7497), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7497) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7505), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7505) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7512), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7519), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7520) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7527), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7527) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7534), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7535) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7542), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7542) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7549), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7550) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7557), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7557) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7564), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7564) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7571), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7572) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7579), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7579) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7586), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7586) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7593), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7593) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7608), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7608) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7616), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7616) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7624), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7624) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7632), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7632) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7639), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7640) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7646), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7647) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7654), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7654) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7661), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7661) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7668), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7668) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7675), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7676) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7682), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7683) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7689), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7690) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7697), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7697) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7704), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7704) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7712), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7712) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7726), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7727) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7735), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7735) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7743), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7743) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7751), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7751) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7759), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7759) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7766), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7766) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7774), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7774) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7783), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7790), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7798), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7798) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7805), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7805) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7812), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7812) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7820), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7820) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7827), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7828) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7835), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7835) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7850), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7850) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7857), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7857) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7865), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7865) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7872), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7873) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7880), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7880) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7887), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7887) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7894), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7895) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7902), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7902) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7909), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7909) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7916), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7917) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7923), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7924) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7931), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7932) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7941), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7941) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7948), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7949) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7963), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7964) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7972), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7972) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7979), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7979) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7986), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7986) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7994), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(7994) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8001), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8002) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8010), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8010) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8018), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8018) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8025), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8025) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8032), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8033) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8040), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8040) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8047), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8047) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8062), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8062) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8070), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8070) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8077), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8077) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8084), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8085) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8091), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8092) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8100), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8100) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8109), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8110) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8117), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8117) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8124), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8125) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8132), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8132) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8139), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8140) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8147), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8147) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8154), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8155) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8161), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8162) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8169), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8169) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8184), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8185) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8192), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8192) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8199), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8199) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8206), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8207) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8214), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8214) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8221), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8221) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8228), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8229) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8236), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8236) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8244), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8244) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8252), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8252) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8259), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8260) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8268), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8269) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8276), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8276) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8283), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8283) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8290), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8290) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8306), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8306) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8313), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8313) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8321), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8321) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8328), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8328) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8335), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8335) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8343) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8350), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8350) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8357), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8358) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8365), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8365) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8372), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8372) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8379), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8379) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8387), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8387) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8394), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8394) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8401), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8401) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8409), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8409) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8425), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8425) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8434), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8434) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8442), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8442) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8450), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8450) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8458), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8458) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8465), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8465) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8473), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8474) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8481), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8481) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8489), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8489) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8496), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8496) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8503), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8504) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8511), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8512) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8519), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8519) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8526), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8526) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8534), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8535) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8550), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8550) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8558), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8558) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8566), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8566) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8573), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8574) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8581), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8581) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8589), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8589) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8597), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8597) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8605), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8605) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8613), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8613) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8620), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8621) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8628), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8628) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8635), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8636) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8643), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8643) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8651), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8651) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8658), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8658) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8673), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8674) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8682), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8682) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 213,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8689), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8690) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 214,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8697), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8697) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 215,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8705), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8705) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 216,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8712), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8713) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 217,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8720), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8721) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8728), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8728) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8735), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8736) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8743), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8744) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 221,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8751), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8751) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 222,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8759), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8760) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 223,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8767), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8767) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 224,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8775), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8775) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 225,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8789), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8790) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 226,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8798), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8798) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 227,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8806), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8806) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 228,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8813), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8813) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 229,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8821), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8821) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 230,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8828), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8829) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 231,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8837), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8837) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8844), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8844) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8852), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8852) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8859), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8859) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8867), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8867) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8875), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8875) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8882), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8883) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8890), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8890) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8898), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8898) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8912), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8913) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8921), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8921) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8929), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8930) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8937), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8937) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8944), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8945) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8952), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8952) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8960), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8960) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8967), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8967) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8974), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8974) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8982), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8982) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8989), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8990) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8997), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(8997) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9004), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9005) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9012), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9012) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9019), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9019) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9033), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9034) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9041), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9042) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9049), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9049) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9058), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9058) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9065), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9066) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 260,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9073), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9074) });

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "Backup.AutoBackupEnabled",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 12, 27, 6, 445, DateTimeKind.Utc).AddTicks(4682));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "Backup.BackupPath",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 12, 27, 6, 445, DateTimeKind.Utc).AddTicks(4686));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "Backup.RetentionDays",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 12, 27, 6, 445, DateTimeKind.Utc).AddTicks(4684));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.AccreditationNumber",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 12, 27, 6, 445, DateTimeKind.Utc).AddTicks(4695));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.AddressLine1",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 12, 27, 6, 445, DateTimeKind.Utc).AddTicks(4692));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.AlternatePhone",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 12, 27, 6, 445, DateTimeKind.Utc).AddTicks(4702));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.Board",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 12, 27, 6, 445, DateTimeKind.Utc).AddTicks(4699));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.Email",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 12, 27, 6, 445, DateTimeKind.Utc).AddTicks(4704));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.ManagementName",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 12, 27, 6, 445, DateTimeKind.Utc).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.Name",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 12, 27, 6, 445, DateTimeKind.Utc).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.Phone",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 12, 27, 6, 445, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.PinCode",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 12, 27, 6, 445, DateTimeKind.Utc).AddTicks(4694));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.UDISECode",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 12, 27, 6, 445, DateTimeKind.Utc).AddTicks(4697));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Key",
                keyValue: "School.Website",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 12, 27, 6, 445, DateTimeKind.Utc).AddTicks(4706));

            migrationBuilder.InsertData(
                table: "SystemSettings",
                columns: new[] { "Key", "Category", "CreatedAt", "DataType", "DefaultValue", "Description", "IsReadOnly", "ModifiedAt", "Value" },
                values: new object[] { "Academic.CurrentYear", "Academic", new DateTime(2025, 10, 15, 12, 27, 6, 445, DateTimeKind.Utc).AddTicks(4679), "String", "2024-25", "Current academic year", false, null, "2024-25" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6583), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6584) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6589), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6590) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6594), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6594) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6599), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6599) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6603), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6603) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6607), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6607) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6611), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6611) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6617), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6617) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6621), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6622) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6625), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(6626) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9555), new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9555) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9560), new DateTime(2025, 10, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9561) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9565), new DateTime(2025, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9566) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9571), new DateTime(2025, 10, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9571) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9575), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9576) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9579), new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9580) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9584), new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9584) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9589), new DateTime(2025, 10, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9590) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9593), new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9594) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ExpenseDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9597), new DateTime(2025, 10, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9598) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 15, 17, 57, 6, 445, DateTimeKind.Local).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9458), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9458) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9461), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9461) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9464), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9464) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9466), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9466) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9468), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9469) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9478), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9479) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9481), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9482) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9484), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9484) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9486), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9487) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9488), new DateTime(2025, 10, 15, 12, 27, 6, 437, DateTimeKind.Utc).AddTicks(9489) });
        }
    }
}
