﻿using Microsoft.EntityFrameworkCore;
using OCAirLines.Database.Contexts;
using OCAirLines.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OCAirLines.Database.Repositories.Pagamento
{
    public interface IPagamentoRepository : IRepository<Cartao>
    {
        Task<Cartao> BuscaCartaoPorIdAsync(int cartaoId);
    }

    public class PagamentoRopository : Repository<Cartao>, IPagamentoRepository
    {
        private readonly OCAirLinesDbContext _dataContext;

        public PagamentoRopository(OCAirLinesDbContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Cartao> BuscaCartaoPorIdAsync(int cartaoId) => await _dataContext.Cartoes
            .Include(x => x.Usuario)
            .SingleOrDefaultAsync(x => x.Id == cartaoId);
    }
}
