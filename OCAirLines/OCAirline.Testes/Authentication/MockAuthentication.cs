using OCAirLines.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCAirline.Testes.Authentication
{
    public class MockAuthentication
    {
        public static IEnumerable<object[]> NovoApp()
        {
            yield return new[] { new AppAuthentication { Id = 1, Name = "", Email = "", HashId = "", AppRole = "", Password = "" } };
            yield return new[] { new AppAuthentication { Id = 1, Name = "", Email = "", HashId = "", AppRole = "", Password = "" } };
            yield return new[] { new AppAuthentication { Id = 1, Name = "", Email = "", HashId = "", AppRole = "", Password = "" } };
        }
    }
}
