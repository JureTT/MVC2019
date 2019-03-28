using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class PrviController : Controller
    {
        // GET: Prvi
        public ActionResult MetodaSParametrima(int id)
        {
            //return View();
            return Content(id.ToString());
        }
        // GET: Drugi
        public ActionResult DrugaMetodaSParametrima(int id)
        {
            return View((object)id);
            //return Content(id.ToString());
        }
    }
}