using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mono_zadatak.Models
{
    public class VozilaDbContext:DbContext
    {
        public DbSet<MarkaVozila> MarkeVozila { get; set; }
        public DbSet<ModelVozila> ModeliVozila { get; set; }
    }
}