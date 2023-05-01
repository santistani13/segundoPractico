using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace segundoPractico.Migrations
{
    /// <inheritdoc />
    public partial class addEmpresaModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    ubicacion = table.Column<string>(type: "TEXT", nullable: false),
                    mail = table.Column<string>(type: "TEXT", nullable: false),
                    NotebookId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.id);
                    table.ForeignKey(
                        name: "FK_Empresa_Notebook_NotebookId",
                        column: x => x.NotebookId,
                        principalTable: "Notebook",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_NotebookId",
                table: "Empresa",
                column: "NotebookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
