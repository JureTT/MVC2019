using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ispit_ASPNET.Models
{
    public class Poklon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Ime { get; set; }
        [StringLength(50)]
        public string Marka { get; set; }

        public int Kolicina { get; set; }
        [DataType(DataType.Currency)]
        public decimal Cijena { get; set; }

        public string Napomena { get; set; }

        public bool Kupljeno { get; set; }
    }
}