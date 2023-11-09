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
    public class DiscapacidadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiscapacidadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Discapacidads
        public async Task<IActionResult> Index()
        {
              return _context.Discapacidad != null ? 
                          View(await _context.Discapacidad.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Discapacidad'  is null.");
        }

        // GET: Discapacidads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Discapacidad == null)
            {
                return NotFound();
            }

            var discapacidad = await _context.Discapacidad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (discapacidad == null)
            {
                return NotFound();
            }

            return View(discapacidad);
        }

        // GET: Discapacidads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Discapacidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,discapacidad")] Discapacidad discapacidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(discapacidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(discapacidad);
        }

        // GET: Discapacidads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Discapacidad == null)
            {
                return NotFound();
            }

            var discapacidad = await _context.Discapacidad.FindAsync(id);
            if (discapacidad == null)
            {
                return NotFound();
            }
            return View(discapacidad);
        }

        // POST: Discapacidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,discapacidad")] Discapacidad discapacidad)
        {
            if (id != discapacidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discapacidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscapacidadExists(discapacidad.Id))
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
            return View(discapacidad);
        }

        // GET: Discapacidads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Discapacidad == null)
            {
                return NotFound();
            }

            var discapacidad = await _context.Discapacidad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (discapacidad == null)
            {
                return NotFound();
            }

            return View(discapacidad);
        }

        // POST: Discapacidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Discapacidad == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Discapacidad'  is null.");
            }
            var discapacidad = await _context.Discapacidad.FindAsync(id);
            if (discapacidad != null)
            {
                _context.Discapacidad.Remove(discapacidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiscapacidadExists(int id)
        {
          return (_context.Discapacidad?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
