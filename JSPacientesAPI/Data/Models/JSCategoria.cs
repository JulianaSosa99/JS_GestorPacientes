using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JSPacientesAPI.Data.Models;

public partial class JSCategoria
{
    [Key]
    public int JSCategoriaID { get; set; }

    [Required(ErrorMessage = "Debe ingresarla gravedad")]
    public string? JSGravedad { get; set; }


    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime JSFechaIngreso { get; set; }

    // Clave foránea
    public int JSPacienteID { get; set; }

    // Propiedad de navegación
    public JSPaciente? JSPaciente { get; set; }
}
