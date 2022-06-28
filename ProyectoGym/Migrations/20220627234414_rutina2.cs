using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoGym.Migrations
{
    public partial class rutina2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rutina_Usuarios_UsuarioId",
                table: "Rutina");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rutina",
                table: "Rutina");

            migrationBuilder.DropIndex(
                name: "IX_Rutina_UsuarioId",
                table: "Rutina");

            migrationBuilder.RenameTable(
                name: "Rutina",
                newName: "Rutinas");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Rutinas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rutinas",
                table: "Rutinas",
                column: "RutinaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Rutinas",
                table: "Rutinas");

            migrationBuilder.RenameTable(
                name: "Rutinas",
                newName: "Rutina");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Rutina",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rutina",
                table: "Rutina",
                column: "RutinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rutina_UsuarioId",
                table: "Rutina",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rutina_Usuarios_UsuarioId",
                table: "Rutina",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
