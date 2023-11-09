using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_CLINICA.Data.Migrations
{
    /// <inheritdoc />
    public partial class createmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alergia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alergia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alergia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discapacidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discapacidad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discapacidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enfermedad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    enfermedad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermedad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apelido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreResponsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoResponsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: true),
                    TelefonoResponsable = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: true),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdPacienteNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cita_Paciente_IdPacienteNavigationId",
                        column: x => x.IdPacienteNavigationId,
                        principalTable: "Paciente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RegistroMedico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: true),
                    IdDiscapacidad = table.Column<int>(type: "int", nullable: true),
                    IdAlergia = table.Column<int>(type: "int", nullable: true),
                    IdEnfermedad = table.Column<int>(type: "int", nullable: true),
                    Tratamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FKpacienteId = table.Column<int>(type: "int", nullable: true),
                    FKalergiaId = table.Column<int>(type: "int", nullable: true),
                    FKdiscapacidadId = table.Column<int>(type: "int", nullable: true),
                    FKenfermedadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroMedico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroMedico_Alergia_FKalergiaId",
                        column: x => x.FKalergiaId,
                        principalTable: "Alergia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistroMedico_Discapacidad_FKdiscapacidadId",
                        column: x => x.FKdiscapacidadId,
                        principalTable: "Discapacidad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistroMedico_Enfermedad_FKenfermedadId",
                        column: x => x.FKenfermedadId,
                        principalTable: "Enfermedad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistroMedico_Paciente_FKpacienteId",
                        column: x => x.FKpacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cita_IdPacienteNavigationId",
                table: "Cita",
                column: "IdPacienteNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroMedico_FKalergiaId",
                table: "RegistroMedico",
                column: "FKalergiaId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroMedico_FKdiscapacidadId",
                table: "RegistroMedico",
                column: "FKdiscapacidadId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroMedico_FKenfermedadId",
                table: "RegistroMedico",
                column: "FKenfermedadId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroMedico_FKpacienteId",
                table: "RegistroMedico",
                column: "FKpacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "RegistroMedico");

            migrationBuilder.DropTable(
                name: "Alergia");

            migrationBuilder.DropTable(
                name: "Discapacidad");

            migrationBuilder.DropTable(
                name: "Enfermedad");

            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
