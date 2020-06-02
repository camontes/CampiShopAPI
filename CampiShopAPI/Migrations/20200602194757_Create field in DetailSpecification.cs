using Microsoft.EntityFrameworkCore.Migrations;

namespace CampiShopAPI.Migrations
{
    public partial class CreatefieldinDetailSpecification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DetailSpecifications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "DetailSpecifications");
        }
    }
}
