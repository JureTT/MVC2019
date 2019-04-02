using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class NaruciController : Controller
    {
        // GET: NaruciArtikal
        public ActionResult NaruciArtikal()
        {
            return View();
        }

        // POST: NaruciArtikal
        [HttpPost]
        public ActionResult NaruciArtikal(Artikl artikl)
        {
            if(artikl.Kolicina > 10)
            {
                ViewBag.Poruka = "Nema dovoljno " + artikl.Naziv + " na skladištu!";
                return View(artikl);
            }
            else
            {
                ViewBag.Poruka = "Naručeno je " + artikl.Kolicina + "komada" + artikl.Naziv + " sa ukupnom cijenom " + artikl.Cijena * artikl.Kolicina;
                return View(artikl);
            }
        }
    }
}