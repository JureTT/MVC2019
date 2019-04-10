using ADO_NET_Komponente.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADO_NET_Komponente.Controllers
{
    public class ADONETKomponenteController : Controller
    {
        string connStr = ConfigurationManager.ConnectionStrings["dbAlgebraConnString"].ConnectionString;

        // GET: ADONETKomponente
        public ActionResult List()
        {
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cm = new SqlCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM tblPolaznici";

            SqlDataReader dr = null;
            List<PolaznikModel> lstPolaznici = new List<PolaznikModel>();

            try
            {
                conn.Open();

                dr = cm.ExecuteReader();

                //provjeravamo dal DataReader postoji
                if (dr != null)
                {
                    // ako postoji provjeri dal ima redova za pročitati
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            // kreiramo novi objekt PolaznikModel i dodajemo ga u listu lstPolaznici
                            PolaznikModel polaznik = new PolaznikModel();
                            polaznik.IdPolaznik = int.Parse(dr["IdPolaznik"].ToString());
                            polaznik.Ime = dr["Ime"].ToString();
                            polaznik.Prezime = dr["Prezime"].ToString();
                            polaznik.Email = dr["Email"].ToString();
                            lstPolaznici.Add(polaznik);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja polaznika!. Opis: " + ex.ToString();
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                cm.Dispose();
            }
            return View(lstPolaznici);
        }

        // GET: ADONETKomponente
        //[HttpGet]
        public ActionResult Details(int idPolaznik)
        {
            SqlConnection conn = new SqlConnection(connStr);

            string cmdText = "SELECT * FROM tblPolaznici WHERE IdPolaznik = @IdPolaznik";

            SqlCommand cmd = new SqlCommand(cmdText, conn);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@IdPolaznik";
            param.DbType = DbType.Int32;
            param.Direction = ParameterDirection.Input;
            param.Value = idPolaznik;
            cmd.Parameters.Add(param);

            SqlDataReader dr = null;
            PolaznikModel polaznik = new PolaznikModel();

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                if(dr != null)
                {
                    if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            polaznik.IdPolaznik = int.Parse(dr["IdPolaznik"].ToString());
                            polaznik.Ime = dr["Ime"].ToString();
                            polaznik.Prezime = dr["Prezime"].ToString();
                            polaznik.Email = dr["Email"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja polaznika! Opis: " + ex.Message;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                cmd.Dispose();
            }
            return View(polaznik);
        }

        // GET: ADONETKomponente
        [HttpGet]
        public ActionResult Create()
        {
            return View(new PolaznikModel());
        }

        // POST: ADONETKomponente
        [HttpPost]
        public ActionResult Create(PolaznikModel model)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string cmdText = "INSERT INTO tblPolaznici (Ime, Prezime, Email) VALUES ('" +
                        model.Ime + "', '" + model.Prezime + "', '" + model.Email + "') ";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Connection.Open();

                    int brojDodanihRedaka = cmd.ExecuteNonQuery();
                    ViewBag.Message = "Broj dodanih redaka : " + brojDodanihRedaka;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod opisa polaznika! Opis: " + ex.ToString();
            }
            return View(model);
        }
        // GET: ADONETKomponente
        //[HttpGet]
        public ActionResult Edit(int idPolaznik)
        {
            SqlConnection conn = new SqlConnection(connStr);

            string cmdText = "SELECT * FROM tblPolaznici WHERE IdPolaznik = @IdPolaznik";

            SqlCommand cmd = new SqlCommand(cmdText, conn);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@IdPolaznik";
            param.DbType = DbType.Int32;
            param.Direction = ParameterDirection.Input;
            param.Value = idPolaznik;
            cmd.Parameters.Add(param);

            SqlDataReader dr = null;
            PolaznikModel polaznik = new PolaznikModel();

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            polaznik.IdPolaznik = int.Parse(dr["IdPolaznik"].ToString());
                            polaznik.Ime = dr["Ime"].ToString();
                            polaznik.Prezime = dr["Prezime"].ToString();
                            polaznik.Email = dr["Email"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja polaznika! Opis: " + ex.Message;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                cmd.Dispose();
            }
            return View(polaznik);
        }
        // GET: ADONETKomponente
        [HttpPost]
        public ActionResult Edit(PolaznikModel model)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string cmdText = "UPDATE tblPolaznici SET Ime = '" + model.Ime + "', Prezime = '" + model.Prezime + "', Email = '" + model.Email 
                        + "' WHERE IdPolaznik = " + model.IdPolaznik;
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Connection.Open();

                    int brojDodanihRedaka = cmd.ExecuteNonQuery();
                    if (brojDodanihRedaka > 0)
                    {
                        ViewBag.Message = "Zapis je upisan u bazu!";
                    }
                    else
                    {
                        ViewBag.Message = "Dogodila se graška!";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja opisa polaznika! Opis: " + ex.ToString();
            }
            return View(model);
        }
        // GET: ADONETKomponente
        //[HttpGet]
        public ActionResult Delete(int idPolaznik)
        {
            SqlConnection conn = new SqlConnection(connStr);

            string cmdText = "DELETE FROM tblPolaznici WHERE IdPolaznik = " + idPolaznik;

            SqlCommand cmd = new SqlCommand(cmdText, conn);

            try
            {
                cmd.Connection.Open();

                int brojBrisanihRedaka = cmd.ExecuteNonQuery();
                TempData["Message"] = "Broj izbrisanih redaka: " + brojBrisanihRedaka;
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja polaznika! Opis: " + ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                cmd.Dispose();
            }
            return RedirectToAction("List");
        }
    }
}