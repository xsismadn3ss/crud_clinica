using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CLINICA_CRUD.Models;

public partial class Paciente
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    [Display(Name = "Apellido")]
    public string? Apelido { get; set; }

    public int? Edad { get; set; }

    public string? Sexo { get; set; }

    [Display(Name = "Nombre")]
    public string? NombreResponsable { get; set; }

    [Display(Name = "Apellido")]
    public string? ApellidoResponsable { get; set; }

    public int? Telefono { get; set; }

    [Display(Name = "Telefono")]
    public int? TelefonoResponsable { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<RegistroMedico> RegistroMedicos { get; set; } = new List<RegistroMedico>();
}
