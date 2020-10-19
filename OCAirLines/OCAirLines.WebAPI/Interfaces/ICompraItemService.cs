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
    public interface ICompraItemService
    {
        Task<IList<CompraItem>> TodosPorCompraAsync(int compraId);
        Task<CompraItem> BuscaPorId(int compraItemId);
        Task<QueryResult<CompraItem>> IncluirCompraItemAsync([FromForm] CompraItemModel model);
        Task<QueryResult<CompraItem>> AtualizarCompraItemAsync(int compraItemId, [FromBody] CompraItemModel model);
        Task<QueryResult<CompraItem>> DeletarCompraItemAsync(int compraItemId);
    }
}
