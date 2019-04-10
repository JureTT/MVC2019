using Adonet_spajanje_na_bazu.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adonet_spajanje_na_bazu.Controllers
{
    public class SqlDataReaderObjektController : Controller
    {
        // GET: SqlDataReaderObjekt
        public ActionResult Index()
        {
            //kreiramo connectionString i Connection objekt
            List<Tecaj> lstTecajevi = new List<Tecaj>();
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //Kreiramo SQL naredbu za upis
                string cmdText = "SELECT * FROM tblTecajevi";

                //Kreiramo Command objekt i otvaramo vezu s bazom
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Connection.Open();

                //Komandu izvršavamo pozivom ExecuteReader();
                //koja kreira SqlDataReader objekt
                SqlDataReader reader = cmd.ExecuteReader();

                //Ako je pozivom metode kreiran SqlDataReader objekt
                if (reader != null)
                {
                    //i ako ima redaka za čitanje
                    if (reader.HasRows)
                    {
                        //Dok ima podataka u readeru, dodajemo ih u listu
                        while (reader.Read())
                        {
                            //Kreiramo novi Tecaj objekt
                            Tecaj tecaj = new Tecaj();

                            //Postavljamo mu svojstva
                            tecaj.Id = int.Parse(reader["IdTecaj"].ToString());
                            tecaj.Naziv = reader["Naziv"].ToString();
                            tecaj.Opis = reader["Opis"].ToString();

                            //Dodajemo tecaj u listu lstTecajevi
                            lstTecajevi.Add(tecaj);
                        }
                    }
                }
                reader.Close();
            }
            return View(lstTecajevi);
        }
    }
}