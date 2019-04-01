using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class OsobaController : Controller
    {
        // GET: Osoba/PopuniOsobu
        public ActionResult PopuniOsobu()
        {
            return View();
        }
        // POST: Osoba/PopuniOsobu
        [HttpPost]
        public ActionResult PrikaziOsobu(Osoba osoba)
        {
            return View(osoba);
        }
    }
}