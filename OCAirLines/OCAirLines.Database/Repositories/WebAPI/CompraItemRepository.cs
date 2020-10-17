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
    public interface ICompraItemRepository : IRepository<CompraItem>
    {
        IQueryable<CompraItem> TodosPorCompra(int compraId);
        Task<CompraItem> BuscaPorIdAsync(int compraItemId);

    }

    public class CompraItemRepository : Repository<CompraItem>, ICompraItemRepository
    {
        private readonly OCAirLinesDbContext _dataContext;

        public CompraItemRepository(OCAirLinesDbContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<CompraItem> TodosPorCompra(int compraId) => _dataContext.CompraItem.AsQueryable();

        public async Task<CompraItem> BuscaPorIdAsync(int compraItemId) => await _dataContext.CompraItem.FindAsync(compraItemId);



    }
}
