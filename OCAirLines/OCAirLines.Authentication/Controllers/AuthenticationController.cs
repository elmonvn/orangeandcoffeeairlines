using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OCAirLines.Authentication.Model;
using OCAirLines.Authentication.Repositories;
using OCAirLines.Authentication.Services;

namespace OCAirLines.Authentication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        [HttpGet]
        [Route("token")]
        public ActionResult GenerateToken([FromBody] AppAuth appAuth)
        {
            try
            {
                var _AppAuth = AppAuthServices.AppInfoAuth(appAuth.Name, appAuth.Password, appAuth.AppId);
                if (_AppAuth == null)
                    return NotFound(new { status = true, message = "Não foi possivel autenticar-se, verifique suas credenciais." });
                var token = TokenServices.Get(_AppAuth);
                return Ok(new { status = true, message = "Autenticado com Sucesso!", content = new { userApp=_AppAuth.Name, token = "Bearer "+token }});
            }
            catch (Exception ex)
            {
                return NotFound(new { status = false, message = "Falha durante a autenticação.", Error = ex.Message,ErrorDetail = ex.StackTrace });
            }
        }
    }
}
