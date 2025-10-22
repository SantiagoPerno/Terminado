using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tesis.Migrations
{
    /// <inheritdoc />
    public partial class LegajoEstudiante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TieneCUS",
                table: "Estudiantes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneConstanciaDomicilio",
                table: "Estudiantes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneDni",
                table: "Estudiantes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneDniMadre",
                table: "Estudiantes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneDniPadre",
                table: "Estudiantes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneDniTutor",
                table: "Estudiantes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneISA",
                table: "Estudiantes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TienePartidaNacimiento",
                table: "Estudiantes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TieneCUS",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "TieneConstanciaDomicilio",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "TieneDni",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "TieneDniMadre",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "TieneDniPadre",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "TieneDniTutor",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "TieneISA",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "TienePartidaNacimiento",
                table: "Estudiantes");
        }
    }
}
