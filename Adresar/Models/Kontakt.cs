using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adresar.Models
{
    public class Kontakt
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Ime ne smije biti veće od 25 znakova")]
        public string Ime { get; set; }
        [Required]
        [StringLength(25)]
        public string Prezime { get; set; }
        [StringLength(100)]
        public string Adresa { get; set; }
        [StringLength(20)]
        public string Telefon { get; set; }
        [StringLength(20)]
        public string Mobitel { get; set; }
        [StringLength(30)]
        public string Email { get; set; }

        public string Napomena { get; set; }

        public bool Aktivan { get; set; }
    }
}