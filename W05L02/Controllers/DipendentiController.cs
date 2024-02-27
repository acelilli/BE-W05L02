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
        {
            return View();
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
            }
            catch (SqlException ex)
            {
                ViewBag.Message = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return RedirectToAction("Index");
        }

    }
}