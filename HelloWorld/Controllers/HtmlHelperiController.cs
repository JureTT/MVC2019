using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class HtmlHelperiController : Controller
    {
        // GET: HtmlHelperi
        public ActionResult Index()
        {
            return View();
        }

        private string[] mjesta = new string[]
        {
            "Split", "Zadar", "Osijek", "Rijeka"
        };
        public ViewResult FormHelper()
        {
            ViewBag.Mjesta = mjesta;
            return View(new Osoba());
        }
        [HttpPost]
        public ViewResult FormHelper(Osoba osoba)
        {
            ViewBag.Mjesta = mjesta;
            ViewBag.Poruka = "Uspjeh, juhu :)";
            return View(new Osoba());
        }
        public ViewResult StronglyTypedHelper()
        {
            ViewBag.Mjesta = mjesta;
            return View(new Osoba());
        }
        [HttpPost]
        public ViewResult StronglyTypedHelper(Osoba osoba)
        {
            ViewBag.Mjesta = mjesta;
            ViewBag.Poruka = "Uspješno unešeni podaci, juhu :)";
            return View(new Osoba());
        }
    }
}