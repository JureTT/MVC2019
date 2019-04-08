using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adonet_spajanje_na_bazu.Controllers
{
    public class SqlConnectionObjektController : Controller
    {
        // GET: SqlConnectionObjekt direktno
        public ActionResult Index()
        {
            //Prvo kreiramo conn string
            string connString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = dbAlgebra; Integrated Security = True"; //koristi uvijek @ (monkey)

            // Nakon toga instanca SqlConnection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                if(conn.State == System.Data.ConnectionState.Open)
                {
                    Response.Write("Konekcija je uspjela");
                }
            }
            catch (SqlException sqlex)
            {
                Response.Write("Greška spajanja na bazu" + sqlex.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("Neka greška" + ex.ToString());
            }
            finally
            {
                // Kad obavimo sve operacije u bazi, konekciju uvijek trebamo zatvoriti
                conn.Close();
            }

            return View();
        }
        // GET: SqlConnectionObjekt direktno preko Web.config
        public ActionResult SpojPrekoWebConfig()
            {
            //Prvo kreiramo conn string
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnString"].ConnectionString;  //umjesto nule može i ime connection stringa

                // Nakon toga instanca SqlConnection
                SqlConnection conn = new SqlConnection(connString);

                try
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        Response.Write("Konekcija je uspjela");
                    }
                }
                catch (SqlException sqlex)
                {
                    Response.Write("Greška spajanja na bazu" + sqlex.ToString());
                }
                catch (Exception ex)
                {
                    Response.Write("Neka greška" + ex.ToString());
                }
                finally
                {
                    // Kad obavimo sve operacije u bazi, konekciju uvijek trebamo zatvoriti
                    conn.Close();
                }

            return View();
        }
    }
}