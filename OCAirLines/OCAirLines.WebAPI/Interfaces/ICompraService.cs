using System;
﻿using Microsoft.AspNetCore.Mvc;
using OCAirLines.Database.Helpers;
using OCAirLines.Database.Models;
using OCAirLines.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.WebAPI.Interfaces
{
    public interface ICompraService
    {
        Task<IList<Compra>> TodosAsync();
        Task<Compra> BuscaPorId(int compraId);
        Task<QueryResult<Compra>> IncluirCompraAsync([FromForm] CompraModel model);
        Task<QueryResult<Compra>> AtualizarCompraAsync(int compraId, [FromBody] CompraModel model);
        Task<QueryResult<Compra>> DeletarCompraAsync(int compraId);
    }
}
