using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.Authentication
{
    public class SecretApi
    {
        public static string HashIdClient(string AppName) => Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(System.Text.Encoding.UTF8.GetBytes(AppName) + DateTime.Now.ToString())).Substring(0,10).ToLower();
    }
}
