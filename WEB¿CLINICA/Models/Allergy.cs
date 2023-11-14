using CLINICA_CRUD.Models;

namespace WEB_CLINICA.Models
{
    public class Allergy
    {
        public int Id { get; set; }

        public string? alergia { get; set; }

        public virtual ICollection<RegistroMedico> RegistroMedicos { get; set; } = new List<RegistroMedico>();
    }
}
