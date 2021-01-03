using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebProje.Data;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var arabaList = _context.Araba
                .Include(a => a.ArabaModel)
                .Include(a => a.Cekis)
                .Include(a => a.Ilan)
                .Include(a => a.KasaTipi)
                .Include(a => a.Marka)
                .Include(a => a.Renk)
                .Include(a => a.Satici);
            return View(arabaList.ToList());
        }
    }
}
