using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ViseslojnaAplikacija.Models
{
    public class TecajModel
    {
        public int IdTecaj { get; set; }
        [Required]
        public string Naziv { get; set; }
        [DataType(DataType.MultilineText)]
        public string Opis { get; set; }
    }
}