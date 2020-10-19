using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OCAirLines.Database.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OCAirLines.Authentication.Services
{
    public class TokenServices
    {
        public static string Get(AppAuthentication appAuth)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("SECRET_KEY"));// Secret Api Hash GENERATE BY https://www.grc.com/passwords.htm
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, appAuth.Name),
                        new Claim(ClaimTypes.Role, appAuth.AppRole)
                    }
                 ),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddHours(2)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
