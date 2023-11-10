using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CLINICA_CRUD.Models;

public partial class Cita
{
    public int Id { get; set; }

    public string? Motivo { get; set; }

    public DateTime? Fecha { get; set; }

    [Display(Name = "ID de paciente")]public int? FKpacienteId { get; set; }
    public virtual Paciente? FKpaciente { get; set; }
}
