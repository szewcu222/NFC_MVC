using NFC_MVC.DAL;
using NFC_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFC_MVC.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetProdukt()
        {
            Produkt produkt = new Produkt
            {
                Cena = 12,
                DataWaznosci = DateTime.Now,
                Nazwa = "jabko",
                RFIDTag = "1111"
            };
            db.Produkty.Add(produkt);
            db.SaveChanges();
            
            return Json(produkt);
        }

        public string zam()
        {
            var u1 = db.Users.SingleOrDefault(u => u.UserName == "laroja_ns9@gmail.com").Id;

            var z = new Zamowienie
            {
                UzytkownikId = u1,
                LodowkaId = 5,
                DataDostarczenia = DateTime.Now,
                DataZamowienia = DateTime.Now
                //Produkty = new List<Produkt>{ context.Produkty.Find(1) }
            };
            db.Zamowienia.Add(z);
            db.SaveChanges();

            return z.UzytkownikId;
        }

    }
}