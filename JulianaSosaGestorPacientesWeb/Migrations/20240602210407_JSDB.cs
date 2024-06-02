using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JulianaSosaGestorPacientesWeb.Migrations
{
    /// <inheritdoc />
    public partial class JSDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JSPaciente",
                columns: table => new
                {
                    JSPacienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JSNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JSApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JSEnfermedad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JSDNI = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JSPaciente", x => x.JSPacienteID);
                });

            migrationBuilder.CreateTable(
                name: "JSCategoria",
                columns: table => new
                {
                    JSCategoriaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JSGravedad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JSFechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JSPacienteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JSCategoria", x => x.JSCategoriaID);
                    table.ForeignKey(
                        name: "FK_JSCategoria_JSPaciente_JSPacienteID",
                        column: x => x.JSPacienteID,
                        principalTable: "JSPaciente",
                        principalColumn: "JSPacienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JSCategoria_JSPacienteID",
                table: "JSCategoria",
                column: "JSPacienteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JSCategoria");

            migrationBuilder.DropTable(
                name: "JSPaciente");
        }
    }
}
