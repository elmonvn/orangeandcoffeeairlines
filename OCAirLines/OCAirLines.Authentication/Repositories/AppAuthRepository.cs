using Microsoft.EntityFrameworkCore;
using OCAirLines.Authentication.Repositories.Interfaces;
using OCAirLines.Database.Contexts;
using OCAirLines.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace OCAirLines.Authentication.Repositories
{
    public class AppAuthRepository : IAppAuthRepository
    {
        private readonly OCAirLinesDbContext dataContext;
        public AppAuthRepository(OCAirLinesDbContext _dataContext)
        {
            dataContext = _dataContext;
        }
        public  async Task<AppAuthentication> SelecionarPorHashIdName(string hashId, string appName)
        {
            //var result =  new AppAuth { AppId = 1, Email = "Wladigley@gmail.com", AppRole = "OCUSUARIO",Name="Teste",Password="1234" };
            var result = await dataContext.AppAuthentications.Where(x=>x.HashId == hashId && x.Name == appName).FirstOrDefaultAsync();
            return result;
        }

        public async Task RegistrarNovoApp(AppAuthentication appAuth)
        {
            await dataContext.AppAuthentications.AddAsync(appAuth);
            dataContext.SaveChanges();
        }

        public async Task RevogarApp(string hashId, string appName)
        {
            AppAuthentication appAuth = new AppAuthentication() { HashId = hashId, Name = appName };
            dataContext.AppAuthentications.Attach(appAuth);
            dataContext.AppAuthentications.Remove(appAuth);
            await dataContext.SaveChangesAsync();

        }
    }
}
