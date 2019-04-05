using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class ListaArtikalaController : Controller
    {
        // GET: ListaArtikala
        public ActionResult UnesiArtikal()
        {
            string[] kategorije = new string[] { "Sport", "Glazba", "Tehnika" };
            ViewBag.nešto = kategorije;
            return View();
        }
        // GET: ListaArtikala
        [HttpPost]
        public ActionResult DodajArtikal()
        {
            return View();
        }
    }
}