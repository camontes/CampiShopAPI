using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampiShopAPI.Migrations
{
    public partial class UpdateCategoriesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 7, 31, 13, 54, 59, 922, DateTimeKind.Local).AddTicks(5130), new DateTime(2020, 7, 31, 13, 54, 59, 923, DateTimeKind.Local).AddTicks(1929) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 7, 31, 13, 54, 59, 923, DateTimeKind.Local).AddTicks(2324), new DateTime(2020, 7, 31, 13, 54, 59, 923, DateTimeKind.Local).AddTicks(2333) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 7, 31, 13, 54, 59, 923, DateTimeKind.Local).AddTicks(2339), new DateTime(2020, 7, 31, 13, 54, 59, 923, DateTimeKind.Local).AddTicks(2340) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 7, 31, 13, 54, 59, 923, DateTimeKind.Local).AddTicks(2342), "Cellphones", new DateTime(2020, 7, 31, 13, 54, 59, 923, DateTimeKind.Local).AddTicks(2343) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 7, 31, 9, 52, 7, 717, DateTimeKind.Local).AddTicks(3218), new DateTime(2020, 7, 31, 9, 52, 7, 717, DateTimeKind.Local).AddTicks(9806) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 7, 31, 9, 52, 7, 718, DateTimeKind.Local).AddTicks(172), new DateTime(2020, 7, 31, 9, 52, 7, 718, DateTimeKind.Local).AddTicks(180) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 7, 31, 9, 52, 7, 718, DateTimeKind.Local).AddTicks(187), new DateTime(2020, 7, 31, 9, 52, 7, 718, DateTimeKind.Local).AddTicks(188) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 7, 31, 9, 52, 7, 718, DateTimeKind.Local).AddTicks(190), "Cell phones", new DateTime(2020, 7, 31, 9, 52, 7, 718, DateTimeKind.Local).AddTicks(191) });
        }
    }
}
