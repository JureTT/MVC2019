using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsPrimjer
{
    public partial class PozdravnaPoruka : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Obradi_Click(object sender, EventArgs e)
        {
            lblRezultat.Text = txtIme.Text;
        }
    }
}