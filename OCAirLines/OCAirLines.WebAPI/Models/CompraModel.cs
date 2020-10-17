using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.WebAPI.Models
{
    public class CompraModel
    {
        public int UsuarioId { get; set; }
        public int CartaoId { get; set; }
        public DateTime DtCompra { get; set; }
        public int QtdParcela { get; set; }
        public bool Status { get; set; }

    }
}
