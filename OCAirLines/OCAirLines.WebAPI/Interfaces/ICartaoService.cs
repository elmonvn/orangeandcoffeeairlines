using Microsoft.AspNetCore.Mvc;
using OCAirLines.Database.Helpers;
using OCAirLines.Database.Models;
using OCAirLines.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.WebAPI.Interfaces
{
    public interface ICartaoService
    {
        Task<IList<Cartao>> TodosPorUsuarioAsync(int UsuarioId);
        Task<Cartao> BuscaPorId(int cartaoId);
        Task<QueryResult<Cartao>> IncluirCartaoAsync([FromForm] CartaoModel model);
        Task<QueryResult<Cartao>> AtualizarCartaoAsync(int cartaoId, [FromBody] CartaoModel model);
        Task<QueryResult<Cartao>> DeletarCartaoAsync(int cartaoId);
    }
}
