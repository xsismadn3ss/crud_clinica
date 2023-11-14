using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CLINICA_CRUD.Models;
using WEB_CLINICA.Data;

namespace WEB_CLINICA.Controllers
{
    public class RegistroMedicoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistroMedicoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegistroMedicoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RegistroMedico.Include(r => r.FKalergia).Include(r => r.FKdiscapacidad).Include(r => r.FKenfermedad).Include(r => r.FKpaciente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RegistroMedicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RegistroMedico == null)
            {
                return NotFound();
            }

            var registroMedico = await _context.RegistroMedico
                .Include(r => r.FKalergia)
                .Include(r => r.FKdiscapacidad)
                .Include(r => r.FKenfermedad)
                .Include(r => r.FKpaciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroMedico == null)
            {
                return NotFound();
            }

            return View(registroMedico);
        }

        // GET: RegistroMedicoes/Create
        public IActionResult Create()
        {
            ViewData["FKalergiaId"] = new SelectList(_context.Allergy, "Id", "alergia");
            ViewData["FKdiscapacidadId"] = new SelectList(_context.Disability, "Id", "discapacidad");
            ViewData["FKenfermedadId"] = new SelectList(_context.Disease, "Id", "enfermedad");
            ViewData["FKpacienteId"] = new SelectList(_context.Paciente, "Id", "Id");
            return View();
        }

        // POST: RegistroMedicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tratamiento,FKpacienteId,FKalergiaId,FKdiscapacidadId,FKenfermedadId")] RegistroMedico registroMedico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroMedico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FKalergiaId"] = new SelectList(_context.Allergy, "Id", "alergia", registroMedico.FKalergiaId);
            ViewData["FKdiscapacidadId"] = new SelectList(_context.Disability, "Id", "discapacidad", registroMedico.FKdiscapacidadId);
            ViewData["FKenfermedadId"] = new SelectList(_context.Disease, "Id", "enfermedad", registroMedico.FKenfermedadId);
            ViewData["FKpacienteId"] = new SelectList(_context.Paciente, "Id", "Id", registroMedico.FKpacienteId);
            return View(registroMedico);
        }

        // GET: RegistroMedicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RegistroMedico == null)
            {
                return NotFound();
            }

            var registroMedico = await _context.RegistroMedico.FindAsync(id);
            if (registroMedico == null)
            {
                return NotFound();
            }
            ViewData["FKalergiaId"] = new SelectList(_context.Allergy, "Id", "alergia", registroMedico.FKalergiaId);
            ViewData["FKdiscapacidadId"] = new SelectList(_context.Disability, "Id", "discapacidad", registroMedico.FKdiscapacidadId);
            ViewData["FKenfermedadId"] = new SelectList(_context.Disease, "Id", "enfermedad", registroMedico.FKenfermedadId);
            ViewData["FKpacienteId"] = new SelectList(_context.Paciente, "Id", "Id", registroMedico.FKpacienteId);
            return View(registroMedico);
        }

        // POST: RegistroMedicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tratamiento,FKpacienteId,FKalergiaId,FKdiscapacidadId,FKenfermedadId")] RegistroMedico registroMedico)
        {
            if (id != registroMedico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroMedico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroMedicoExists(registroMedico.Id))
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
            ViewData["FKalergiaId"] = new SelectList(_context.Allergy, "Id", "alergia", registroMedico.FKalergiaId);
            ViewData["FKdiscapacidadId"] = new SelectList(_context.Disability, "Id", "discapacidad", registroMedico.FKdiscapacidadId);
            ViewData["FKenfermedadId"] = new SelectList(_context.Disease, "Id", "enfermedad", registroMedico.FKenfermedadId);
            ViewData["FKpacienteId"] = new SelectList(_context.Paciente, "Id", "Id", registroMedico.FKpacienteId);
            return View(registroMedico);
        }

        // GET: RegistroMedicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RegistroMedico == null)
            {
                return NotFound();
            }

            var registroMedico = await _context.RegistroMedico
                .Include(r => r.FKalergia)
                .Include(r => r.FKdiscapacidad)
                .Include(r => r.FKenfermedad)
                .Include(r => r.FKpaciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroMedico == null)
            {
                return NotFound();
            }

            return View(registroMedico);
        }

        // POST: RegistroMedicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RegistroMedico == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RegistroMedico'  is null.");
            }
            var registroMedico = await _context.RegistroMedico.FindAsync(id);
            if (registroMedico != null)
            {
                _context.RegistroMedico.Remove(registroMedico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroMedicoExists(int id)
        {
          return (_context.RegistroMedico?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
