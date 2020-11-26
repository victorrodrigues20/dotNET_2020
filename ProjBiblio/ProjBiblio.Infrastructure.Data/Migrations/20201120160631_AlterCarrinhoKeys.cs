using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjBiblio.Infrastructure.Data.Migrations
{
    public partial class AlterCarrinhoKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Carrinho",
                table: "Carrinho");

            migrationBuilder.DropColumn(
                name: "CarrinhoID",
                table: "Carrinho");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarrinhoID",
                table: "Carrinho",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carrinho",
                table: "Carrinho",
                columns: new[] { "CarrinhoID", "LivroID" });
        }
    }
}
