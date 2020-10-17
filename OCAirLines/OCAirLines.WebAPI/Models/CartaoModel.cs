using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.WebAPI.Models
{
    public class CartaoModel
    {
        public int UsuarioId { get; set; }
        public string Bandeira { get; set; }
        public string Numero { get; set; }
        public string CodSeguranca { get; set; }
        public string Vencimento { get; set; }
        public bool Status { get; set; }
    }
}
