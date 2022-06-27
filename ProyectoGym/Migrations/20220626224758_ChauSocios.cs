using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoGym.Migrations
{
    public partial class ChauSocios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_Usuarios_SocioId",
                table: "Actividades");

            migrationBuilder.DropIndex(
                name: "IX_Actividades_SocioId",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "SocioId",
                table: "Actividades");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SocioId",
                table: "Actividades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_SocioId",
                table: "Actividades",
                column: "SocioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_Usuarios_SocioId",
                table: "Actividades",
                column: "SocioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
