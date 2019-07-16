using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mono_zadatak.Models
{
    public class MarkaVozila : IMarkaVozila
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        public string Kratica { get; set; }
    }
}