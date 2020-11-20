using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjBiblio.Infrastructure.Data.Migrations
{
    public partial class AddCarrinhoSessionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SessionUserID",
                table: "Carrinho",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionUserID",
                table: "Carrinho");
        }
    }
}
