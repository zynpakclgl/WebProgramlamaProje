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
    public class ArabaModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArabaModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArabaModel
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArabaModel.ToListAsync());
        }

        // GET: ArabaModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arabaModel = await _context.ArabaModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arabaModel == null)
            {
                return NotFound();
            }

            return View(arabaModel);
        }

        // GET: ArabaModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArabaModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArabaModelAd")] ArabaModel arabaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arabaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arabaModel);
        }

        // GET: ArabaModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arabaModel = await _context.ArabaModel.FindAsync(id);
            if (arabaModel == null)
            {
                return NotFound();
            }
            return View(arabaModel);
        }

        // POST: ArabaModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArabaModelAd")] ArabaModel arabaModel)
        {
            if (id != arabaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arabaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArabaModelExists(arabaModel.Id))
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
            return View(arabaModel);
        }

        // GET: ArabaModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arabaModel = await _context.ArabaModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arabaModel == null)
            {
                return NotFound();
            }

            return View(arabaModel);
        }

        // POST: ArabaModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arabaModel = await _context.ArabaModel.FindAsync(id);
            _context.ArabaModel.Remove(arabaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArabaModelExists(int id)
        {
            return _context.ArabaModel.Any(e => e.Id == id);
        }
    }
}
