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
    public interface IFavoritaService
    {
        Task<IList<Favorita>> TodosPorUsuarioAsync(int UsuarioId);
        Task<Favorita> BuscaPorId(int pesquisaId);
        Task<QueryResult<Favorita>> IncluirFavoritaAsync([FromForm] FavoritaModel model);
        Task<QueryResult<Favorita>> AtualizarFavoritaAsync(int pesquisaId, [FromBody] FavoritaModel model);
        Task<QueryResult<Favorita>> DeletarFavoritaAsync(int pesquisaId);
    }
}
