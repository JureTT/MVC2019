using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adonet_spajanje_na_bazu.Models
{
    public class Tecaj
    {
        public int Id { get; internal set; }
        public string Naziv { get; internal set; }
        public string Opis { get; internal set; }
    }
}