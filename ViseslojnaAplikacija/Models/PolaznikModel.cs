using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ViseslojnaAplikacija.Models
{
    public class PolaznikModel
    {
        public int IdPolaznik { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Grad")]
        public int IdGrad { get; set; }

        public List<GradModel> lstGradovi { get; set; }

        public static DataSet ds { get; set; }
        public static string cs = ConfigurationManager.ConnectionStrings["ViseslojnaAplikacijaContext"].ConnectionString;

        public PolaznikModel()
        {

        }
        public PolaznikModel(bool isSingle)
        {
            if (isSingle)
            {
                lstGradovi = new List<GradModel>();
                ds = SqlHelper.ExecuteDataset(cs, CommandType.Text, "SELECT * FROM tblGradovi");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    GradModel grad = new GradModel();
                    grad.IdGrad = int.Parse(row["IdGrad"].ToString());
                    grad.Naziv = row["Naziv"].ToString();
                    lstGradovi.Add(grad);
                }
            }
        }
    }
}