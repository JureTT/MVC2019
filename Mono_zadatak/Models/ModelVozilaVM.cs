using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mono_zadatak.Models
{
    public class ModelVozilaVM
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdMarke { get; set; }
        [Required]
        public string Naziv { get; set; }
        public string Kratica { get; set; }
    }
}