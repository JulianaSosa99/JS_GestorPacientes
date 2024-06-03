using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSGestionPacientesMAUI.Models
{

    public class JSPaciente
    {
        public int jsPacienteID { get; set; }
        public string? jsNombre { get; set; }
        public string? jsApellido { get; set; }
        public string? jsEnfermedad { get; set; }
        public string? jsdni { get; set; }
        public object? jsCategoria { get; set; }
    }

}
