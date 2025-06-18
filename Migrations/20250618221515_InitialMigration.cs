using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAM_MB_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_MUSICOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Apelido = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Cpf = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Classe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MUSICOS", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_MUSICOS",
                columns: new[] { "Id", "Apelido", "Classe", "Cpf", "UsuarioId" },
                values: new object[] { 1, "Jeff", 1, "234.234.234-23", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_MUSICOS");
        }
    }
}
