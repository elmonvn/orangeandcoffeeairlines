using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.Passagem.ViewModel
{
    public class Voos
    {
        public string LocalOrigem { get; set; }
        public string LocalDestino { get; set; }
        public string Companhia { get; set; }
        public string Preco { get; set; }
        public string DataIda { get; set; }
        public string DataVolta { get; set; }
    }
}
