using Microsoft.EntityFrameworkCore;
using JSPacientesAPI.Data;
using JSPacientesAPI.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace JSPacientesAPI.Controllers;

public static class JSPacienteEndpoints
{
    public static void MapJSPacienteEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/JSPaciente").WithTags(nameof(JSPaciente));

        group.MapGet("/", async (JSPacientesContext db) =>
        {
            return await db.JSPaciente.ToListAsync();
        })
        .WithName("GetAllJSPacientes")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<JSPaciente>, NotFound>> (int JSPacienteID, JSPacientesContext db) =>
        {
            return await db.JSPaciente.AsNoTracking()
                .FirstOrDefaultAsync(model => model.JSPacienteID == JSPacienteID)
                is JSPaciente model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetJSPacienteById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int JSPacienteID, JSPaciente jSPaciente, JSPacientesContext db) =>
        {
            var affected = await db.JSPaciente
                .Where(model => model.JSPacienteID == JSPacienteID)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.JSPacienteID, jSPaciente.JSPacienteID)
                    .SetProperty(m => m.JSNombre, jSPaciente.JSNombre)
                    .SetProperty(m => m.JSApellido, jSPaciente.JSApellido)
                    .SetProperty(m => m.JSEnfermedad, jSPaciente.JSEnfermedad)
                    .SetProperty(m => m.JSDNI, jSPaciente.JSDNI)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateJSPaciente")
        .WithOpenApi();

        group.MapPost("/", async (JSPaciente jSPaciente, JSPacientesContext db) =>
        {
            db.JSPaciente.Add(jSPaciente);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/JSPaciente/{jSPaciente.JSPacienteID}",jSPaciente);
        })
        .WithName("CreateJSPaciente")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int JSPacienteID, JSPacientesContext db) =>
        {
            var affected = await db.JSPaciente
                .Where(model => model.JSPacienteID == JSPacienteID)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteJSPaciente")
        .WithOpenApi();
    }
}
