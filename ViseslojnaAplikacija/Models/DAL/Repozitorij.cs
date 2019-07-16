using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ViseslojnaAplikacija.Models.DAL
{
    public class Repozitorij
    {
        public static DataSet ds { get; set; }
        public static string cs = ConfigurationManager.ConnectionStrings["ViseslojnaAplikacijaContext"].ConnectionString;

        #region PolazniciCRUD
        public static List<PolaznikModel> DohvatiPolaznike()
        {
            List<PolaznikModel> kolekcija = new List<PolaznikModel>();

            ds = SqlHelper.ExecuteDataset(cs, "DohvatiPolaznike");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                PolaznikModel polaznik = new PolaznikModel(false);  //dodan unutar zagrada true ili false za aktivaciju kostruktora grada
                polaznik.IdPolaznik = (int)row["IdPolaznik"];
                polaznik.Ime = row["Ime"].ToString();
                polaznik.Prezime = row["Prezime"].ToString();
                polaznik.Email = row["Email"].ToString();
                kolekcija.Add(polaznik);
            }

            return kolekcija;
        }

        public static PolaznikModel DohvatiPolaznika(int idPolaznik)
        {
            ds = SqlHelper.ExecuteDataset(cs, "DohvatiPolaznika", idPolaznik);
            DataRow row = ds.Tables[0].Rows[0];

            PolaznikModel polaznik = new PolaznikModel(false); //dodan unutar zagrada true ili false za aktivaciju kostruktora grada
            polaznik.IdPolaznik = (int)row["IdPolaznik"];
            polaznik.Ime = row["Ime"].ToString();
            polaznik.Prezime = row["Prezime"].ToString();
            polaznik.Email = row["Email"].ToString();

            return polaznik;
        }

        public static void UrediPolaznika(PolaznikModel polaznik)
        {
            SqlHelper.ExecuteNonQuery(cs, "UrediPolaznika", polaznik.IdPolaznik, polaznik.Ime, polaznik.Prezime, polaznik.Email);
        }

        public static object KreirajPolaznika(PolaznikModel polaznik)
        {
            var id = SqlHelper.ExecuteScalar(cs, "KreirajPolaznika", polaznik.Ime, polaznik.Prezime, polaznik.Email);
            return id;
        }

        public static void IzbrisiPolaznika(int idPolaznik)
        {
            SqlHelper.ExecuteNonQuery(cs, "IzbrisiPolaznika", idPolaznik);
        }
        #endregion

        #region TecajCRUD
        public static List<TecajModel> DohvatiTecajeve()
        {
            List<TecajModel> kolekcija = new List<TecajModel>();

            ds = SqlHelper.ExecuteDataset(cs, "DohvatiTecajeve");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                TecajModel tecaj = new TecajModel();
                tecaj.IdTecaj = (int)row["IdTecaj"];
                tecaj.Naziv = row["Naziv"].ToString();
                tecaj.Opis = row["Opis"].ToString();
                kolekcija.Add(tecaj);
            }

            return kolekcija;
        }

        public static TecajModel DohvatiTecaj(int idTecaj)
        {
            ds = SqlHelper.ExecuteDataset(cs, "DohvatiTecaj", idTecaj);
            DataRow row = ds.Tables[0].Rows[0];

            TecajModel tecaj = new TecajModel();
            tecaj.IdTecaj = (int)row["IdTecaj"];
            tecaj.Naziv = row["Naziv"].ToString();
            tecaj.Opis = row["Opis"].ToString();

            return tecaj;
        }

        public static void UrediTecaj(TecajModel tecaj)
        {
            SqlHelper.ExecuteNonQuery(cs, "UrediTecaj", tecaj.IdTecaj, tecaj.Naziv, tecaj.Opis);
        }

        public static object KreirajTecaj(TecajModel tecaj)
        {
            var id = SqlHelper.ExecuteScalar(cs, "KreirajTecaj", tecaj.Naziv, tecaj.Opis);
            return id;
        }

        public static void IzbrisiTecaj(int idTecaj)
        {
            SqlHelper.ExecuteNonQuery(cs, "IzbrisiTecaj", idTecaj);
        }
        #endregion
    }
}