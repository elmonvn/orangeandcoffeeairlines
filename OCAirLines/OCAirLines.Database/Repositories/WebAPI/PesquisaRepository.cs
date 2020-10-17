using Microsoft.EntityFrameworkCore;
using OCAirLines.Database.Contexts;
using OCAirLines.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCAirLines.Database.Repositories.WebAPI
{
    public interface IPesquisaRepository : IRepository<Pesquisa>
    {
        IQueryable<Pesquisa> TodosPorUsuario(int UsuarioId);
        Task<Pesquisa> BuscaPorIdAsync(int pesquisaId);

    }

    public class PesquisaRepository : Repository<Pesquisa>
    {
        private readonly OCAirLinesDbContext _dataContext;

        public PesquisaRepository(OCAirLinesDbContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<Pesquisa> TodosPorUsuario(int usuarioId) => _dataContext.Pesquisas.AsQueryable();

        public async Task<Pesquisa> BuscaPorIdAsync(int pesquisaId) => await _dataContext.Pesquisas.FindAsync(pesquisaId);
    }
}
