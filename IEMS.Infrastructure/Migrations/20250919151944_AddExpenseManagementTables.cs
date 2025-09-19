using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IEMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddExpenseManagementTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7493), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7493) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7503), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7503) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7505), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7505) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7506), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7507) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7508), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7508) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7767), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7768) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7772), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7773) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7777), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7777) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7616), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7616) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7620), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7621) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7622), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7623) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7624), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7624) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7625), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7626) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7627), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7627) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7629), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7629) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7630), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7631) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7819), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7819) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7824), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7824) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7829), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7829) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7583), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7583) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7591), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7591) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7595), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7595) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7538), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7538) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7551), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7551) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7556), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7556) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7324), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7325) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7330), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7331) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7334), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7335) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7338), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7339) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7342), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7343) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7719), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7720) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7725), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7725) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7730), new DateTime(2025, 9, 19, 15, 19, 43, 910, DateTimeKind.Utc).AddTicks(7730) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2239), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2239) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2244), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2244) });

            migrationBuilder.UpdateData(
                table: "ElectricityBills",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2248), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2248) });

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

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2277), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2278) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2283), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2283) });

            migrationBuilder.UpdateData(
                table: "OtherExpenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2287), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2287) });

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2191), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2192) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2197), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2198) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2201), new DateTime(2025, 9, 19, 12, 50, 19, 827, DateTimeKind.Utc).AddTicks(2202) });

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
        }
    }
}
