using Mono_zadatak.Models;
using Mono_zadatak.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mono_zadatak.Controllers
{
    public class ModelController : Controller
    {
        public string Index()
        {
            return "Ovo je nije početna stranica, ukucati \"List\" kako bi dobili početnu stranicu.";
        }

        public ActionResult List()
        {
            List<ModelVozilaVM> lstModeli = new List<ModelVozilaVM>();

            try
            {
                lstModeli = VehicleService.DohvatiModele();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa modela vozila. Opis: " + ex.Message;
            }
            return View(lstModeli);
        }
        [HttpPost]
        public ActionResult List(int idMarke)
        {
            List<ModelVozilaVM> lstModeli = new List<ModelVozilaVM>();

            try
            {
                if (idMarke == 0)
                {
                    Response.Redirect("List");
                }
                else
                {
                    lstModeli = VehicleService.DohvatiListuModela(idMarke);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa modela vozila. Opis: " + ex.Message;
            }
            return View(lstModeli);
        }

        // GET: Model/Details/5
        public ActionResult Details(int idModela)
        {
            ModelVozilaVM model = new ModelVozilaVM();

            try
            {
                model = VehicleService.DohvatiModel(idModela);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja modela vozila. Opis: " + ex.Message;
            }

            return View(model);
        }

        // GET: Model/Create
        public ActionResult Create()
        {
            return View(new ModelVozilaVM());
        }

        // POST: Model/Create
        [HttpPost]
        public ActionResult Create(ModelVozilaVM model)
        {
            try
            {
                VehicleService.KreirajModel(model);
                ViewBag.Message = "Model uspješno kreiran!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod upisa modela! Opis: " + ex.Message;
            }
            return View(model);
        }

        // GET: Model/Edit/5
        public ActionResult Edit(int idModela)
        {
            ModelVozilaVM model = new ModelVozilaVM();

            try
            {
                model = VehicleService.DohvatiModel(idModela);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja modela! Opis: " + ex.Message;
            }

            return View(model);
        }

        // POST: Model/Edit/5
        [HttpPost]
        public ActionResult Edit(ModelVozilaVM model)
        {
            try
            {
                VehicleService.UrediModel(model);
                ViewBag.Message = "Model uspješno uređen!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja marke! Opis: " + ex.Message;
            }
            return View(model);
        }

        // GET: Model/Delete/5
        public ActionResult Delete(int idModela)
        {
            ModelVozilaVM model = new ModelVozilaVM();

            try
            {
                model = VehicleService.DohvatiModel(idModela);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja modela! Opis: " + ex.Message;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(ModelVozilaVM model)
        {
            try
            {
                VehicleService.IzbrisiModel(model.Id);
                TempData["Message"] = "Model uspješno izbrisan.";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Greška kod brisanja modela! Opis: " + ex.Message;
            }

            return RedirectToAction("List");
        }
    }
}
