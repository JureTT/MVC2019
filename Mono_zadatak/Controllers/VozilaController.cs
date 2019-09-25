using Mono_zadatak.Models;
using Mono_zadatak.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mono_zadatak.Controllers
{
    public class VozilaController : Controller
    {

        // GET: Vozila
        public ActionResult List()
        {
            List<VozilaFull> lstVozila = new List<VozilaFull>();
            lstVozila = VehicleService.DohvatiVozila();
            return View(lstVozila);
        }
    }
}
