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

        public static bool RegisterAppAuth()
        {
            //Registrar App mo banco
            return true;
        }
        public static bool RevokeAppAuth()
        {
            //Revogar App mo banco
            return true;
        }
    }
}
