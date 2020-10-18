using Microsoft.AspNetCore.Mvc;
using OCAirLines.Database.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.Pagamento.Interfaces
{
    public interface IPagamentoService
    {
        Task<QueryResult<bool>> StatusPagamentoAsync(int usuarioId, int compraId);
    }
}
