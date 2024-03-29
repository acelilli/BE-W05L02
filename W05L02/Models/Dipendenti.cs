﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W05L02.Models
{
    public class Dipendenti
    {
        public int IdDipendente { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        [Display(Name = "Codice fiscale:")]
        public string CF { get; set; }

        [Display(Name = "Sposato:")]
        public bool Coniugato { get; set; }

        [Display(Name = "Figli a carico:")]
        public int NFigliACarico { get; set; }
        public string Mansione { get; set; }

        public Dipendenti() { }
        // è qui che non mi serve id perchè generato automaticamente
        public Dipendenti(string nome, string cognome, string indirizzo, string cf, bool coniugato, int nfigli, string mansione)
        {
            Nome = nome;
            Cognome = cognome;
            Indirizzo = indirizzo;
            CF = cf;
            Coniugato = coniugato;
            NFigliACarico = nfigli;
            Mansione = mansione;
        }
    }
}