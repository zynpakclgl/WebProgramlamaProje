using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProje.Models
{
    public class Kullanicilar : IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int TcNo { get; set; }

        [DataType(DataType.Date)]
        public DateTime DogumTarihi { get; set; }

    }
}
