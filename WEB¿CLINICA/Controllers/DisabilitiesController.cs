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
    public class DisabilitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DisabilitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Disabilities
        public async Task<IActionResult> Index()
        {
              return _context.Disability != null ? 
                          View(await _context.Disability.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Disability'  is null.");
        }

        // GET: Disabilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Disability == null)
            {
                return NotFound();
            }

            var disability = await _context.Disability
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disability == null)
            {
                return NotFound();
            }

            return View(disability);
        }

        // GET: Disabilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Disabilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,discapacidad")] Disability disability)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disability);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disability);
        }

        // GET: Disabilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Disability == null)
            {
                return NotFound();
            }

            var disability = await _context.Disability.FindAsync(id);
            if (disability == null)
            {
                return NotFound();
            }
            return View(disability);
        }

        // POST: Disabilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,discapacidad")] Disability disability)
        {
            if (id != disability.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disability);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisabilityExists(disability.Id))
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
            return View(disability);
        }

        // GET: Disabilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Disability == null)
            {
                return NotFound();
            }

            var disability = await _context.Disability
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disability == null)
            {
                return NotFound();
            }

            return View(disability);
        }

        // POST: Disabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Disability == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Disability'  is null.");
            }
            var disability = await _context.Disability.FindAsync(id);
            if (disability != null)
            {
                _context.Disability.Remove(disability);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisabilityExists(int id)
        {
          return (_context.Disability?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
