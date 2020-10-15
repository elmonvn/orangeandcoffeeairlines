using OCAirLines.Database.Helpers;
using OCAirLines.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.Authentication.Services.Intefaces
{
    public interface IAppAuthServices
    {
            Task<QueryResult<AppAuthentication>> AppInfoAuth(string appName, string passWord, string HashId);
            Task<QueryResult<AppAuthentication>> RegistrarNovoApp(AppAuthentication appAuth);
            Task<QueryResult<string>> RevogarApp(AppAuthentication appAuth);
    }
}
