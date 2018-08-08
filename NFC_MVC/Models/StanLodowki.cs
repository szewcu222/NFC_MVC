using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NFC_MVC.Models
{
    [Table("StanLodowki")]
    public class StanLodowki
    {
        public int Ilosc { get; set; }

        [ForeignKey("Lodowka")]
        public int LodowkaId { get; set; }
        public Lodowka Lodowka { get; set; }

        [ForeignKey("Produkt")]
        public int ProduktId { get; set; }
        public Produkt Produkt { get; set; }
    }
}