using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IEMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixTeacherMonthlySalaryDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MonthlySalary",
                table: "Teachers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5366), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5366) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5374), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5375) });

            migrationBuilder.UpdateData(
                table: "TransportExpenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5379), new DateTime(2025, 9, 18, 14, 54, 53, 932, DateTimeKind.Utc).AddTicks(5379) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MonthlySalary",
                table: "Teachers",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
    }
}
