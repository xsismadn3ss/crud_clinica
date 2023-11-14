using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CLINICA_CRUD.Models;
using WEB_CLINICA.Models;

namespace WEB_CLINICA.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CLINICA_CRUD.Models.Cita> Cita { get; set; } = default!;
        public DbSet<CLINICA_CRUD.Models.Paciente> Paciente { get; set; } = default!;
        public DbSet<CLINICA_CRUD.Models.RegistroMedico> RegistroMedico { get; set; } = default!;
        public DbSet<WEB_CLINICA.Models.Allergy> Allergy { get; set; } = default!;
        public DbSet<WEB_CLINICA.Models.Disability> Disability { get; set; } = default!;
        public DbSet<WEB_CLINICA.Models.Disease> Disease { get; set; } = default!;
    }
}