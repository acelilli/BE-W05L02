using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W05L02.Models;

namespace W05L02.Controllers
{
    public class DipendentiController : Controller
    {
        // GET: Dipendenti
        public ActionResult Index()
        { // 1. Creo connessione + lista
            string connectionString = ConfigurationManager.ConnectionStrings["DipendentiPagamenti"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            // qui lista
            //creo una lista di tipo Dipendenti (model) chiamata dipendentiList
            List<Dipendenti> dipendentiList = new List<Dipendenti>();
            try 
            {
                conn.Open();
                string query = "SELECT * FROM Dipendenti";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                // creo ciclo while per leggere i dati dal database e inserirli in una lista di oggetti Dipendente
                while (reader.Read())
                {
                    //creo un oggetto Dipendente chiamato dipendente
                    Dipendenti dipendente = new Dipendenti
                    {
                        // IdDipendente = Convert.ToInt32(reader["ID"]),
                        Nome = reader["Nome"].ToString(),
                        Cognome = reader["Cognome"].ToString(),
                        Indirizzo = reader["Indirizzo"].ToString(),
                        CF = reader["CF"].ToString(),
                        Coniugato = Convert.ToBoolean(reader["Coniugato"]),
                        NFigliACarico = Convert.ToInt32(reader["NFigliACarico"]),
                        Mansione = reader["Mansione"].ToString()
                    };
                    //aggiungo l'oggetto alla lista
                    dipendentiList.Add(dipendente);
                }
            }
            catch (Exception ex)
            {
                   ViewBag.ErrorMessage = "Si è verificato un errore durante l'inserimento: " + ex.Message;
            } finally {
                conn.Close();
            }
            return View(dipendentiList);
        }

        public ActionResult CreateDipendenti() {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDipendenti(Dipendenti dipendente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DipendentiPagamenti"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                // query per passare tutti i dati nel database tramite i parametri 
                string query = "INSERT INTO DatiDipendenti (Nome, Cognome, CF, Indirizzo, Coniugato, NFigliACarico, Mansione) " +
                    "VALUES (@Nome, @Cognome, @CF, @Indirizzo, @Coniugato, @NFigliACarico, @Mansione,)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", dipendente.Nome);
                cmd.Parameters.AddWithValue("@Cognome", dipendente.Cognome);
                cmd.Parameters.AddWithValue("@CF", dipendente.CF);
                cmd.Parameters.AddWithValue("@Indirizzo", dipendente.Indirizzo);
                cmd.Parameters.AddWithValue("@Coniugato", dipendente.Coniugato);
                cmd.Parameters.AddWithValue("@NFigliACarico", dipendente.NFigliACarico);
                cmd.Parameters.AddWithValue("@Mansione", dipendente.Mansione);
                cmd.ExecuteNonQuery();

                ViewBag.Message = "Inserimento riuscito!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Si è verificato un errore di connessione durante l'inserimento: " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return View("CreateDipendenti");
        }

    }
}