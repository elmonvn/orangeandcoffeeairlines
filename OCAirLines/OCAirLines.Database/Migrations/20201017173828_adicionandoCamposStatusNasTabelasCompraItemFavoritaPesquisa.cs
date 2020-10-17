using Microsoft.EntityFrameworkCore.Migrations;

namespace OCAirLines.Database.Migrations
{
    public partial class adicionandoCamposStatusNasTabelasCompraItemFavoritaPesquisa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Pesquisas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Favoritas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "CompraItens",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Pesquisas");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Favoritas");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CompraItens");
        }
    }
}
