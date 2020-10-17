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
    public interface IPesquisaService
    {
        Task<IList<Pesquisa>> TodosPorUsuarioAsync(int UsuarioId);
        Task<Pesquisa> BuscaPorId(int pesquisaId);
        Task<QueryResult<Pesquisa>> IncluirPesquisaAsync([FromForm] PesquisaModel model);
        Task<QueryResult<Pesquisa>> AtualizarPesquisaAsync(int pesquisaId, [FromBody] PesquisaModel model);
        Task<QueryResult<Pesquisa>> DeletarPesquisaAsync(int pesquisaId);
    }
}
