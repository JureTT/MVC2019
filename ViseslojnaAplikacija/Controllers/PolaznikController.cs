using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViseslojnaAplikacija.Models;
using ViseslojnaAplikacija.Models.DAL;

namespace ViseslojnaAplikacija.Controllers
{
    public class PolaznikController : Controller
    {
        public string Index()
        {
            return "Ovo je index";
        }
        // GET: Polaznik
        public ActionResult List()
        {
            List<PolaznikModel> lstPolaznici = new List<PolaznikModel>();

            try
            {
                lstPolaznici = Repozitorij.DohvatiPolaznike();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa polaznika! Opis: " + ex.Message;
            }
            return View(lstPolaznici);
        }

        // GET: Polaznik/Details/5
        public ActionResult Details(int idPolaznik)
        {
            PolaznikModel polaznik = new PolaznikModel(false);

            try
            {
                polaznik = Repozitorij.DohvatiPolaznika(idPolaznik);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja polaznika Opis: " + ex.Message;
            }
            return View(polaznik);
        }

        // GET: Polaznik/Create
        public ActionResult Create()
        {
            return View(new PolaznikModel(false));
        }

        // POST: Polaznik/Create
        [HttpPost]
        public ActionResult Create(PolaznikModel model)
        {
            try
            {
                Repozitorij.KreirajPolaznika(model);
                ViewBag.Message = "Polaznik uspješno upisan!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod upisa polaznika! Opis: " + ex.Message;
            }
            return View(model);
        }

        // GET: Polaznik/Edit/5
        public ActionResult Edit(int idPolaznik)
        {
            PolaznikModel polaznik = new PolaznikModel(false);
            try
            {
                polaznik = Repozitorij.DohvatiPolaznika(idPolaznik);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja polaznika! Opis: " + ex.Message;
            }
            return View(polaznik);
        }

        // POST: Polaznik/Edit/5
        [HttpPost]
        public ActionResult Edit(PolaznikModel model)
        {
            try
            {
                Repozitorij.UrediPolaznika(model);
                ViewBag.Message = "Polaznik uspješno uređen!";
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja polaznika! Opis: " + ex.Message;
            }
            return View(model);
        }

        // GET: Polaznik/Delete/5
        public ActionResult Delete(int idPolaznik)
        {           
            try
            {
                Repozitorij.IzbrisiPolaznika(idPolaznik);
                TempData["Message"] = "Polaznik uspješno izbrisan!";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Greška kod brisanja polaznika! Opis: " + ex.Message;
            }
            return RedirectToAction("List");
        }
    }
}
