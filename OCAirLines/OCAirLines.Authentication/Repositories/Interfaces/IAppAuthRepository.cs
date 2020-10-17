using OCAirLines.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.Authentication.Repositories.Interfaces
{
    public interface IAppAuthRepository
    {
        Task<AppAuthentication> SelecionarPorHashIdName(string hashId, string appName);
        Task RegistrarNovoApp(AppAuthentication appAuth);
        Task RevogarApp(string hashId, string appName);
    }
}
