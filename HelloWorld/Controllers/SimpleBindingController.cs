using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class SimpleBindingController : Controller
    {    
        // GET: /SimpleBinding/SimpleBindMetoda
        public ViewResult SimpleBindMetoda()
        {
            return View("SimpleBind");
        }

        // POST: /SimpleBindMetoda
        [HttpPost]
        public ViewResult SimpleBindMetoda(string ime)
        {
            string pozdrav = "Pozdrav, " + ime + "!";
            return View("SimpleBind", (object)pozdrav);
        }
    }
}