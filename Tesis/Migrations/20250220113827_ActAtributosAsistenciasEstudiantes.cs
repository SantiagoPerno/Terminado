using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tesis.Migrations
{
    /// <inheritdoc />
    public partial class ActAtributosAsistenciasEstudiantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ausente",
                table: "Asistencias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AusenteInjustificado",
                table: "Asistencias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AusenteJustificado",
                table: "Asistencias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Tardanza",
                table: "Asistencias",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ausente",
                table: "Asistencias");

            migrationBuilder.DropColumn(
                name: "AusenteInjustificado",
                table: "Asistencias");

            migrationBuilder.DropColumn(
                name: "AusenteJustificado",
                table: "Asistencias");

            migrationBuilder.DropColumn(
                name: "Tardanza",
                table: "Asistencias");
        }
    }
}
