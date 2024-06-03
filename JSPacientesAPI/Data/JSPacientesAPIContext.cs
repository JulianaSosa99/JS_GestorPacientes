using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JSPacientesAPI.Data.Models;

namespace JSPacientesAPI.Data
{
    public class JSPacientesAPIContext : DbContext
    {
        public JSPacientesAPIContext (DbContextOptions<JSPacientesAPIContext> options)
            : base(options)
        {
        }

        public DbSet<JSPacientesAPI.Data.Models.JSPaciente> JSPaciente { get; set; } = default!;
        public DbSet<JSPacientesAPI.Data.Models.JSCategoria> JSCategoria { get; set; } = default!;
    }
}
