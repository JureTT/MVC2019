using Adresar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Adresar.WcfService.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(): base("AdresarBaza")
        {

        }
        public DbSet<Kontakt> Kontakti { get; set; }
    }
}