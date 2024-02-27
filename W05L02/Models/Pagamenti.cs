using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W05L02.Models
{
    public class Pagamenti
    {

        // sempre senza id del pagamento
        [Display(Name = "Num. Dipendente:")]
        public int IdDipendente { get; set; }

        [Display(Name = "Periodo del pagamento:")]
        public DateTime PeriodoPagamento { get; set; }

        [Display(Name = "Ammontare del pagamento:")]
        public decimal AmmontarePagamento { get; set; }

        [Display(Name = "Selezionare per stipendio:")]
        public bool TipoPagamento { get; set; }

        Pagamenti() { }
        Pagamenti(int idDipendente, DateTime periodopagamento, decimal ammontare, bool tipo)
        {
            IdDipendente = idDipendente;
            PeriodoPagamento = periodopagamento;
            AmmontarePagamento = ammontare;
            TipoPagamento = tipo;
        }
    }
}