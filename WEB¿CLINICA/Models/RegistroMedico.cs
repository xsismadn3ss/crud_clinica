using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WEB_CLINICA.Models;

namespace CLINICA_CRUD.Models;

public partial class RegistroMedico
{
    public int Id { get; set; }

   /* [Display(Name = "ID")] public int? IdPaciente { get; set; }

   public int? IdDiscapacidad { get; set; }

    public int? IdAlergia { get; set; }

    public int? IdEnfermedad { get; set; }*/


    public string? Tratamiento { get; set; }

    [Display(Name ="Paciente")] public int? FKpacienteId { get; set; }
    [Display(Name = "Alergia")] public int? FKalergiaId { get; set; }
    [Display(Name = "Discapacidad")] public int? FKdiscapacidadId { get; set; }
    [Display(Name = "Enfermedad")] public int? FKenfermedadId {  get; set; }

    [Display(Name = "Paciente")] public virtual Paciente? FKpaciente { get; set; }

    [Display(Name = "Alergia")] public virtual Allergy? FKalergia { get; set; }

    [Display(Name = "Discapacidad")] public virtual Disability? FKdiscapacidad { get; set; }

    [Display(Name = "Enfermedad")] public virtual Disease? FKenfermedad { get; set; }

}
