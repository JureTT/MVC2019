using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Validacije.Models;

namespace Validacije.Controllers
{
    public class ValidacijeController : Controller
    {
        // GET: Validacije
        public ActionResult IzdvajanjeRacuna()
        {
            return View( new Racun() { Datum = DateTime.Now, BrojRacuna = "/" + DateTime.Now.Year.ToString() });
        }

        [HttpPost]
        public  ViewResult IzdvajanjeRacuna(Racun racun, string id)
        {
            //obavezne vrijednosti
            if (string.IsNullOrEmpty(racun.BrojRacuna))
            {
                ModelState.AddModelError("BrojRacuna", "Broj računa je obavezan!");
            }
            if (string.IsNullOrEmpty(racun.Zaposlenik))
            {
                ModelState.AddModelError("BrojRacuna", "Broj računa je obavezan!");
            }
            if (string.IsNullOrEmpty(racun.Kupac))
            {
                ModelState.AddModelError("BrojRacuna", "Broj računa je obavezan!");
            }

            //model-level validacija
            if (ModelState.IsValidField("Datum"))
            {
                if (racun.Datum < DateTime.Today.AddDays(-3))
                {
                    ModelState.AddModelError("", "Datum ne smije biti manji za više od 3 dana!");
                }
            }

            if(ModelState.IsValid)
            {
                return View("RacunIzdan", racun);
            }
            else
            {
                if (id == "IzdavanjeRacuna2")
                {
                    return View("IzdavanjeRacuna2");
                }
                else
                {
                    return View();
                }
            }

            //ukupna provjera validacije
            if (ModelState.IsValid)
            {
                return View("RacunIzdan", racun);
            }
            else
            {
                return View();
            }
        }
        
        public ViewResult IzdavanjeRacuna2()
        {
            return View(new Racun() { Datum = DateTime.Now, BrojRacuna = "/" + DateTime.Now.Year.ToString() });
        }

        public ViewResult MetaIzdavanjeRacuna()
        {
            return View(new MetaRacun() { Datum = DateTime.Now, BrojRacuna = "/" + DateTime.Now.Year.ToString() });
        }

        public ViewResult MetaIzdavanjeRacuna(MetaRacun metaRacun)
        {
            if (ModelState.IsValid)
            {
                return View("MetaRacunIzdan", metaRacun);
            }
            else
            {
                return View();
            }
        }
    }
}