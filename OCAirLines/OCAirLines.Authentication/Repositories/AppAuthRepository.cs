using OCAirLines.Authentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.Authentication.Repositories
{
    public class AppAuthRepository
    {
        internal static AppAuth SelectById(int appId)
        {
            var result =  new AppAuth { AppId = 1, Email = "Wladigley@gmail.com", AppRole = "OCUSUARIO",Name="Teste",Password="1234" };
            return result;
        }
    }
}
