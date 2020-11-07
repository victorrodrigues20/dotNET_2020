using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProjBiblio.Infrastructure.Data.Migrations
{
    public partial class TabelasManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emprestimo",
                columns: table => new
                {
                    EmprestimoID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioID = table.Column<int>(nullable: false),
                    DataInicio = table.Column<string>(nullable: true),
                    DataFim = table.Column<string>(nullable: true),
                    DataDevolucao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimo", x => x.EmprestimoID);
                    table.ForeignKey(
                        name: "FK_Emprestimo_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivroAutor",
                columns: table => new
                {
                    AutorID = table.Column<int>(nullable: false),
                    LivroID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroAutor", x => new { x.AutorID, x.LivroID });
                    table.ForeignKey(
                        name: "FK_LivroAutor_Autor_AutorID",
                        column: x => x.AutorID,
                        principalTable: "Autor",
                        principalColumn: "AutorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroAutor_Livro_LivroID",
                        column: x => x.LivroID,
                        principalTable: "Livro",
                        principalColumn: "LivroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivroEmprestimo",
                columns: table => new
                {
                    LivroID = table.Column<int>(nullable: false),
                    EmprestimoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroEmprestimo", x => new { x.LivroID, x.EmprestimoID });
                    table.ForeignKey(
                        name: "FK_LivroEmprestimo_Emprestimo_EmprestimoID",
                        column: x => x.EmprestimoID,
                        principalTable: "Emprestimo",
                        principalColumn: "EmprestimoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroEmprestimo_Livro_LivroID",
                        column: x => x.LivroID,
                        principalTable: "Livro",
                        principalColumn: "LivroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_UsuarioID",
                table: "Emprestimo",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_LivroID",
                table: "LivroAutor",
                column: "LivroID");

            migrationBuilder.CreateIndex(
                name: "IX_LivroEmprestimo_EmprestimoID",
                table: "LivroEmprestimo",
                column: "EmprestimoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivroAutor");

            migrationBuilder.DropTable(
                name: "LivroEmprestimo");

            migrationBuilder.DropTable(
                name: "Emprestimo");
        }
    }
}
