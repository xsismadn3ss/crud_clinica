using System;
using System.Collections.Generic;

namespace CLINICA_CRUD.Models;

public partial class Cita
{
    public int Id { get; set; }

    public int? IdPaciente { get; set; }

    public string? Motivo { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Paciente? IdPacienteNavigation { get; set; }
}
