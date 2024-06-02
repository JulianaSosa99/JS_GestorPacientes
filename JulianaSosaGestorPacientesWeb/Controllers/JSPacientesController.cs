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
    public class JSPacientesController : Controller
    {
        private readonly Context _context;

        public JSPacientesController(Context context)
        {
            _context = context;
        }

        // GET: JSPacientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.JSPaciente.ToListAsync());
        }

        // GET: JSPacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jSPaciente = await _context.JSPaciente
                .FirstOrDefaultAsync(m => m.JSPacienteID == id);
            if (jSPaciente == null)
            {
                return NotFound();
            }

            return View(jSPaciente);
        }

        // GET: JSPacientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JSPacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JSPacienteID,JSNombre,JSApellido,JSEnfermedad,JSDNI")] JSPaciente jSPaciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jSPaciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jSPaciente);
        }

        // GET: JSPacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jSPaciente = await _context.JSPaciente.FindAsync(id);
            if (jSPaciente == null)
            {
                return NotFound();
            }
            return View(jSPaciente);
        }

        // POST: JSPacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JSPacienteID,JSNombre,JSApellido,JSEnfermedad,JSDNI")] JSPaciente jSPaciente)
        {
            if (id != jSPaciente.JSPacienteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jSPaciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JSPacienteExists(jSPaciente.JSPacienteID))
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
            return View(jSPaciente);
        }

        // GET: JSPacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jSPaciente = await _context.JSPaciente
                .FirstOrDefaultAsync(m => m.JSPacienteID == id);
            if (jSPaciente == null)
            {
                return NotFound();
            }

            return View(jSPaciente);
        }

        // POST: JSPacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jSPaciente = await _context.JSPaciente.FindAsync(id);
            if (jSPaciente != null)
            {
                _context.JSPaciente.Remove(jSPaciente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JSPacienteExists(int id)
        {
            return _context.JSPaciente.Any(e => e.JSPacienteID == id);
        }
    }
}
