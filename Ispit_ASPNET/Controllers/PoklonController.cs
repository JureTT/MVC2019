using Ispit_ASPNET.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Ispit_ASPNET.Controllers
{
    public class PoklonController : Controller
    {
        private ApplicationDbContext _baza = new ApplicationDbContext();
        // GET: Poklon
        public ActionResult Index()
        {
            List<Poklon> popis = (from p in _baza.Pokloni where p.Kupljeno.ToString()=="false" select p).ToList();
            return View(popis);
        }

        public ActionResult Dodaj()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult Dodaj(Poklon poklon)
        {
            if(ModelState.IsValid)
            {
                _baza.Pokloni.Add(poklon);
                _baza.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Detalji(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poklon poklon = _baza.Pokloni.Find(id);
            if (poklon == null)
            {
                return HttpNotFound();
            }
            return View(poklon);
        }

        public ActionResult Uredi(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poklon poklon = _baza.Pokloni.Find(id);
            if (poklon == null)
            {
                return HttpNotFound();
            }
            return View(poklon);
        }
        [HttpPost]
        public ActionResult Uredi(Poklon poklon)
        {
            if(ModelState.IsValid)
            {
                _baza.Entry(poklon).State = EntityState.Modified;
                _baza.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(poklon);
        }

        public ActionResult Obrisi(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poklon poklon = _baza.Pokloni.Find(id);
            if (poklon == null)
            {
                return HttpNotFound();
            }
            return View(poklon);
        }
        [HttpPost]
        public ActionResult Obrisi(int id)
        {
            Poklon poklon = _baza.Pokloni.Find(id);
            _baza.Pokloni.Remove(poklon);
            _baza.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Kupljeno()
        {
            List<Poklon> popis = (from p in _baza.Pokloni where p.Kupljeno.Equals(true) select p).ToList();
            return View(popis);
        }
    }
}