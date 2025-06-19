using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAM_MB_API.Migrations
{
    /// <inheritdoc />
    public partial class Usuario_Musico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Endereco = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Senha = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Bio = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FotoPerfil = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TB_MUSICOS",
                keyColumn: "Id",
                keyValue: 1,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Bio", "DataCriacao", "Email", "Endereco", "FotoPerfil", "Nome", "Senha", "Telefone" },
                values: new object[] { 1, "Guitarrista solo", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jeff@email.com", "Rua Teste", null, "Jefferson", "123456", "11999999999" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_MUSICOS_UsuarioId",
                table: "TB_MUSICOS",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_MUSICOS_Usuario_UsuarioId",
                table: "TB_MUSICOS",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_MUSICOS_Usuario_UsuarioId",
                table: "TB_MUSICOS");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_TB_MUSICOS_UsuarioId",
                table: "TB_MUSICOS");

            migrationBuilder.UpdateData(
                table: "TB_MUSICOS",
                keyColumn: "Id",
                keyValue: 1,
                column: "UsuarioId",
                value: 0);
        }
    }
}
