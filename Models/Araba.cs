using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProje.Models
{
    public class Araba
    {
        public int Id { get; set; }
        public int IlanNo { get; set; }
        public int MarkaId { get; set; }
        public int ArabaModelId { get; set; }
        public int Yil { get; set; }
        public string Yakit { get; set; }
        public string Vites { get; set; }
        public int MotorGücü { get; set; }
        public int MotorHacmi { get; set; }
        public double Km { get; set; }
        public int RenkId { get; set; }
        public int KasaTipiId { get; set; }
        public int CekisId { get; set; }
        public string Plaka { get; set; }
        public string Durumu { get; set; }
        public double Fiyat { get; set; }
        public string Fotograf { get; set; }
        public int SaticiId { get; set; }

        public ArabaModel ArabaModel { get; set; }
        public KasaTipi KasaTipi { get; set; }
        public Cekis Cekis { get; set; }
        public Ilan Ilan { get; set; }
        public Renk Renk { get; set; }
        public Satici Satici { get; set; }
        public Marka Marka { get; set; }
    }
}
