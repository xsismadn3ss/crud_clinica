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
    public class AlergiasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlergiasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alergias
        public async Task<IActionResult> Index()
        {
              return _context.Alergia != null ? 
                          View(await _context.Alergia.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Alergia'  is null.");
        }

        // GET: Alergias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Alergia == null)
            {
                return NotFound();
            }

            var alergia = await _context.Alergia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alergia == null)
            {
                return NotFound();
            }

            return View(alergia);
        }

        // GET: Alergias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alergias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,alergia")] Alergia alergia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alergia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alergia);
        }

        // GET: Alergias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Alergia == null)
            {
                return NotFound();
            }

            var alergia = await _context.Alergia.FindAsync(id);
            if (alergia == null)
            {
                return NotFound();
            }
            return View(alergia);
        }

        // POST: Alergias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,alergia")] Alergia alergia)
        {
            if (id != alergia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alergia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlergiaExists(alergia.Id))
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
            return View(alergia);
        }

        // GET: Alergias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Alergia == null)
            {
                return NotFound();
            }

            var alergia = await _context.Alergia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alergia == null)
            {
                return NotFound();
            }

            return View(alergia);
        }

        // POST: Alergias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Alergia == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Alergia'  is null.");
            }
            var alergia = await _context.Alergia.FindAsync(id);
            if (alergia != null)
            {
                _context.Alergia.Remove(alergia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlergiaExists(int id)
        {
          return (_context.Alergia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
