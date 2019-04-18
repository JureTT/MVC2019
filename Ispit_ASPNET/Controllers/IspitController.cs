using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ispit_ASPNET.Controllers
{
    public class IspitController : Controller
    {
        // GET: Ispit
        public ActionResult Prvi()
        {
            DateTime datum = DateTime.Now;
            return View(datum);
        }
    }
}