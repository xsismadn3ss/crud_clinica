using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEB_CLINICA.Data;
using WEB_CLINICA.Models;

namespace WEB_CLINICA.Controllers
{
    public class AllergiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllergiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Allergies
        public async Task<IActionResult> Index()
        {
              return _context.Allergy != null ? 
                          View(await _context.Allergy.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Allergy'  is null.");
        }

        // GET: Allergies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Allergy == null)
            {
                return NotFound();
            }

            var allergy = await _context.Allergy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allergy == null)
            {
                return NotFound();
            }

            return View(allergy);
        }

        // GET: Allergies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Allergies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,alergia")] Allergy allergy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allergy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allergy);
        }

        // GET: Allergies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Allergy == null)
            {
                return NotFound();
            }

            var allergy = await _context.Allergy.FindAsync(id);
            if (allergy == null)
            {
                return NotFound();
            }
            return View(allergy);
        }

        // POST: Allergies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,alergia")] Allergy allergy)
        {
            if (id != allergy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allergy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllergyExists(allergy.Id))
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
            return View(allergy);
        }

        // GET: Allergies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Allergy == null)
            {
                return NotFound();
            }

            var allergy = await _context.Allergy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allergy == null)
            {
                return NotFound();
            }

            return View(allergy);
        }

        // POST: Allergies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Allergy == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Allergy'  is null.");
            }
            var allergy = await _context.Allergy.FindAsync(id);
            if (allergy != null)
            {
                _context.Allergy.Remove(allergy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllergyExists(int id)
        {
          return (_context.Allergy?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
