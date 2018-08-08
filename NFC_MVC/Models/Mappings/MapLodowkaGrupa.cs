using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace NFC_MVC.Models.Mappings
{
    public class LodowkaMap : EntityTypeConfiguration<Lodowka>
    {
        public LodowkaMap()
        {
            this.HasKey(c => c.LodowkaId);
            this.Property(c => c.LodowkaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasRequired(c1 => c1.Grupa).WithRequiredPrincipal(c2 => c2.Lodowka);
        }
    }
}