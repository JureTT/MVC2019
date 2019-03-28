using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zadatak_2._1._1_zbirka.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string poruka = "Rezultat operacije 4 + 3 * 3 = ";
            return View((object)poruka);
        }
    }
}