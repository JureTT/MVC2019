using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class BrojGodinaController : Controller
    {
        // GET: RacunajBrojGodina
        public ActionResult RacunajBrojGodina()
        {
            return View();
        }
        // POST: RacunajBrojGodina
        [HttpPost]
        public ActionResult RacunajBrojGodina(DateTime? datum)
        {
            if (datum == null)
            {
                datum = DateTime.Now;
            }
            TimeSpan razlika = DateTime.Now - (DateTime)datum;          // "datum" se mora kastati jer je tipa DateTime?
            int godine = razlika.Days / 365;
            return View(godine);
            //int razlikaGodina = (DateTime.Now - datum).Days / 365;
            //return View((object)razlikaGodina);
        }
    }
}