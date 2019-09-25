using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mono_zadatak.Models
{
    public class VozilaFull
    {
        public int IdModel { get; set; }
        public string NazivModel { get; set; }
        public string Kratica { get; set; }
        public int IdMarka { get; set; }
        public string NazivMarka { get; set; }        
    }
}