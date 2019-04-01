using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class TocanOdgovorController : Controller
    {
        // GET: TocanOdgrovor
        public ActionResult ProvjeriOdgovor()
        {
            return View();
        }

        // GET: TocanOdgrovor
        [HttpPost]
        public ActionResult ProvjeriOdgovor(int? dan)
        {
            DateTime datum = DateTime.Now;
            string provjera = (dan == null)? "neunešen" : ((int)datum.DayOfWeek == dan) ? "točan" : "netočan";
            return View((object)provjera);
        }
    }
}