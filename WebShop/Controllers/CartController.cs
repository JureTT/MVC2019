using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class CartController : Controller
    {
        private WebShopEntities db = new WebShopEntities();
        public static List<Proizvodi> lstProizvodi = new List<Proizvodi>();

        // GET: Cart
        public ActionResult Index()
        {
            if (Session["Cart"] != null)
            {
                lstProizvodi = Session["Cart"] as List<Proizvodi>;
            }

            return View(lstProizvodi);
        }

        public ActionResult AddToCart(int id)
        {
            Proizvodi proizvod = db.Proizvodis.Find(id);
            lstProizvodi.Add(proizvod);

            // Listu proizvoda spremamo u Session objekt
            Session["Cart"] = lstProizvodi;

            if(proizvod == null)
            {
                return HttpNotFound();
            }

            var proizvodi = db.Proizvodis.Include(p => p.MjereProizvoda);

            return RedirectToAction(actionName: "Index", controllerName: "WebShop", routeValues: proizvodi.ToList());
        }

        public ActionResult RemoveFromCart(int index)
        {
            lstProizvodi = Session["Cart"] as List<Proizvodi>;
            lstProizvodi.RemoveAt(index);
            Session["Cart"] = lstProizvodi;
            return View("Index", lstProizvodi);
        }
    }
}