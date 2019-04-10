using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADO_NET_Komponente.Models
{
    public class PolaznikModel
    {
        public int IdPolaznik { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
    }
}