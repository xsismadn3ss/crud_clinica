using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_CLINICA.Data.Migrations
{
    /// <inheritdoc />
    public partial class finish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
            name: "IdPacienteNavigationId",
            table: "Cita",
            type: "int",
            nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
