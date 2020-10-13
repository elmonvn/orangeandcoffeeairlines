using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.Authentication
{
    public class SecretApi
    {
        public static string key =>  Environment.GetEnvironmentVariable("SECRET_KEY");
    }
}
