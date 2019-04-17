using Adresar.Models;
using Adresar.WcfService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Adresar.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "KontaktService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select KontaktService.svc or KontaktService.svc.cs at the Solution Explorer and start debugging.
    public class KontaktService : IKontaktService
    {
        ApplicationDbContext _db = new ApplicationDbContext();

        public List<Kontakt> DohvatiAktivneKontakte()
        {
            var aktivniKontakti = from k in _db.Kontakti where k.Aktivan select k;
            return aktivniKontakti.ToList();
        }
    }
}
