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
        /// <summary>
        /// Gera um Novo token de acesso com base nas informacoes fornecidas
        /// </summary>
        /// <param name="appAuth"></param>
        /// <returns></returns>
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
                return Ok(new { status = true, message = "Autenticado com Sucesso!", content = new { appId = _AppAuth.AppId, userApp =_AppAuth.Name, token = "Bearer "+token }});
            }
            catch (Exception ex)
            {
                return NotFound(new { status = false, message = "Falha durante a autenticação.", Error = ex.Message,ErrorDetail = ex.StackTrace });
            }
        }

        /// <summary>
        /// Registra um Novo App para consumir as Apis
        /// </summary>
        /// <param name="appAuth"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("registerapp")]
        public ActionResult RegisterApp([FromBody] AppAuth appAuth)
        {
            //Registrar App mo banco
            try
            {
                if(String.IsNullOrEmpty(appAuth.AppRole) || String.IsNullOrEmpty(appAuth.Email)|| String.IsNullOrEmpty(appAuth.Password)|| String.IsNullOrEmpty(appAuth.Name))
                    return NotFound(new { status = false, message = "Não foi possivel registrar, verifique suas iformações." });

                var registerId = AppAuthServices.RegisterAppAuth(appAuth);
                
                if (registerId == 0)
                    return NotFound(new { status = false, message = "Não foi possivel registrar, verifique suas iformações." });
                
                return Ok(new { status = true, message = "Registrado com Sucesso!", content = new { appId = registerId, userApp = appAuth.Name} });
            }
            catch (Exception ex)
            {
                return NotFound(new { status = false, message = "Falha durante o Registro.", Error = ex.Message, ErrorDetail = ex.StackTrace });
            }
        }
        /// <summary>
        /// Revogar um App ja cadastrado
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("revokeapp")]
        public ActionResult<bool> RevokeApp(int appId)
        {
            //Revogar App mo banco
            return true;
        }

    }
}
