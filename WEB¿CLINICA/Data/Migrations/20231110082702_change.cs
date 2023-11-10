using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_CLINICA.Data.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAlergia",
                table: "RegistroMedico");

            migrationBuilder.DropColumn(
                name: "IdDiscapacidad",
                table: "RegistroMedico");

            migrationBuilder.DropColumn(
                name: "IdEnfermedad",
                table: "RegistroMedico");

            migrationBuilder.DropColumn(
                name: "FKpacienteId",
                table: "RegistroMedico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAlergia",
                table: "RegistroMedico",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdDiscapacidad",
                table: "RegistroMedico",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEnfermedad",
                table: "RegistroMedico",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FKpacienteId",
                table: "RegistroMedico",
                type: "int",
                nullable: true);
        }
    }
}
