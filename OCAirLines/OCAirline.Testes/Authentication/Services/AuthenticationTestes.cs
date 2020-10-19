using OCAirLines.Authentication.Services.Intefaces;
using OCAirLines.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OCAirline.Testes.Authentication.Services
{
    public class AuthenticationTestes
    {
        public static IAppAuthServices appAuthServices;
        public static IEnumerable<object[]> mock;
        public AuthenticationTestes()
        {
            appAuthServices = InjectionContainer.GetInstance<IAppAuthServices>();
            mock = MockAuthentication.NovoApp();
        }



        [Theory(DisplayName = "Teste para registrar um novo app")]
        [MemberData(nameof(mock))]
        public static void RegistrarNovoApp(AppAuthentication appAuth)
        {
            var result = appAuthServices.RegistrarNovoApp(appAuth);
            Assert.Equal(true,result.Result.Succeeded);
        }
    }
}
