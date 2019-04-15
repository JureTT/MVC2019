using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class WebShopController : Controller
    {
        // GET: WebShop
        private WebShopEntities db = new WebShopEntities();

        public ActionResult Index()
        {
            var proizvodi = db.Proizvodis.Include(p => p.MjereProizvoda);
            return View(proizvodi.ToList());
        }
    }
}