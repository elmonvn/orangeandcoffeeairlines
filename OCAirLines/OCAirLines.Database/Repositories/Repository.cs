using OCAirLines.Database.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OCAirLines.Database.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task InserirAsync(T obj);
        void Atualizar(T obj);
        void Deletar(T obj);
        Task SalvarAsync();
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OCAirLinesDbContext _dataContext;

        public Repository(OCAirLinesDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task InserirAsync(T obj) => await _dataContext.AddAsync(obj);

        public void Atualizar(T obj) => _dataContext.Update(obj);

        public void Deletar(T obj) => _dataContext.Remove(obj);

        public async Task SalvarAsync() => await _dataContext.SaveChangesAsync();
    }
}
