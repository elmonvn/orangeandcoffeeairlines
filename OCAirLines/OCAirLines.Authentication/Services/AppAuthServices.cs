using OCAirLines.Authentication.Repositories;
using OCAirLines.Authentication.Repositories.Interfaces;
using OCAirLines.Authentication.Services.Intefaces;
using OCAirLines.Database.Helpers;
using OCAirLines.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.Authentication.Services
{
    public class AppAuthServices: IAppAuthServices
    {
        private readonly IAppAuthRepository appAuthRepository;
        public AppAuthServices(IAppAuthRepository _appAuthRepository)
        {
            appAuthRepository = _appAuthRepository;
        }

        public async Task<QueryResult<AppAuthentication>> AppInfoAuth(string appName, string passWord, string hashId)
        {
            //recupera informações do App do banco
            var result = await appAuthRepository.SelecionarPorHashIdName(hashId, appName);
            
            if (passWord != result.Password || appName != result.Name && hashId != result.HashId)
                return new QueryResult<AppAuthentication> { Succeeded = false };
            result.Password = "****";
            return new QueryResult<AppAuthentication> { Succeeded = true, Result = result }; ;
        }

        public async Task<QueryResult<AppAuthentication>> RegistrarNovoApp(AppAuthentication appAuth)
        {
            //Registrar App mo banco
            if (appAuth.Password != appAuth.Password && appAuth.Name != appAuth.Name)
                return new QueryResult<AppAuthentication> { Succeeded = false, Message = "Name e Password são obrigatórios, Verifique." };

            appAuth.HashId = SecretApi.HashIdClient(appAuth.Name);
            await appAuthRepository.RegistrarNovoApp(appAuth);
            appAuth.Password = "****";
            return new QueryResult<AppAuthentication>{ Succeeded = true, Result = appAuth, Message = "Registrado com sucesso!" };
        }

        public async Task<QueryResult<string>> RevogarApp(AppAuthentication appAuth)
        {
            var result = await appAuthRepository.SelecionarPorHashIdName(appAuth.HashId, appAuth.Name);

            if (appAuth.Password != result.Password || appAuth.Name != result.Name)
                return new QueryResult<string> { Succeeded = false, Message = "Verifique suas credenciais." };
            //Revogar App mo banco
            await appAuthRepository.RevogarApp(appAuth.HashId, appAuth.Name);

            return new QueryResult<string>{Succeeded = true, Result = appAuth.Name, Message="Revogado com sucesso!" };
        }
    }
}
