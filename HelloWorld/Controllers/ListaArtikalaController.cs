using HelloWorld.Models;
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
            ViewBag.Kategorije = kategorije;
            return View(new Artikl());
        }
        
        [HttpPost]
        public ActionResult DodajArtikal(Artikl artikl)
        {
            if(Session["Artikli"] != null)
            {
                List<Artikl> artikli = (List<Artikl>)Session["Artikli"];
                artikli.Add(artikl);
                Session["Artikli"] = artikli;
            }
            else
            {
                List<Artikl> artikli = new List<Artikl>();
                artikli.Add(artikl);
                Session["Artikli"] = artikli;
            }
            return View(Session["Artikli"]);
        }
    }
}