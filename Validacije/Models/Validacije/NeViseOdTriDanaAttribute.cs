using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Validacije.Models.Validacije
{
    public class NeViseOdTriDanaAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is MetaRacun)
            {
                MetaRacun mr = (MetaRacun)value;
                if (mr.Datum < DateTime.Today.AddDays(-3))
                {
                    return false;
                }                
            }
            return true;
        }
    }
}