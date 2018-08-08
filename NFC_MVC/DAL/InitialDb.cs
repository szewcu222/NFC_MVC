using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NFC_MVC.Migrations;
using NFC_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NFC_MVC.DAL
{
    public class InitialDb : MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>
    {
        public static void SeedNFC(ApplicationDbContext context)
        {
            var UserManager = new UserManager<Uzytkownik>(new UserStore<Uzytkownik>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - STWORZENIE ROLI 'ADMIN' - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            string roleNameAdmin = "Admin";

            if (!RoleManager.RoleExists(roleNameAdmin))
            {
                var roleresult = RoleManager.Create(new IdentityRole(roleNameAdmin));
            }

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - STWORZENIE ROLI 'USER' - - - - - - - - - - - - - - - - - - - - - - 
            string roleNameUser = "User";

            if (!RoleManager.RoleExists(roleNameUser))
            {
                var roleresult = RoleManager.Create(new IdentityRole(roleNameUser));
            }

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - STWORZENIE UŻYTKOWNIKÓW 'ADMIN' - - - - - - - - - - - - - - - - - -
            var user = new Uzytkownik() { UserName = "admin@przepisy.pl", Email = "admin@przepisy.pl", DataRejestracji = DateTime.Now, Nazwisko = "ziomek" };

            if (UserManager.Create(user, "P@ssw0rd").Succeeded)
            {
                UserManager.AddToRole(user.Id, roleNameAdmin);
            }

            List<Uzytkownik> listaUserow = new List<Uzytkownik>() {
                new Uzytkownik() { UserName = "4sobek4@gmail.com", Email = "4sobek4@gmail.com", Imie = "Sebastian", Nazwisko = "Szczepanski", DataRejestracji = DateTime.Now },
                new Uzytkownik() { UserName = "laroja_ns9@gmail.com", Email = "laroja_ns9@gmail.com", Imie = "Tomek", Nazwisko = "Miss", DataRejestracji = DateTime.Now },
                new Uzytkownik() { UserName = "cwel@gmail.com", Email = "cwel@gmail.com", Imie = "Lukasz", Nazwisko = "Gej", DataRejestracji = DateTime.Now},
                new Uzytkownik() { UserName = "didajdisapojntciu@gmail.com", Email = "didajdisapojntciu@gmail.com", Imie = "James", Nazwisko = "Blunt", DataRejestracji = DateTime.Now }
            };

            foreach (var us in listaUserow)
            {
                if (UserManager.Create(us, "password").Succeeded)
                {
                    UserManager.AddToRole(us.Id, roleNameUser);
                }
            }




            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - LODOWKA

            var lodowki = new List<Lodowka> {
                    new Lodowka { Pojemnosc = 10, GrupaId = 1, DataAktualizacji = DateTime.Now },
                    new Lodowka { Pojemnosc = 15, GrupaId = 2, DataAktualizacji = DateTime.Now },
                    new Lodowka { Pojemnosc = 12, GrupaId = 3, DataAktualizacji = DateTime.Now }
                };

            lodowki.ForEach(x => context.Lodowki.Add(x));
            context.SaveChanges();

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - GRUPA

            var u1 = context.Users.SingleOrDefault(u => u.UserName == "laroja_ns9@gmail.com").Id;
            var u2 = context.Users.SingleOrDefault(u => u.UserName == "4sobek4@gmail.com").Id;
            var u3 = context.Users.SingleOrDefault(u => u.UserName == "cwel@gmail.com").Id;

            //var grupy = new List<Grupa> {
            //        new Grupa { Nazwa = "yakuza" },
            //        new Grupa { Nazwa = "mlode_wilki" },
            //        new Grupa { Nazwa = "banda chuja"}
            //    };

            //grupy.ForEach(x => context.Grupy.Add(x));
            //context.SaveChanges();




            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - PRODUKT

            var produkty = new List<Produkt> {
                    new Produkt {Nazwa = "Kielbasa",    RFIDTag = "SDSA532131289DSA", DataWaznosci = DateTime.Now},
                    new Produkt {Nazwa = "Twarozek",    RFIDTag = "372819D7SADSA789", DataWaznosci = DateTime.Now},
                    new Produkt {Nazwa = "Pizza",       RFIDTag = "3421DHSJAKDFAS3D", DataWaznosci = DateTime.Now},
                    new Produkt {Nazwa = "Kabanosy",    RFIDTag = "90GFDSGHFJDSKGGF", DataWaznosci = DateTime.Now},
                    new Produkt {Nazwa = "CocaCola",    RFIDTag = "DFSAFDSA2432341C", DataWaznosci = DateTime.Now},
                    new Produkt {Nazwa = "Chipsy",      RFIDTag = "NBGHJ48DNBCIU489", DataWaznosci = DateTime.Now},
                    new Produkt {Nazwa = "Cisowianka",  RFIDTag = "012234187CDHSFDS", DataWaznosci = DateTime.Now},
                    new Produkt {Nazwa = "Jogurt",      RFIDTag = "43298DSADA213144", DataWaznosci = DateTime.Now},
                    new Produkt {Nazwa = "Maslo",       RFIDTag = "75643643FDSFSASA", DataWaznosci = DateTime.Now}
                };

            produkty.ForEach(x => context.Produkty.Add(x));
            context.SaveChanges();

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - STABY LODOWEK

            //var l1 = context.Lodowki.Find(1);
            //var l2 = context.Lodowki.Find(2);
            //var l3 = context.Lodowki.Find(3);

            //var p1 = context.Produkty.Find(1).ProduktId;



            //var stanyLodowek = new List<StanLodowki> {
            //        new StanLodowki() { LodowkaId = 1, ProduktId = 1, Ilosc = 3 },
            //        new StanLodowki() { LodowkaId = 1, ProduktId = 2, Ilosc = 3 },
            //        new StanLodowki() { LodowkaId = 1, ProduktId = 3, Ilosc = 3 },
            //        new StanLodowki() { LodowkaId = 2, ProduktId = 3, Ilosc = 3 },
            //        new StanLodowki() { LodowkaId = 2, ProduktId = 4, Ilosc = 3 },
            //        new StanLodowki() { LodowkaId = 2, ProduktId = 5, Ilosc = 3 },
            //        new StanLodowki() { LodowkaId = 3, ProduktId = 2, Ilosc = 3 },
            //        new StanLodowki() { LodowkaId = 3, ProduktId = 3, Ilosc = 3 },
            //        new StanLodowki() { LodowkaId = 3, ProduktId = 4, Ilosc = 3 }
            //    };

            //stanyLodowek.ForEach(d => context.StanyLodowek.Add(d));
            //context.SaveChanges();


            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - UPODOBANIA UZYTKOWNIKA



            //var upodobaniaUzytkownika = new List<UpodobanieUzytkownika> {
            //        new UpodobanieUzytkownika() { ProduktId = 1, UzytkownikId = u1, Ilosc = 5 },
            //        new UpodobanieUzytkownika() { ProduktId = 1, UzytkownikId = u2, Ilosc = 5 },
            //        new UpodobanieUzytkownika() { ProduktId = 1, UzytkownikId = u3, Ilosc = 5 },
            //        new UpodobanieUzytkownika() { ProduktId = 2, UzytkownikId = u1, Ilosc = 5 },
            //        new UpodobanieUzytkownika() { ProduktId = 2, UzytkownikId = u2, Ilosc = 5 },
            //        new UpodobanieUzytkownika() { ProduktId = 2, UzytkownikId = u3, Ilosc = 5 },
            //        new UpodobanieUzytkownika() { ProduktId = 3, UzytkownikId = u1, Ilosc = 5 },
            //        new UpodobanieUzytkownika() { ProduktId = 3, UzytkownikId = u2, Ilosc = 5 },
            //        new UpodobanieUzytkownika() { ProduktId = 3, UzytkownikId = u3, Ilosc = 5 }
            //    };


            //upodobaniaUzytkownika.ForEach(d => context.UpodobaniaUzytkownikow.Add(d));
            //context.SaveChanges();
            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ZAMOWIENIA

            //var zamowienia = new List<Zamowienie> {
            //         new Zamowienie
            //        {
            //            UzytkownikId = u1,
            //            LodowkaId = 1,
            //            //Produkty = new List<Produkt>{ context.Produkty.Find(1) }
            //        },
            //         new Zamowienie
            //         {
            //             UzytkownikId = u2,
            //             LodowkaId = 2,
            //             //Produkty = new List<Produkt>{ context.Produkty.Find(2) }
            //         },
            //         new Zamowienie
            //         {
            //             UzytkownikId = u3,
            //             LodowkaId = 3,
            //             //Produkty = new List<Produkt>{ context.Produkty.Find(3) }
            //         }
            //    };

            //zamowienia.ForEach(d => context.Zamowienia.Add(d));
            //context.SaveChanges();
        }
    }
}