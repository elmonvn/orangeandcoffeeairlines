using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using OCAirLines.Database.Contexts;
using OCAirLines.Database.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OCAirLines.Database
{
    public class AuthenticationAPIDbSeeder
    {
        public static async Task Initialize(OCAirLinesDbContext context)
        {
            await context.Database.MigrateAsync();

            if (!context.AppAuthentications.Any())
                await CriarAPIAutenticacoes(context);
        }

        private static async Task CriarAPIAutenticacoes(OCAirLinesDbContext context)
        {
            var listAppAuth = new List<AppAuthentication>();

            listAppAuth.Add(new AppAuthentication
            {
                Name = "WebAPI",
                Password = "123456",
                Email = "webapi@email.com",
                AppRole = "webapi",
                HashId = HashIdClient("WebAPI")
            });

            listAppAuth.Add(new AppAuthentication
            {
                Name = "PagamentoAPI",
                Password = "123456",
                Email = "pagamentoapi@email.com",
                AppRole = "pagamentoapi",
                HashId = HashIdClient("PagamentoAPI")
            });

            listAppAuth.Add(new AppAuthentication
            {
                Name = "PassagemAPI",
                Password = "123456",
                Email = "passagemapi@email.com",
                AppRole = "passagemapi",
                HashId = HashIdClient("PassagemAPI")
            });

            await context.AddRangeAsync(listAppAuth);
            await context.SaveChangesAsync();
        }

        public static string HashIdClient(string AppName) => Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(System.Text.Encoding.UTF8.GetBytes(AppName) + DateTime.Now.ToString())).Substring(0, 10).ToLower();
    }
}
