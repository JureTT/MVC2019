using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Validacije.Models.Validacije;

namespace Validacije.Models
{
    [NeViseOdTriDana(ErrorMessage = "Datum ne smije biti manji za više od 3 dana!")]
    public class MetaRacun
    {
        [Required(ErrorMessage = "Broj računa je obavezan!")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Duljina računa mora biti između 3 i 10 znakova!")]
        public string BrojRacuna { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Datum { get; set; }

        [Required(ErrorMessage = "Zaposlenik je obavezan!")]
        public string Zaposlenik { get; set; }

        [Required(ErrorMessage = "Kupac je obavezan!")]
        public string Kupac { get; set; }

        [Range(1, 1000, ErrorMessage = "Cijena mora biti unutar intervala [1 - 1000] !")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Cijena { get; set; }

    }
}