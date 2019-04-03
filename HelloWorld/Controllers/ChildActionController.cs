using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class ChildActionController : Controller
    {
        // GET: ChildAction
        public ViewResult ChildActionView()
        {
            string[] proizvodi = new string[]
            {
                "Banana", "Jabuka", "Kivi", "Mrkva", "Kupus"
            };
            return View(proizvodi);
        }
        // GET: ChildAction/OdredigrupuProizvoda
        [ChildActionOnly]
        public string OdrediGrupuProizvoda(string proizvod)
        {
            switch (proizvod)
            {
                case "Jabuka":
                case "Kivi":
                case "Banana":
                    return "Voće";
                case "Mrkva":
                case "Kupus":
                    return "Povrće";
                default:
                    return "Nepoznato";
            }
        }
    }
}