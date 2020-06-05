using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampiShopAPI.Migrations
{
    public partial class ChangefieldUpdatedAtinProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateddAt",
                table: "Products");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Products");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateddAt",
                table: "Products",
                type: "datetime2",
                nullable: true);
        }
    }
}
