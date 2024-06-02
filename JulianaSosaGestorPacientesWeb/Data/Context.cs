using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JulianaSosaGestorPacientesWeb.Models;

namespace JulianaSosaGestorPacientesWeb.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<JulianaSosaGestorPacientesWeb.Models.JSPaciente> JSPaciente { get; set; } = default!;
        public DbSet<JulianaSosaGestorPacientesWeb.Models.JSCategoria> JSCategoria { get; set; } = default!;
    }
}
