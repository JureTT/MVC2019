using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class LayoutSectionController : Controller
    {
        // GET: LayoutSection
        public ActionResult Stranica1()
        {
            return View();
        }

        // GET: LayoutSection
        public ActionResult Stranica2()
        {
            return View();
        }
    }
}