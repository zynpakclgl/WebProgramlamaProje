using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProje.Data;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class RenkController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RenkController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Renk
        public async Task<IActionResult> Index()
        {
            return View(await _context.Renk.ToListAsync());
        }

        // GET: Renk/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renk = await _context.Renk
                .FirstOrDefaultAsync(m => m.Id == id);
            if (renk == null)
            {
                return NotFound();
            }

            return View(renk);
        }

        // GET: Renk/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Renk/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RenkAd")] Renk renk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(renk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(renk);
        }

        // GET: Renk/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renk = await _context.Renk.FindAsync(id);
            if (renk == null)
            {
                return NotFound();
            }
            return View(renk);
        }

        // POST: Renk/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RenkAd")] Renk renk)
        {
            if (id != renk.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(renk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RenkExists(renk.Id))
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
            return View(renk);
        }

        // GET: Renk/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renk = await _context.Renk
                .FirstOrDefaultAsync(m => m.Id == id);
            if (renk == null)
            {
                return NotFound();
            }

            return View(renk);
        }

        // POST: Renk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var renk = await _context.Renk.FindAsync(id);
            _context.Renk.Remove(renk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RenkExists(int id)
        {
            return _context.Renk.Any(e => e.Id == id);
        }
    }
}
