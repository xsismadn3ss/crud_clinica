using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CLINICA_CRUD.Models;

public partial class Discapacidad
{
    public int Id { get; set; }

    [Display(Name = "Discapacidad")]
    public string? discapacidad { get; set; }

    public virtual ICollection<RegistroMedico> RegistroMedicos { get; set; } = new List<RegistroMedico>();
}
