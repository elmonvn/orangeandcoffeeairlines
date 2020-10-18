using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.Passagem.ViewModel
{
    public class BuscaPassagem
    {
        public string LocalOrigem { get; set; }
        public string LocalDestino { get; set; }
        public string TipoCabine { get; set; }
        public DateTime DataIda { get; set; }
        public DateTime DataVolta { get; set; }
    }
}
