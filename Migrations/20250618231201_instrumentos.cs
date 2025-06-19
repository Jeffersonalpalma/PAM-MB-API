using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PAM_MB_API.Migrations
{
    /// <inheritdoc />
    public partial class instrumentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_MUSICOS_Usuario_UsuarioId",
                table: "TB_MUSICOS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "TB_USUARIOS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USUARIOS",
                table: "TB_USUARIOS",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TB_INSTRUMENTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_INSTRUMENTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_MUSICO_INSTRUMENTO",
                columns: table => new
                {
                    MusicoId = table.Column<int>(type: "int", nullable: false),
                    InstrumentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MUSICO_INSTRUMENTO", x => new { x.MusicoId, x.InstrumentoId });
                    table.ForeignKey(
                        name: "FK_TB_MUSICO_INSTRUMENTO_TB_INSTRUMENTO_InstrumentoId",
                        column: x => x.InstrumentoId,
                        principalTable: "TB_INSTRUMENTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_MUSICO_INSTRUMENTO_TB_MUSICOS_MusicoId",
                        column: x => x.MusicoId,
                        principalTable: "TB_MUSICOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_INSTRUMENTO",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Saxofone" },
                    { 2, "Guitarra" },
                    { 3, "Cavaco" },
                    { 4, "Violão" }
                });

            migrationBuilder.InsertData(
                table: "TB_MUSICO_INSTRUMENTO",
                columns: new[] { "InstrumentoId", "MusicoId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_MUSICO_INSTRUMENTO_InstrumentoId",
                table: "TB_MUSICO_INSTRUMENTO",
                column: "InstrumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_MUSICOS_TB_USUARIOS_UsuarioId",
                table: "TB_MUSICOS",
                column: "UsuarioId",
                principalTable: "TB_USUARIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_MUSICOS_TB_USUARIOS_UsuarioId",
                table: "TB_MUSICOS");

            migrationBuilder.DropTable(
                name: "TB_MUSICO_INSTRUMENTO");

            migrationBuilder.DropTable(
                name: "TB_INSTRUMENTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USUARIOS",
                table: "TB_USUARIOS");

            migrationBuilder.RenameTable(
                name: "TB_USUARIOS",
                newName: "Usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_MUSICOS_Usuario_UsuarioId",
                table: "TB_MUSICOS",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
