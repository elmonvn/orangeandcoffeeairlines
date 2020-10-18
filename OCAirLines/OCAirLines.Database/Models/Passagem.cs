using System;
using System.Collections.Generic;
using System.Text;

namespace OCAirLines.Database.Models
{
    public class Passagem
    {
        public int Id { get; set; }
        public string Companhia { get; set; }
        public string  LocalOrigem { get; set; }
        public string LocalDestino { get; set; }
        public decimal Preco { get; set; }
        public string Classificacao { get; set; }
        public string TipoCabine { get; set; }
        public string DuracaoViagem { get; set; }
        public DateTime DataOrigem { get; set; }
        public DateTime DataDestino { get; set; }
    }
}
