using Adresar.KontaktService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adresar.Controllers
{
    public class KontaktiWSController : Controller
    {
        // GET: KontaktiWS
        public ActionResult Index()
        {
            KontaktServiceClient klijent = new KontaktServiceClient();

            List<Kontakt> kontakti = klijent.DohvatiAktivneKontakte().ToList();

            return View(kontakti);
        }
    }
}