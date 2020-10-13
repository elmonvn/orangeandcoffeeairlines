using Microsoft.IdentityModel.Tokens;
using OCAirLines.Authentication.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OCAirLines.Authentication.Services
{
    public class TokenServices
    {
        public static string Get(AppAuth appAuth)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretApi.key);// Secret Api Hash GENERATE BY https://www.grc.com/passwords.htm
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
