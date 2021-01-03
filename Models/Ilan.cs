using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProje.Models
{
    public class Ilan
    {
        public int Id { get; set; }
        public int IlanNo { get; set; }

        [DataType(DataType.Date)]
        public DateTime IlanTarihi { get; set; }
    }
}
