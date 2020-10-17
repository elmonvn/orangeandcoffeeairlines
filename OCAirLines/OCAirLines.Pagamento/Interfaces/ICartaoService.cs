﻿using Microsoft.AspNetCore.Mvc;
using OCAirLines.Database.Helpers;
using OCAirLines.Database.Models;
using OCAirLines.Pagamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.Pagamento.Interfaces
{
    public interface ICartaoService
    {
        string GeraToken();
        Task<QueryResult<Compra>> RegistrarPagamento([FromHeader] string token, [FromForm] CartaoModel model);
    }
}
