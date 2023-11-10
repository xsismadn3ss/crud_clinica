using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_CLINICA.Data.Migrations
{
    /// <inheritdoc />
    public partial class cambiar_citar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "IdPaciente",
            //    table: "Cita");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "IdPaciente",
            //    table: "Cita",
            //    type: "int",
            //    nullable: true);
        }
    }
}
