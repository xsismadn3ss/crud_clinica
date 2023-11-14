using CLINICA_CRUD.Models;
using System.ComponentModel.DataAnnotations;

namespace WEB_CLINICA.Models
{
    public class Disease
    {
        public int Id { get; set; }

        [Display(Name = "Enfermedad")]
        public string? enfermedad { get; set; }

        public virtual ICollection<RegistroMedico> RegistroMedicos { get; set; } = new List<RegistroMedico>();
    }
}
