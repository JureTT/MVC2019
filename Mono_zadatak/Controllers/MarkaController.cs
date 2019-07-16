using AutoMapper;
using Mono_zadatak.Models;
using Mono_zadatak.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mono_zadatak.Controllers
{
    public class MarkaController : Controller
    {        
        // GET: Marka
        public string Index()
        {            
            return "Ovo je nije početna stranica, ukucati \"List\" kako bi dobili početnu stranicu. ";
        }

        public ActionResult List()
        {
            List<MarkaVozilaVM> lstMarke = new List<MarkaVozilaVM>();

            try
            {
                lstMarke = VehicleService.DohvatiMarke();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa marki vozila. Opis: " + ex.Message;
            }
            return View(lstMarke);
        }

        // GET: Marka/Details/5
        public ActionResult Details(int idMarke)
        {
            MarkaVozilaVM marka = new MarkaVozilaVM();

            try
            {
                marka = VehicleService.DohvatiMarku(idMarke);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja marke vozila. Opis: " + ex.Message;
            }

            return View(marka);
        }

        // GET: Marka/Create
        public ActionResult Create()
        {
            return View(new MarkaVozilaVM());
        }

        // POST: Marka/Create
        [HttpPost]
        public ActionResult Create(MarkaVozilaVM marka)
        {
            try
            {
                VehicleService.KreirajMarku(marka);
                ViewBag.Message = "Marka je uspješno upisana!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod upisa marke! Opis: " + ex.Message; 
            }
            return View(marka);
        }

        // GET: Marka/Edit/5
        public ActionResult Edit(int idMarke)
        {
            MarkaVozilaVM marka = new MarkaVozilaVM();

            try
            {
                marka = VehicleService.DohvatiMarku(idMarke);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja marke! Opis: " + ex.Message;
            }

            return View(marka);
        }

        // POST: Marka/Edit/5
        [HttpPost]
        public ActionResult Edit(MarkaVozilaVM marka)
        {
            try
            {
                VehicleService.UrediMarku(marka);
                ViewBag.Message = "Marka uspješno uređena!";
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja marke! Opis: " + ex.Message;
            }
            return View(marka);
        }

        // GET: Marka/Delete/5
        public ActionResult Delete(int idMarke)
        {
            MarkaVozilaVM marka = new MarkaVozilaVM();

            try
            {
                marka = VehicleService.DohvatiMarku(idMarke);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja marke! Opis: " + ex.Message;
            }
            return View(marka);
        }
        [HttpPost]
        public ActionResult Delete(MarkaVozilaVM marka)
        {
            try
            {
                VehicleService.IzbrisiMarku(marka.Id);
                TempData["Message"] = "Marka uspješno izbrisana.";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Greška kod brisanja marke! Opis: " + ex.Message;
            }

            return RedirectToAction("List");
        }
    }
}
