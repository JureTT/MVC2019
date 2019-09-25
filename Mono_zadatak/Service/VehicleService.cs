using Mono_zadatak.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Mono_zadatak.Service
{
    public class VehicleService
    {
        /////// --- AUTOMAPER PROBA --- //////
        MapperConfiguration configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<MarkaVozila, MarkaVozilaVM>();
            cfg.CreateMap<ModelVozila, ModelVozilaVM>();
            cfg.CreateMap<MarkaVozilaVM, MarkaVozila>();
            cfg.CreateMap<ModelVozilaVM, ModelVozila>();
            cfg.CreateMap<ModelVozila, VozilaFull>()
            .ForMember(dest => dest.IdModel, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IdMarka, opt => opt.MapFrom(src => src.IdMarke))
            .ForMember(dest => dest.NazivModel, opt => opt.MapFrom(src => src.Naziv)) 
            .ForMember(dest => dest.Kratica, opt => opt.MapFrom(src => src.Kratica))
            ;

        });
        IMapper maper => configuration.CreateMapper();

        MarkaVozila objekt = new MarkaVozila();
        MarkaVozilaVM objektVM => maper.Map<MarkaVozilaVM>(objekt);

        //public static DataSet ds { get; set; }
        //public static string cs = ConfigurationManager.ConnectionStrings["VozilaDbContext"].ConnectionString;
        public static VozilaDbContext _db = new VozilaDbContext();

        static VehicleService servis = new VehicleService();

        public static List<VozilaFull> DohvatiVozila()
        {
            List<VozilaFull> lista = (from model in _db.ModeliVozila
                                      join marka in _db.MarkeVozila 
                                      on model.IdMarke equals marka.Id 
                                      select new VozilaFull
                                      {
                                          IdMarka = marka.Id,
                                          NazivMarka = marka.Naziv,
                                          Kratica = marka.Kratica,
                                          IdModel = model.Id,
                                          NazivModel = model.Naziv
                                      }).ToList();
            return lista;
        }

        #region MarkaCRUD
        public List<MarkaVozilaVM> DohvatiMarkeVM()
        {
            List<MarkaVozila> kolekcija = (from item in _db.MarkeVozila select item).ToList();
            List<MarkaVozilaVM> kolekcijaVM = maper.Map<List<MarkaVozilaVM>>(kolekcija);            
            return kolekcijaVM;
        }        
        public static List<MarkaVozilaVM> DohvatiMarke()
        {
            //List<MarkaVozila> kolekcija = new List<MarkaVozila>();

            //ds = SqlHelper.ExecuteDataset(cs, "DohvatiPolaznike");

            //foreach (DataRow row in ds.Tables[0].Rows)
            //{
            //    MarkaVozila polaznik = new MarkaVozila(false);  //dodan unutar zagrada true ili false za aktivaciju kostruktora grada
            //    polaznik.IdPolaznik = (int)row["IdPolaznik"];
            //    polaznik.Ime = row["Ime"].ToString();
            //    polaznik.Prezime = row["Prezime"].ToString();
            //    polaznik.Email = row["Email"].ToString();
            //    kolekcija.Add(polaznik);
            //}

            return servis.DohvatiMarkeVM();
        }

        public MarkaVozilaVM DohvatiMarkuVM(int idMarka)
        {
            MarkaVozila marka = _db.MarkeVozila.Find(idMarka);
            MarkaVozilaVM markaVM = maper.Map<MarkaVozilaVM>(marka);
            return markaVM;
        }
        public static MarkaVozilaVM DohvatiMarku(int idMarka)
        {            
            //ds = SqlHelper.ExecuteDataset(cs, "DohvatiPolaznika", idPolaznik);
            //DataRow row = ds.Tables[0].Rows[0];

            //MarkaVozila polaznik = new MarkaVozila(false); //dodan unutar zagrada true ili false za aktivaciju kostruktora grada
            //polaznik.IdPolaznik = (int)row["IdPolaznik"];
            //polaznik.Ime = row["Ime"].ToString();
            //polaznik.Prezime = row["Prezime"].ToString();
            //polaznik.Email = row["Email"].ToString();

            return servis.DohvatiMarkuVM(idMarka);
        }

        public void UrediMarkuVM(MarkaVozilaVM marka)
        {

            MarkaVozila novo = maper.Map<MarkaVozila>(marka);
            MarkaVozila orginal = _db.MarkeVozila.Find(novo.Id);
            //_db.Entry(marka).State = EntityState.Modified;    //-- ne radi
            _db.Entry(orginal).CurrentValues.SetValues(novo);
            _db.SaveChanges();
            //SqlHelper.ExecuteNonQuery(cs, "UrediPolaznika", polaznik.IdPolaznik, polaznik.Ime, polaznik.Prezime, polaznik.Email);
        }
        public static void UrediMarku(MarkaVozilaVM marka)
        {
            servis.UrediMarkuVM(marka);
        }

        public object KreirajMarkuVM(MarkaVozilaVM marka)
        {
            MarkaVozila orginal = maper.Map<MarkaVozila>(marka);
            _db.MarkeVozila.Add(orginal);
            _db.SaveChanges();
            //var id = SqlHelper.ExecuteScalar(cs, "KreirajPolaznika", polaznik.Ime, polaznik.Prezime, polaznik.Email);
            return marka;
        }
        public static object KreirajMarku(MarkaVozilaVM marka)
        {            
            return servis.KreirajMarkuVM(marka);
        }

        public static void IzbrisiMarku(int idMarke)
        {
            MarkaVozila marka = _db.MarkeVozila.Find(idMarke);
            _db.MarkeVozila.Remove(marka);
            _db.SaveChanges();
            //SqlHelper.ExecuteNonQuery(cs, "IzbrisiPolaznika", idPolaznik);
        }
        
        #endregion

        #region ModelCRUD
        public List<ModelVozilaVM> DohvatiModeleVM()
        {
            List<ModelVozila> kolekcija = (from item in _db.ModeliVozila select item).ToList();
            List<ModelVozilaVM> kolekcijaVM = maper.Map<List<ModelVozilaVM>>(kolekcija);
            return kolekcijaVM;
        }
        public static List<ModelVozilaVM> DohvatiModele()
        {
            return servis.DohvatiModeleVM();
        }
        public List<ModelVozilaVM> DohvatiListuModelaVM(int idMarke)
        {
            List<ModelVozila> kolekcija = (from item in _db.ModeliVozila where item.IdMarke == idMarke select item).ToList();
            List<ModelVozilaVM> kolekcijaVM = maper.Map<List<ModelVozilaVM>>(kolekcija);           
            return kolekcijaVM;
        }
        public static List<ModelVozilaVM> DohvatiListuModela(int idMarke)
        {
            return servis.DohvatiListuModelaVM(idMarke);
        }

        public ModelVozilaVM DohvatiModelVM(int idModela)
        {
            ModelVozila model = _db.ModeliVozila.Find(idModela);
            ModelVozilaVM modelVM = maper.Map<ModelVozilaVM>(model);
            return modelVM;
        }
        public static ModelVozilaVM DohvatiModel(int idModela)
        {
            return servis.DohvatiModelVM(idModela);
        }

        public void UrediModelVM(ModelVozilaVM model)
        {
            ModelVozila novo = maper.Map<ModelVozila>(model);
            ModelVozila orginal = _db.ModeliVozila.Find(novo.Id);
            _db.Entry(orginal).CurrentValues.SetValues(novo);
            _db.SaveChanges();
        }
        public static void UrediModel(ModelVozilaVM model)
        {
            servis.UrediModelVM(model);
        }

        public object KreirajModelVM(ModelVozilaVM model)
        {
            ModelVozila orginal = maper.Map<ModelVozila>(model);
            _db.ModeliVozila.Add(orginal);
            _db.SaveChanges();
            return model;
        }
        public static object KreirajModel(ModelVozilaVM model)
        {            
            return servis.KreirajModelVM(model);
        }

        public static void IzbrisiModel(int idModela)
        {
            ModelVozila model = _db.ModeliVozila.Find(idModela);
            _db.ModeliVozila.Remove(model);
            _db.SaveChanges();
        }
        #endregion
    }
}