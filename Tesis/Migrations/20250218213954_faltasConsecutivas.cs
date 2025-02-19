using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tesis.Migrations
{
    /// <inheritdoc />
    public partial class faltasConsecutivas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FaltasConsecutivas",
                table: "Asistencias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaltasConsecutivas",
                table: "Asistencias");
        }
    }
}
