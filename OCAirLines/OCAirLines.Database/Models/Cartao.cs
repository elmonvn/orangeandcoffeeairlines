using System;
using System.Collections.Generic;
using System.Text;

namespace OCAirLines.Database.Models
{
    public class Cartao
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Bandeira { get; set; }
        public string Numero { get; set; }
        public string CodSeguranca { get; set; }
        public string Vencimento { get; set; }
        public bool Status { get; set; }

        public Usuario Usuario { get; set; }

        public ICollection<Compra> Compras { get; set; }
    }
}
