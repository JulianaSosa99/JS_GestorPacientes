using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JulianaSosaGestorPacientesWeb.Data;
using JulianaSosaGestorPacientesWeb.Models;

namespace JulianaSosaGestorPacientesWeb.Controllers
{
    public class JSCategoriasController : Controller
    {
        private readonly Context _context;

        public JSCategoriasController(Context context)
        {
            _context = context;
        }

        // GET: JSCategorias
        public async Task<IActionResult> Index()
        {
            var context = _context.JSCategoria.Include(j => j.JSPaciente);
            return View(await context.ToListAsync());
        }

        // GET: JSCategorias/Details/5
        public async Task<IActionResult> JSDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jSCategoria = await _context.JSCategoria
                .Include(j => j.JSPaciente)
                .FirstOrDefaultAsync(m => m.JSCategoriaID == id);
            if (jSCategoria == null)
            {
                return NotFound();
            }

            return View(jSCategoria);
        }

        // GET: JSCategorias/Create
        public IActionResult JSCreate()
        {
            ViewData["JSPacienteID"] = new SelectList(_context.JSPaciente, "JSPacienteID", "JSApellido");
            return View();
        }

        // POST: JSCategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> JSCreate([Bind("JSCategoriaID,JSGravedad,JSFechaIngreso,JSPacienteID")] JSCategoria jSCategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jSCategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JSPacienteID"] = new SelectList(_context.JSPaciente, "JSPacienteID", "JSApellido", jSCategoria.JSPacienteID);
            return View(jSCategoria);
        }

        // GET: JSCategorias/Edit/5
        public async Task<IActionResult> JSEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jSCategoria = await _context.JSCategoria.FindAsync(id);
            if (jSCategoria == null)
            {
                return NotFound();
            }
            ViewData["JSPacienteID"] = new SelectList(_context.JSPaciente, "JSPacienteID", "JSApellido", jSCategoria.JSPacienteID);
            return View(jSCategoria);
        }

        // POST: JSCategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> JSEdit(int id, [Bind("JSCategoriaID,JSGravedad,JSFechaIngreso,JSPacienteID")] JSCategoria jSCategoria)
        {
            if (id != jSCategoria.JSCategoriaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jSCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JSCategoriaExists(jSCategoria.JSCategoriaID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["JSPacienteID"] = new SelectList(_context.JSPaciente, "JSPacienteID", "JSApellido", jSCategoria.JSPacienteID);
            return View(jSCategoria);
        }

        // GET: JSCategorias/Delete/5
        public async Task<IActionResult> JSDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jSCategoria = await _context.JSCategoria
                .Include(j => j.JSPaciente)
                .FirstOrDefaultAsync(m => m.JSCategoriaID == id);
            if (jSCategoria == null)
            {
                return NotFound();
            }

            return View(jSCategoria);
        }

        // POST: JSCategorias/Delete/5
        [HttpPost, ActionName("JSDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jSCategoria = await _context.JSCategoria.FindAsync(id);
            if (jSCategoria != null)
            {
                _context.JSCategoria.Remove(jSCategoria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JSCategoriaExists(int id)
        {
            return _context.JSCategoria.Any(e => e.JSCategoriaID == id);
        }
    }
}
