using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NFC_MVC.Models
{
    [Table("Lodowka")]
    public class Lodowka
    {
        public Lodowka()
        {
            StanLodowki = new HashSet<StanLodowki>();
            Zamowienia = new HashSet<Zamowienie>(); 
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LodowkaId { get; set; }
        [Required]
        [Display(Name = "Pojemnosc w [L]")]
        public int Pojemnosc { get; set; }
        public DateTime DataAktualizacji { get; set; }


        [ForeignKey("Grupa")]
        public int? GrupaId { get; set; }
        public virtual Grupa Grupa { get; set; }

        public virtual ICollection<StanLodowki> StanLodowki { get; set; }

        public virtual ICollection<Zamowienie> Zamowienia { get; set; }
    }
}