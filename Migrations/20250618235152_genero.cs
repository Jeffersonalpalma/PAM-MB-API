using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PAM_MB_API.Migrations
{
    /// <inheritdoc />
    public partial class genero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_GENERO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_GENERO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_MUSICO_GENERO",
                columns: table => new
                {
                    MusicoId = table.Column<int>(type: "int", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MUSICO_GENERO", x => new { x.MusicoId, x.GeneroId });
                    table.ForeignKey(
                        name: "FK_TB_MUSICO_GENERO_TB_GENERO_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "TB_GENERO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_MUSICO_GENERO_TB_MUSICOS_MusicoId",
                        column: x => x.MusicoId,
                        principalTable: "TB_MUSICOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_GENERO",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Contry" },
                    { 2, "Pop" },
                    { 3, "Rap" },
                    { 4, "Funk" },
                    { 5, "Pagode" },
                    { 6, "R&B" }
                });

            migrationBuilder.InsertData(
                table: "TB_MUSICO_GENERO",
                columns: new[] { "GeneroId", "MusicoId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_MUSICO_GENERO_GeneroId",
                table: "TB_MUSICO_GENERO",
                column: "GeneroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_MUSICO_GENERO");

            migrationBuilder.DropTable(
                name: "TB_GENERO");
        }
    }
}
