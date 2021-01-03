using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProje.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using WebProje.Data;

namespace ArabaAlSat.Controllers
{
    public class ArabaController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _hostingEnvironment;

        public ArabaController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Araba
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Araba.Include(a => a.ArabaModel).Include(a => a.Cekis).Include(a => a.Ilan).Include(a => a.KasaTipi).Include(a => a.Marka).Include(a => a.Renk).Include(a => a.Satici);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Araba/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var araba = await _context.Araba
                .Include(a => a.ArabaModel)
                .Include(a => a.Cekis)
                .Include(a => a.Ilan)
                .Include(a => a.KasaTipi)
                .Include(a => a.Marka)
                .Include(a => a.Renk)
                .Include(a => a.Satici)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (araba == null)
            {
                return NotFound();
            }

            return View(araba);
        }

        // GET: Araba/Create
        public IActionResult Create()
        {
            ViewData["ArabaModelId"] = new SelectList(_context.ArabaModel, "Id", "ArabaModelAd");
            ViewData["CekisId"] = new SelectList(_context.Cekis, "Id", "CekisAd");
            ViewData["IlanNo"] = new SelectList(_context.Ilan, "Id", "IlanNo");
            ViewData["KasaTipiId"] = new SelectList(_context.KasaTipi, "Id", "KasaTipiAd");
            ViewData["MarkaId"] = new SelectList(_context.Marka, "Id", "MarkaAd");
            ViewData["RenkId"] = new SelectList(_context.Renk, "Id", "RenkAd");
            ViewData["SaticiId"] = new SelectList(_context.Satici, "Id", "AdSoyad");
            return View();
        }

        // POST: Araba/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IlanNo,MarkaId,ArabaModelId,Yil,Yakit,Vites,MotorGücü,MotorHacmi,Km,RenkId,KasaTipiId,CekisId,Plaka,Durumu,Fiyat,Fotograf,SaticiId")] Araba araba)
        {
            if (ModelState.IsValid)
            {

                //**************************************

                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;


                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"image\araba");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                araba.Fotograf = @"\image\araba\" + fileName + extension;

                //**************************************
                _context.Add(araba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArabaModelId"] = new SelectList(_context.ArabaModel, "Id", "ArabaModelAd", araba.ArabaModelId);
            ViewData["CekisId"] = new SelectList(_context.Cekis, "Id", "CekisAd", araba.CekisId);
            ViewData["IlanNo"] = new SelectList(_context.Ilan, "Id", "IlanId", araba.IlanNo);
            ViewData["KasaTipiId"] = new SelectList(_context.KasaTipi, "Id", "KasaTipiAd", araba.KasaTipiId);
            ViewData["MarkaId"] = new SelectList(_context.Marka, "Id", "MarkaAd", araba.MarkaId);
            ViewData["RenkId"] = new SelectList(_context.Renk, "Id", "RenkAd", araba.RenkId);
            ViewData["SaticiId"] = new SelectList(_context.Satici, "Id", "AdSoyad", araba.SaticiId);
            return View(araba);
        }

        // GET: Araba/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var araba = await _context.Araba.FindAsync(id);
            if (araba == null)
            {
                return NotFound();
            }
            ViewData["ArabaModelId"] = new SelectList(_context.ArabaModel, "Id", "ArabaModelAd", araba.ArabaModelId);
            ViewData["CekisId"] = new SelectList(_context.Cekis, "Id", "CekisAd", araba.CekisId);
            ViewData["IlanNo"] = new SelectList(_context.Ilan, "Id", "IlanId", araba.IlanNo);
            ViewData["KasaTipiId"] = new SelectList(_context.KasaTipi, "Id", "KasaTipiAd", araba.KasaTipiId);
            ViewData["MarkaId"] = new SelectList(_context.Marka, "Id", "MarkaAd", araba.MarkaId);
            ViewData["RenkId"] = new SelectList(_context.Renk, "Id", "RenkAd", araba.RenkId);
            ViewData["SaticiId"] = new SelectList(_context.Satici, "Id", "AdSoyad", araba.SaticiId);
            return View(araba);
        }

        // POST: Araba/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IlanNo,MarkaId,ArabaModelId,Yil,Yakit,Vites,MotorGücü,MotorHacmi,Km,RenkId,KasaTipiId,CekisId,Plaka,Durumu,Fiyat,Fotograf,SaticiId")] Araba araba)
        {
            if (id != araba.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(araba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArabaExists(araba.Id))
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
            ViewData["ArabaModelId"] = new SelectList(_context.ArabaModel, "Id", "ArabaModelAd", araba.ArabaModelId);
            ViewData["CekisId"] = new SelectList(_context.Cekis, "Id", "CekisAd", araba.CekisId);
            ViewData["IlanNo"] = new SelectList(_context.Ilan, "Id", "IlanId", araba.IlanNo);
            ViewData["KasaTipiId"] = new SelectList(_context.KasaTipi, "Id", "KasaTipiAd", araba.KasaTipiId);
            ViewData["MarkaId"] = new SelectList(_context.Marka, "Id", "MarkaAd", araba.MarkaId);
            ViewData["RenkId"] = new SelectList(_context.Renk, "Id", "RenkAd", araba.RenkId);
            ViewData["SaticiId"] = new SelectList(_context.Satici, "Id", "AdSoyad", araba.SaticiId);
            return View(araba);
        }

        // GET: Araba/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var araba = await _context.Araba
                .Include(a => a.ArabaModel)
                .Include(a => a.Cekis)
                .Include(a => a.Ilan)
                .Include(a => a.KasaTipi)
                .Include(a => a.Marka)
                .Include(a => a.Renk)
                .Include(a => a.Satici)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (araba == null)
            {
                return NotFound();
            }

            return View(araba);
        }

        // POST: Araba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var araba = await _context.Araba.FindAsync(id);
            _context.Araba.Remove(araba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArabaExists(int id)
        {
            return _context.Araba.Any(e => e.Id == id);
        }
    }
}