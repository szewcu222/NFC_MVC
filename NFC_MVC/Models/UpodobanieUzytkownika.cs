using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NFC_MVC.Models
{
    [Table("UpodobaniaUzytkownika")]
    public class UpodobanieUzytkownika
    {
        public int Ilosc { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProduktId { get; set; }
        public Produkt Produkt { get; set; }
    }
}