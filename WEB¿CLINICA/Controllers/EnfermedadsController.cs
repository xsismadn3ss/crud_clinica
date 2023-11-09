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
    public class EnfermedadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnfermedadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enfermedads
        public async Task<IActionResult> Index()
        {
              return _context.Enfermedad != null ? 
                          View(await _context.Enfermedad.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Enfermedad'  is null.");
        }

        // GET: Enfermedads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Enfermedad == null)
            {
                return NotFound();
            }

            var enfermedad = await _context.Enfermedad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enfermedad == null)
            {
                return NotFound();
            }

            return View(enfermedad);
        }

        // GET: Enfermedads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enfermedads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,enfermedad")] Enfermedad enfermedad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enfermedad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enfermedad);
        }

        // GET: Enfermedads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Enfermedad == null)
            {
                return NotFound();
            }

            var enfermedad = await _context.Enfermedad.FindAsync(id);
            if (enfermedad == null)
            {
                return NotFound();
            }
            return View(enfermedad);
        }

        // POST: Enfermedads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,enfermedad")] Enfermedad enfermedad)
        {
            if (id != enfermedad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enfermedad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnfermedadExists(enfermedad.Id))
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
            return View(enfermedad);
        }

        // GET: Enfermedads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Enfermedad == null)
            {
                return NotFound();
            }

            var enfermedad = await _context.Enfermedad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enfermedad == null)
            {
                return NotFound();
            }

            return View(enfermedad);
        }

        // POST: Enfermedads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Enfermedad == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Enfermedad'  is null.");
            }
            var enfermedad = await _context.Enfermedad.FindAsync(id);
            if (enfermedad != null)
            {
                _context.Enfermedad.Remove(enfermedad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnfermedadExists(int id)
        {
          return (_context.Enfermedad?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
