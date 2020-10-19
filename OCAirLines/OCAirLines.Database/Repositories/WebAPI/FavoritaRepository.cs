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
    public interface IFavoritaRepository : IRepository<Favorita>
    {
        IQueryable<Favorita> TodosPorUsuario(int UsuarioId);
        Task<Favorita> BuscaPorIdAsync(int favoritaId);

    }

    public class FavoritaRepository : Repository<Favorita>, IFavoritaRepository
    {
        private readonly OCAirLinesDbContext _dataContext;

        public FavoritaRepository(OCAirLinesDbContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<Favorita> TodosPorUsuario(int usuarioId) => _dataContext.Favoritas.AsQueryable();

        public async Task<Favorita> BuscaPorIdAsync(int favoritaId) => await _dataContext.Favoritas.FindAsync(favoritaId);
    }
}
