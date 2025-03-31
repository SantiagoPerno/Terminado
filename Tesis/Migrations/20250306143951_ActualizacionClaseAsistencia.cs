using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tesis.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionClaseAsistencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tardanza",
                table: "Asistencias",
                newName: "TardanzaUncuarto");

            migrationBuilder.RenameColumn(
                name: "Ausente",
                table: "Asistencias",
                newName: "TardanzaMedia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TardanzaUncuarto",
                table: "Asistencias",
                newName: "Tardanza");

            migrationBuilder.RenameColumn(
                name: "TardanzaMedia",
                table: "Asistencias",
                newName: "Ausente");
        }
    }
}
