using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JSPacientesAPI.Data.Models;

public class JSPaciente
{
    [Key]
    public int JSPacienteID { get; set; }

    [Required(ErrorMessage = "El Nombre es obligatorio")]
    public string? JSNombre { get; set; }
    [Required(ErrorMessage = "El Apellido es obligatorio")]
    public string? JSApellido { get; set; }
    [Required(ErrorMessage = "La descripcion de la enfermedad es obligatorio")]
    public string? JSEnfermedad { get; set; }

    [Required(ErrorMessage = "El DNI debe tener exactamente 10 números.")]
    public string? JSDNI { get; set; }

    public ICollection<JSCategoria>? JSCategoria { get; set; }
}
