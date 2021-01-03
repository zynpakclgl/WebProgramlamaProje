using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebProje.Models;

namespace WebProje.Data
{
    public class ApplicationDbContext : IdentityDbContext<Kullanicilar>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Araba> Araba { get; set; }
        public DbSet<Satici> Satici { get; set; }
        public DbSet<Adres> Adres { get; set; }
        public DbSet<Cekis> Cekis { get; set; }
        public DbSet<Ilan> Ilan { get; set; }
        public DbSet<KasaTipi> KasaTipi { get; set; }
        public DbSet<ArabaModel> ArabaModel { get; set; }
        public DbSet<Renk> Renk { get; set; }
        public DbSet<Marka> Marka { get; set; }
    }
}
