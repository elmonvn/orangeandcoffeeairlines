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
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        IQueryable<Usuario> Todos();
        Task<Usuario> BuscaPorIdAsync(int usuarioId);
        Task<Usuario> ValidaEmailAsync(string email);
    }

    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly OCAirLinesDbContext _dataContext;

        public UsuarioRepository(OCAirLinesDbContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<Usuario> Todos() => _dataContext.Usuarios.AsQueryable();

        public async  Task<Usuario> BuscaPorIdAsync(int usuarioId) => await _dataContext.Usuarios.FindAsync(usuarioId);

        public async Task<Usuario> ValidaEmailAsync(string email) => await _dataContext.Usuarios.SingleOrDefaultAsync(x => x.Email.ToUpper() == email.ToUpper());
    }
}
