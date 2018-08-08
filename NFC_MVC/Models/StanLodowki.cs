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

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LodowkaId { get; set; }
        public Lodowka Lodowka { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProduktId { get; set; }
        public Produkt Produkt { get; set; }
    }
}