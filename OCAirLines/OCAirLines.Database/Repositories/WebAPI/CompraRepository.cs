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
    public interface ICompraRepository : IRepository<Compra>
    {
        IQueryable<Compra> Todos();
        Task<Compra> BuscaPorIdAsync(int compraId);
    }

    public class CompraRepository : Repository<Compra>, ICompraRepository
    {
        private readonly OCAirLinesDbContext _dataContext;

        public CompraRepository(OCAirLinesDbContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<Compra> Todos() => _dataContext.Compras.AsQueryable();

        public async  Task<Compra> BuscaPorIdAsync(int compraId) => await _dataContext.Compras.FindAsync(compraId);
    }
}
