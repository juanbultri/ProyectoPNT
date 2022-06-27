using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoGym.Migrations
{
    public partial class Socios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Plan",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Usuarios",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SocioId",
                table: "Actividades",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_Usuarios_SocioId",
                table: "Actividades");

            migrationBuilder.DropIndex(
                name: "IX_Actividades_SocioId",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "Plan",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "SocioId",
                table: "Actividades");
        }
    }
}
