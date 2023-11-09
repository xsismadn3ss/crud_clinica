using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CLINICA_CRUD.Models;

public partial class Enfermedad
{
    public int Id { get; set; }

    [Display(Name ="Enfermedad")]
    public string? enfermedad { get; set; }

    public virtual ICollection<RegistroMedico> RegistroMedicos { get; set; } = new List<RegistroMedico>();
}
