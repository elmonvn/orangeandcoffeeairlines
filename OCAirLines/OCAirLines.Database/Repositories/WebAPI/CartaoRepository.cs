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
    public interface ICartaoRepository : IRepository<Cartao>
    {
        IQueryable<Cartao> TodosPorUsuario(int UsuarioId);
        Task<Cartao> BuscaPorIdAsync(int cartaoId);

    }

    public class CartaoRepository : Repository<Cartao>, ICartaoRepository
    {
        private readonly OCAirLinesDbContext _dataContext;

        public CartaoRepository(OCAirLinesDbContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<Cartao> TodosPorUsuario(int usuarioId) => _dataContext.Cartoes.AsQueryable();

        public async Task<Cartao> BuscaPorIdAsync(int cartaoId) => await _dataContext.Cartoes.FindAsync(cartaoId);
    }
}
