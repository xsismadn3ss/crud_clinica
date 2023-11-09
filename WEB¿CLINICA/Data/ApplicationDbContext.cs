using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CLINICA_CRUD.Models;

namespace WEB_CLINICA.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CLINICA_CRUD.Models.Alergia> Alergia { get; set; } = default!;
        public DbSet<CLINICA_CRUD.Models.Cita> Cita { get; set; } = default!;
        public DbSet<CLINICA_CRUD.Models.Discapacidad> Discapacidad { get; set; } = default!;
        public DbSet<CLINICA_CRUD.Models.Enfermedad> Enfermedad { get; set; } = default!;
        public DbSet<CLINICA_CRUD.Models.Paciente> Paciente { get; set; } = default!;
        public DbSet<CLINICA_CRUD.Models.RegistroMedico> RegistroMedico { get; set; } = default!;
    }
}