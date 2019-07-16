using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mono_zadatak.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View("Error");
        }
        public ActionResult NotFound()
        {
            ViewBag.poruka = "Kod statusa 404 - Stranica koju ste tražili nije pronađena.";
            return View("Error");
        }
        public ActionResult Internal()
        {
            ViewBag.poruka = "Kod statusa 500 - Dogoodila se unutarnja greška poslužitelja.";
            return View("Error");
        }
    }
}