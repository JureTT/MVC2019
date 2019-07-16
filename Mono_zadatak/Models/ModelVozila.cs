using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mono_zadatak.Models
{
    public class ModelVozila : IModelVozila
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdMarke { get; set; }
        public virtual MarkaVozila MarkaVozila { get; set; }
        [Required]
        public string Naziv { get; set; }
        public string Kratica { get; set; }
    }
}