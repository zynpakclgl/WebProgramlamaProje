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
    public class KasaTipiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KasaTipiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: KasaTipi
        public async Task<IActionResult> Index()
        {
            return View(await _context.KasaTipi.ToListAsync());
        }

        // GET: KasaTipi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kasaTipi = await _context.KasaTipi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kasaTipi == null)
            {
                return NotFound();
            }

            return View(kasaTipi);
        }

        // GET: KasaTipi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KasaTipi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KasaTipiAd")] KasaTipi kasaTipi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kasaTipi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kasaTipi);
        }

        // GET: KasaTipi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kasaTipi = await _context.KasaTipi.FindAsync(id);
            if (kasaTipi == null)
            {
                return NotFound();
            }
            return View(kasaTipi);
        }

        // POST: KasaTipi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KasaTipiAd")] KasaTipi kasaTipi)
        {
            if (id != kasaTipi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kasaTipi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KasaTipiExists(kasaTipi.Id))
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
            return View(kasaTipi);
        }

        // GET: KasaTipi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kasaTipi = await _context.KasaTipi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kasaTipi == null)
            {
                return NotFound();
            }

            return View(kasaTipi);
        }

        // POST: KasaTipi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kasaTipi = await _context.KasaTipi.FindAsync(id);
            _context.KasaTipi.Remove(kasaTipi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KasaTipiExists(int id)
        {
            return _context.KasaTipi.Any(e => e.Id == id);
        }
    }
}
