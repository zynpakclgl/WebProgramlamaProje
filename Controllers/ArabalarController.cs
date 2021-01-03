using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProje.Data;

namespace WebProje.Controllers
{
    public class ArabalarController : Controller
    {
        private ApplicationDbContext _context;

        public ArabalarController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var arabaList = (from a in _context.Araba
                             join s in _context.Satici on a.SaticiId equals s.Id
                             select new ArabaDTO
                             {
                                 SaticiAdSoyad = s.AdSoyad,
                                 IlanNo = a.IlanNo,
                                 MarkaAdi = a.Marka.MarkaAd,
                                 ArabaModeli = a.ArabaModel.ArabaModelAd,
                                 Yil = a.Yil,
                                 Yakit = a.Yakit,
                                 Vites = a.Vites,
                                 MotorGücü = a.MotorGücü,
                                 MotorHacmi = a.MotorHacmi,
                                 Km = a.Km,
                                 RenkAdi = a.Renk.RenkAd,
                                 KasaTipiAdi = a.KasaTipi.KasaTipiAd,
                                 CekisAdi = a.Cekis.CekisAd,
                                 Plaka = a.Plaka,
                                 Durumu = a.Durumu,
                                 Fiyat = a.Fiyat,
                                 Fotograf = a.Fotograf                         
                                
                             })

                          .OrderBy(x => x.IlanNo).ToList();
            
            
            return View(arabaList);

        }

        
    }

    public class ArabaDTO
    {
        public int IlanNo { get; internal set; }
        public string MarkaAdi { get; internal set; }
        public string ArabaModeli { get; internal set; }
        public int Yil { get; internal set; }
        public string Yakit { get; internal set; }
        public string Vites { get; internal set; }
        public int MotorGücü { get; internal set; }
        public int MotorHacmi { get; internal set; }
        public double Km { get; internal set; }
        public string RenkAdi { get; internal set; }
        public string KasaTipiAdi { get; internal set; }
        public string CekisAdi { get; internal set; }
        public string Plaka { get; internal set; }
        public string Durumu { get; internal set; }
        public double Fiyat { get; internal set; }
        public string Fotograf { get; internal set; }
        public string SaticiAdSoyad { get; internal set; }

    }
}

