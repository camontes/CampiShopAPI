using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampiShopAPI.Migrations
{
    public partial class AddCategoriesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 7, 31, 9, 52, 7, 717, DateTimeKind.Local).AddTicks(3218), "Here you can find all about computers", "Computers", new DateTime(2020, 7, 31, 9, 52, 7, 717, DateTimeKind.Local).AddTicks(9806) },
                    { 2, new DateTime(2020, 7, 31, 9, 52, 7, 718, DateTimeKind.Local).AddTicks(172), "Here you can find all about TV's", "TV's", new DateTime(2020, 7, 31, 9, 52, 7, 718, DateTimeKind.Local).AddTicks(180) },
                    { 3, new DateTime(2020, 7, 31, 9, 52, 7, 718, DateTimeKind.Local).AddTicks(187), "Here you can find all about videogames", "Videogames", new DateTime(2020, 7, 31, 9, 52, 7, 718, DateTimeKind.Local).AddTicks(188) },
                    { 4, new DateTime(2020, 7, 31, 9, 52, 7, 718, DateTimeKind.Local).AddTicks(190), "Here you can find all about cell phones", "Cell phones", new DateTime(2020, 7, 31, 9, 52, 7, 718, DateTimeKind.Local).AddTicks(191) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
