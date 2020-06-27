using Microsoft.EntityFrameworkCore.Migrations;

namespace CampiShopAPI.Migrations
{
    public partial class DeleteastateOrderseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StateOrders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "StateOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Pendiente");

            migrationBuilder.UpdateData(
                table: "StateOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Recibido");

            migrationBuilder.UpdateData(
                table: "StateOrders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Despachado");

            migrationBuilder.UpdateData(
                table: "StateOrders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Entregado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StateOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "En proceso");

            migrationBuilder.UpdateData(
                table: "StateOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Pendiente");

            migrationBuilder.UpdateData(
                table: "StateOrders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Recibido");

            migrationBuilder.UpdateData(
                table: "StateOrders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Despachado");

            migrationBuilder.InsertData(
                table: "StateOrders",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Entregado" });
        }
    }
}
