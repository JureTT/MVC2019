using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adonet_spajanje_na_bazu.Controllers
{
    public class SqlCommandObjektController : Controller
    {
        // GET: SqlCommandObjekt
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Create()
        {
            //kreiramo connectionString i Connection objekt
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //Kreiramo SQL naredbu za upis
                string cmdText = "INSERT INTO tblTecajevi (naziv, opis) VALUES ('Web design', 'Naučite dizajnirati web stranice.')";

                //Kreiramo Command objekt i otvaramo vezu s bazom
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Connection.Open();

                //Komandu izvršavamo metodom ExecuteNonQuery();
                //Ako je zapis upisan u bazu, baza vraća 1 (jer je upisan jedan redak)
                int brojDodanihRedaka = cmd.ExecuteNonQuery();
                if (brojDodanihRedaka > 0)
                {
                    ViewBag.Message = "Zapis je upisan u bazu!";
                }
                else
                {
                    ViewBag.Message = "Dogodila se greška!";
                }
            }
            return View("Index");
        }
        public ActionResult Edit()
        {
            //kreiramo connectionString i Connection objekt
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //Kreiramo SQL naredbu za izmjenu zapisa
                string cmdText = "UPDATE tblTecajevi SET naziv = 'Web programiranje' WHERE idTecaj =1";    // mjenja samo sa prvi upis tj. sa id = 1

                //Kreiramo Command objekt i otvaramo vezu s bazom
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Connection.Open();

                //Komandu izvršavamo metodom ExecuteNonQuery();
                //Ako je došlo do promjene, baza vraća broj izmjenjenih zapisa
                int brojIzmjenjenihRedaka = cmd.ExecuteNonQuery();
                ViewBag.Message = "Broj izmijenjenih redaka: " + brojIzmjenjenihRedaka.ToString();
            }
            return View("Index");
        }
        public ActionResult Delete()
        {
            //kreiramo connectionString i Connection objekt
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //Kreiramo SQL naredbu za brisanje zapisa
                string cmdText = "DELETE FROM tblTecajevi WHERE idTecaj =1";  // briše samo sa prvi upis tj. sa id = 1

                //Kreiramo Command objekt i otvaramo vezu s bazom
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Connection.Open();

                //Komandu izvršavamo metodom ExecuteNonQuery();
                //Ako je došlo do promjene, baza vraća broj izmjenjenih zapisa
                int brojObrisanihRedaka = cmd.ExecuteNonQuery();
                ViewBag.Message = "Broj obrisanih redaka: " + brojObrisanihRedaka.ToString();
            }
            return View("Index"); //možda treba biti unutar vitičaste zagrade
        }
        public ActionResult Count()
        {
            //kreiramo connectionString i Connection objekt
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //Kreiramo SQL naredbu za prebrojavanje zapisa
                string cmdText = "SELECT COUNT(*) FROM tblTecajevi";

                //Kreiramo Command objekt i otvaramo vezu s bazom
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Connection.Open();

                //Komandu izvršavamo metodom ExecuteScalar();
                //jer očekujemo jednu vrijednost kao rezultat upisa
                int brojZapisa = (int)cmd.ExecuteScalar();
                ViewBag.Message = "Broj tečajeva u bazi je: " + brojZapisa.ToString();
            }
            return View("Index"); 
        }
    }
}