using OCAirLines.Authentication.Model;
using OCAirLines.Authentication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.Authentication.Services
{
    public class AppAuthServices
    {
        public static AppAuth AppInfoAuth(string appName, string passWord, int appId)
        {
            //recupera informações do App do banco
            var result = AppAuthRepository.SelectById(appId);
            if (passWord != result.Password || appName != result.Name)
                return null;
            return result;
        }

        public static int RegisterAppAuth(AppAuth appAuth)
        {
            //Registrar App mo banco
            var result = AppAuthRepository.RegisterNewApp(appAuth);

            return result;
        }
        public static bool RevokeAppAuth(int appId)
        {
            //Revogar App mo banco
            //Registrar App mo banco
            var result = AppAuthRepository.RevokeApp(appId);

            return result;
        }
    }
}
