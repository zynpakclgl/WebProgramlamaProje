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
    public class SaticiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SaticiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Satici
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Satici.Include(s => s.Adres);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Satici/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var satici = await _context.Satici
                .Include(s => s.Adres)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (satici == null)
            {
                return NotFound();
            }

            return View(satici);
        }

        // GET: Satici/Create
        public IActionResult Create()
        {
            ViewData["AdresId"] = new SelectList(_context.Adres, "Id", "AdresAd");
            return View();
        }

        // POST: Satici/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Soyad,Telefon,AdresId")] Satici satici)
        {
            if (ModelState.IsValid)
            {
                _context.Add(satici);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdresId"] = new SelectList(_context.Adres, "Id", "AdresAd", satici.AdresId);
            return View(satici);
        }

        // GET: Satici/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var satici = await _context.Satici.FindAsync(id);
            if (satici == null)
            {
                return NotFound();
            }
            ViewData["AdresId"] = new SelectList(_context.Adres, "Id", "AdresAd", satici.AdresId);
            return View(satici);
        }

        // POST: Satici/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Soyad,Telefon,AdresId")] Satici satici)
        {
            if (id != satici.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(satici);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaticiExists(satici.Id))
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
            ViewData["AdresId"] = new SelectList(_context.Adres, "Id", "AdresAd", satici.AdresId);
            return View(satici);
        }

        // GET: Satici/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var satici = await _context.Satici
                .Include(s => s.Adres)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (satici == null)
            {
                return NotFound();
            }

            return View(satici);
        }

        // POST: Satici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var satici = await _context.Satici.FindAsync(id);
            _context.Satici.Remove(satici);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaticiExists(int id)
        {
            return _context.Satici.Any(e => e.Id == id);
        }
    }
}
