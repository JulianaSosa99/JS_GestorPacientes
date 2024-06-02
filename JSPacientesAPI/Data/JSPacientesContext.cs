using System;
using System.Collections.Generic;
using JSPacientesAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JSPacientesAPI.Data;

public partial class JSPacientesContext : DbContext
{
    public JSPacientesContext()
    {
    }

    public JSPacientesContext(DbContextOptions<JSPacientesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<JSCategoria> JSCategoria { get; set; }

    public virtual DbSet<JSPaciente> JSPaciente { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=JSPacientes;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JSCategoria>(entity =>
        {
            entity.HasKey(e => e.JSCategoriaID);

            entity.ToTable("JSCategoria");

            entity.HasIndex(e => e.JSPacienteID, "IX_JSCategoria_JSPacienteID");

            entity.Property(e => e.JSCategoriaID).HasColumnName("JSCategoriaID");
            entity.Property(e => e.JSFechaIngreso).HasColumnName("JSFechaIngreso");
            entity.Property(e => e.JSGravedad).HasColumnName("JSGravedad");
            entity.Property(e => e.JSPacienteID).HasColumnName("JSPacienteID");

            entity.HasOne(d => d.JSPaciente).WithMany(p => p.JSCategoria).HasForeignKey(d => d.JSPacienteID);
        });

        modelBuilder.Entity<JSPaciente>(entity =>
        {
            entity.ToTable("JSPaciente");

            entity.Property(e => e.JSPacienteID).HasColumnName("JSPacienteID");
            entity.Property(e => e.JSApellido).HasColumnName("JSApellido");
            entity.Property(e => e.JSDNI).HasColumnName("JSDNI");
            entity.Property(e => e.JSEnfermedad).HasColumnName("JSEnfermedad");
            entity.Property(e => e.JSNombre).HasColumnName("JSNombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
