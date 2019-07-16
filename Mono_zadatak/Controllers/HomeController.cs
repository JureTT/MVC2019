using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mono_zadatak.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Stranica je napravljena kako bi se naučila sredstva koja su na raspolaganja programeru pri izradi web aplikacije.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakt se može ostvariti putem maila.";

            return View();
        }
    }
}