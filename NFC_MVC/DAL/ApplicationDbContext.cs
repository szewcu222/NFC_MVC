using Microsoft.AspNet.Identity.EntityFramework;
using NFC_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace NFC_MVC.DAL
{

    public class ApplicationDbContext : IdentityDbContext<Uzytkownik>
    {
        public ApplicationDbContext()
            : base("NFCContext")
        {
        }
        public DbSet<Grupa> Grupy { get; set; }
        public DbSet<Produkt> Produkty { get; set; }
        public DbSet<Lodowka> Lodowki { get; set; }
        public DbSet<StanLodowki> StanyLodowek { get; set; }
        public DbSet<UpodobanieUzytkownika> UpodobaniaUzytkownikow { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }

        static ApplicationDbContext()
        {
            Database.SetInitializer(new InitialDb());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //using System.Data.Entity.ModelConfiguration.Conventionsl
            //Wyłącza konwencje, ktora automatycznie tworzy liczbe mnoga dla nazw tabel w bazie danych
            //Zamiast Kategorie mielibysmy Kategories
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new Models.Mappings.LodowkaMap());
        }
    }

}