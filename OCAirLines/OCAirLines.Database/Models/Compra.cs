using System;
using System.Collections.Generic;
using System.Text;

namespace OCAirLines.Database.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int CartaoId { get; set; }
        public DateTime DtCompra { get; set; }
        public int QtdParcela { get; set; } 
        public bool Status { get; set; }

        public Usuario Usuario { get; set; }
        public Cartao Cartao { get; set; }

        public ICollection<CompraItem> Itens { get; set; }
    }
}
