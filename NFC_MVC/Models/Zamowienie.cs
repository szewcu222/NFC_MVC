using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using NFC_MVC.Models.Enums;

namespace NFC_MVC.Models
{
    [Table("Zamowienie")]
    public class Zamowienie
    {
        public Zamowienie()
        {
            Produkty = new HashSet<Produkt>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ZamowienieId { get; set; }
        [Required]
        public DateTime DataZamowienia { get; set; }
        [Required]
        public DateTime DataDostarczenia { get; set; }
        [Required]
        public TypZamowienia TypZamowienia { get; set; }


        [ForeignKey("Uzytkownik")]
        public string UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }

        [ForeignKey("Lodowka")]
        public int LodowkaId { get; set; }
        public Lodowka Lodowka { get; set; }
        //[JsonIgnore]
        public virtual ICollection<Produkt> Produkty { get; set; }
    }
}