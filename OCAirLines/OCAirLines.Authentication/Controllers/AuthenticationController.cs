using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OCAirLines.Authentication.Repositories;
using OCAirLines.Authentication.Services;
using OCAirLines.Authentication.Services.Intefaces;
using OCAirLines.Authentication.ViewModel;
using OCAirLines.Database.Models;

namespace OCAirLines.Authentication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAppAuthServices appAuthServices;
        public AuthenticationController(IAppAuthServices _appAuthServices)
        {
            appAuthServices = _appAuthServices;
        }

        /// <summary>
        /// Gera um Novo token de acesso com base nas informacoes fornecidas
        /// </summary>
        /// <param name="tokenModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Token")]
        public async Task<ActionResult> GenerateToken([FromBody] TokenAppViewModel tokenModel)
        {
            try
            {
                var appAuth = new AppAuthentication();
                appAuth.Name = tokenModel.Name;
                appAuth.Password = tokenModel.Password;
                appAuth.HashId = tokenModel.HashId;

                var _AppAuth = await appAuthServices.AppInfoAuth(appAuth.Name, appAuth.Password, appAuth.HashId);
                if (_AppAuth.Succeeded == false)
                    return NotFound(new { status = false, message = "Não foi possivel autenticar-se, verifique suas credenciais." });
                var token = TokenServices.Get(_AppAuth.Result);
                return Ok(new { status = true, message = "Autenticado com Sucesso!", content = new { AppName = _AppAuth.Result.Name, token = "Bearer " + token } });
            }
            catch (Exception ex)
            {
                return NotFound(new { status = false, message = "Falha durante a autenticação.", Error = ex.Message, ErrorDetail = ex.StackTrace });
            }
        }

        /// <summary>
        /// Consultar informações de cadastro
        /// </summary>
        /// <param name="researchModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Consultar")]
        public async Task<ActionResult> ConsultInfo([FromBody] ResearchViewModel researchModel)
        {
            try
            {
                var appAuth = new AppAuthentication();
                appAuth.Name = researchModel.Name;
                appAuth.Password = researchModel.Password;
                appAuth.HashId = researchModel.HashId;

                var app = await appAuthServices.AppInfoAuth(appAuth.Name, appAuth.Password, appAuth.HashId);

                if (app.Result == null)
                    return NotFound(new { status = true, message = "Não foi possivel encontrar informações, verifique suas credenciais." });

                return Ok(new { status = true, content = app });
            }
            catch (Exception ex)
            {
                return NotFound(new { status = false, message = "Falha durante a autenticação.", Error = ex.Message, ErrorDetail = ex.StackTrace });
            }
        }

        /// <summary>
        /// Registra um Novo App para consumir as Apis
        /// </summary>
        /// <param name="registerModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Registrar")]
        public async Task<ActionResult> RegisterApp([FromBody] RegisterAppViewModel registerModel)
        {
            try
            {
                var appAuth = new AppAuthentication();
                appAuth.Name = registerModel.Name;
                appAuth.Password = registerModel.Password;
                appAuth.Email = registerModel.Email;
                appAuth.AppRole = registerModel.AppRole;

                if (String.IsNullOrEmpty(appAuth.AppRole) || String.IsNullOrEmpty(appAuth.Email) || String.IsNullOrEmpty(appAuth.Password) || String.IsNullOrEmpty(appAuth.Name))
                    return NotFound(new { status = false, message = "Não foi possivel registrar, verifique suas informações." });

                var register = await appAuthServices.RegistrarNovoApp(appAuth);

                if (register.Result == null)
                    return NotFound(new { status = false, message = "Não foi possivel registrar, verifique suas informações." });

                return Ok(new { status = true, message = "Registrado com Sucesso!", content = new { HashId = register.Result.HashId, AppName = appAuth.Name } });
            }
            catch (Exception ex)
            {
                return NotFound(new { status = false, message = "Falha durante o Registro.", Error = ex.Message, ErrorDetail = ex.StackTrace });
            }
        }

        /// <summary>
        /// Revogar um App ja cadastrado
        /// </summary>
        /// <param name="revokeModel"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Revogar")]
        public async Task<ActionResult> RevokeApp([FromBody] RevokeViewModel revokeModel)
        {
            try
            {
                var appAuth = new AppAuthentication();
                appAuth.Name = revokeModel.Name;
                appAuth.Password = revokeModel.Password;
                appAuth.Email = revokeModel.Email;

                if (String.IsNullOrEmpty(appAuth.Email) || String.IsNullOrEmpty(appAuth.Password) || String.IsNullOrEmpty(appAuth.Name))
                    return NotFound(new { status = false, message = "Não foi possivel revogar, verifique suas informações." });

                var registerId = await appAuthServices.RevogarApp(appAuth);

                if (!registerId.Succeeded)
                    return NotFound(new { status = false, message = "Não foi possivel revogar, verifique suas informações." });

                return Ok(new { status = true, message = "Revogado com sucesso!", content = registerId.Result });
            }
            catch (Exception ex)
            {
                return NotFound(new { status = false, message = "Falha durante a Revogação.", Error = ex.Message, ErrorDetail = ex.StackTrace });
            }
        }
    }
}
