using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PAM_MB_API.Migrations
{
    /// <inheritdoc />
    public partial class disponibilidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_DISPONIBILIDADE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateOnly>(type: "date", nullable: true),
                    Hora = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DISPONIBILIDADE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_MUSICO_DISPONIBILIDADE",
                columns: table => new
                {
                    MusicoId = table.Column<int>(type: "int", nullable: false),
                    DisponibilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MUSICO_DISPONIBILIDADE", x => new { x.MusicoId, x.DisponibilidadeId });
                    table.ForeignKey(
                        name: "FK_TB_MUSICO_DISPONIBILIDADE_TB_DISPONIBILIDADE_DisponibilidadeId",
                        column: x => x.DisponibilidadeId,
                        principalTable: "TB_DISPONIBILIDADE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_MUSICO_DISPONIBILIDADE_TB_MUSICOS_MusicoId",
                        column: x => x.MusicoId,
                        principalTable: "TB_MUSICOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_DISPONIBILIDADE",
                columns: new[] { "Id", "Data", "Hora" },
                values: new object[,]
                {
                    { 1, new DateOnly(2000, 5, 15), new TimeOnly(14, 20, 0) },
                    { 2, new DateOnly(2000, 5, 15), new TimeOnly(19, 20, 0) }
                });

            migrationBuilder.InsertData(
                table: "TB_MUSICO_DISPONIBILIDADE",
                columns: new[] { "DisponibilidadeId", "MusicoId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_MUSICO_DISPONIBILIDADE_DisponibilidadeId",
                table: "TB_MUSICO_DISPONIBILIDADE",
                column: "DisponibilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_MUSICO_DISPONIBILIDADE");

            migrationBuilder.DropTable(
                name: "TB_DISPONIBILIDADE");
        }
    }
}
