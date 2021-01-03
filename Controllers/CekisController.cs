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
    public class CekisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CekisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cekis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cekis.ToListAsync());
        }

        // GET: Cekis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cekis = await _context.Cekis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cekis == null)
            {
                return NotFound();
            }

            return View(cekis);
        }

        // GET: Cekis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cekis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CekisAd")] Cekis cekis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cekis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cekis);
        }

        // GET: Cekis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cekis = await _context.Cekis.FindAsync(id);
            if (cekis == null)
            {
                return NotFound();
            }
            return View(cekis);
        }

        // POST: Cekis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CekisAd")] Cekis cekis)
        {
            if (id != cekis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cekis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CekisExists(cekis.Id))
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
            return View(cekis);
        }

        // GET: Cekis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cekis = await _context.Cekis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cekis == null)
            {
                return NotFound();
            }

            return View(cekis);
        }

        // POST: Cekis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cekis = await _context.Cekis.FindAsync(id);
            _context.Cekis.Remove(cekis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CekisExists(int id)
        {
            return _context.Cekis.Any(e => e.Id == id);
        }
    }
}
