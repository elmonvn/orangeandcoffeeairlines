using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.Pagamento.Models
{
    public class CartaoModel
    {
        public int CartaoId { get; set; }
        public int UsuarioId { get; set; }
        public int QtdParcela { get; set; }

        public IList<CompraItemModel> Itens { get; set; }
    }
}
