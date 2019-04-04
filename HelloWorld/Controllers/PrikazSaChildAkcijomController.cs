using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class PrikazSaChildAkcijomController : Controller
    {
        // GET: ObradiListu
        public ActionResult ObradiListu()
        {
            List<Artikl> lista = new List<Artikl>()
            {
                new Artikl() { Naziv = "Lopta", Cijena = 50m, Kategorija = "Sport" },
                new Artikl() { Naziv = "Gitara", Cijena = 200m, Kategorija = "Glazba" },
                new Artikl() { Naziv = "Tablet", Cijena = 500m, Kategorija = "Tehnika" }
            };
            return View(lista);
        }
        [ChildActionOnly]
        public string OdrediKategoriju(Artikl artikl)
        {
            string kategorija = artikl.Kategorija;
            return kategorija;
        }
    }
}