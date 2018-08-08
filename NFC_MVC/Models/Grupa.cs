using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NFC_MVC.Models
{
    [Table("Grupa")]
    public class Grupa
    {
        public Grupa()
        {
            Uzytkownicy = new HashSet<Uzytkownik>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GrupaId { get; set; }
        [Required]
        public string Nazwa { get; set; }


        public virtual Lodowka Lodowka { get; set; }

        public virtual ICollection<Uzytkownik> Uzytkownicy { get; set; }
    }
}