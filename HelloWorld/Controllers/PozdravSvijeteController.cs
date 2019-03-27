using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class PozdravSvijeteController : Controller
    {
        // GET: PozdravSvijete
        public ActionResult Index()
        {
            string model = "Pozdrav svijete lalala";
            return View((object)model);
        }
    }
}