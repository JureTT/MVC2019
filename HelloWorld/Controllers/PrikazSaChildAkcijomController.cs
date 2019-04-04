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
            List<Artikl> lista = new List<Artikl>();
            {
                new Artikl() { Naziv = "Lopta", Cijena = 50, Kategorija = "Sport" };
                new Artikl() { Naziv = "Gitara", Cijena = 200, Kategorija = "Glazba" };
                new Artikl() { Naziv = "Tablet", Cijena = 500, Kategorija = "Tehnika" };
            }
            return View(lista);
        }
        [ChildActionOnly]
        public ActionResult OdrediKategoriju(Artikl artikl)
        {
            string kategorija = artikl.Kategorija;
            return View(kategorija);
        }
    }
}