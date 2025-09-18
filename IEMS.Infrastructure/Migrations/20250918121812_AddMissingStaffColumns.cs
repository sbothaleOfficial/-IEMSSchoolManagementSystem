using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IEMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingStaffColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7159), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7160) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7166), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7166) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7168), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7168) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7169), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7170) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7171), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7171) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7301), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7301) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7306), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7307) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7308), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7309) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7310), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7310) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7312), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7312) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7314), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7314) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7315), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7316) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7317), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7317) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7259), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7259) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7270), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7270) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7274), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7275) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7207), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7207) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7223), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7223) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7228), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7229) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(6932), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(6932) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(6937), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(6938) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(6942), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(6942) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(6945), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(6946) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(6949), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7414) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7419), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7419) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7424), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7424) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7348), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7349) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7352), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7352) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7355), new DateTime(2025, 9, 18, 12, 18, 12, 149, DateTimeKind.Utc).AddTicks(7355) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6816), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6817) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6820), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6821) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6822), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6822) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6824), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6824) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6825), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6826) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6934), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6934) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6940), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6942), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6942) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6943), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6943) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6945), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6945) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6947), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6947) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6948), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6948) });

            migrationBuilder.UpdateData(
                table: "FeeStructures",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6950), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6895), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6895) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6905), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6905) });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6909), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6909) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6852), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6852) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6864), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6864) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6869), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6869) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6647), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6647) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6652), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6653) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6657), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6657) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6661), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6661) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6664), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6665) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(7054), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(7054) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(7059), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(7059) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(7063), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(7063) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6984), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6984) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6987), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6988) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6990), new DateTime(2025, 9, 18, 11, 34, 35, 405, DateTimeKind.Utc).AddTicks(6990) });
        }
    }
}
