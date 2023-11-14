using CLINICA_CRUD.Models;
using System.ComponentModel.DataAnnotations;

namespace WEB_CLINICA.Models
{
    public class Disability
    {
        public int Id { get; set; }

        [Display(Name = "Discapacidad")]
        public string? discapacidad { get; set; }

        public virtual ICollection<RegistroMedico> RegistroMedicos { get; set; } = new List<RegistroMedico>();
    }
}
