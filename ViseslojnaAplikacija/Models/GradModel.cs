using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViseslojnaAplikacija.Models
{
    public class GradModel
    {
        public int IdGrad { get; set; }
        public string Naziv { get; set; }
        public int IdDrzava { get; set; }
    }
}