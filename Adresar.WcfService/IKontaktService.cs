using Adresar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Adresar.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IKontaktService" in both code and config file together.
    [ServiceContract]
    public interface IKontaktService
    {
        [OperationContract]
        List<Kontakt> DohvatiAktivneKontakte();
    }
}
