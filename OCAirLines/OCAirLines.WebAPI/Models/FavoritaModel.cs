using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.WebAPI.Models
{
    public class FavoritaModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int EmpresaId { get; set; }
        public string Empresa { get; set; }
        public int OrigemId { get; set; }
        public string Origem { get; set; }
        public int DestinoId { get; set; }
        public string Destino { get; set; }
        public decimal Preco { get; set; }
        public DateTime DtSaida { get; set; }
        public DateTime DtChegada { get; set; }
    }
}
