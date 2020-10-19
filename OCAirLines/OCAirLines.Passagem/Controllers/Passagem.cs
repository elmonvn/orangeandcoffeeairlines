using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using OCAirLines.Passagem.Services.Interfaces;
using OCAirLines.Passagem.TravelApi.RakutenRapidApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.Passagem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Passagem : ControllerBase
    {
        private IPassagemServices passagemServices;
        public Passagem(IPassagemServices _passagemServices)
        {
            passagemServices = _passagemServices;
        }
        /// <summary>
        /// Nome do lugar desejado
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet("buscar/local/{filtro}")]
        public async Task<ActionResult> Buscar(string filtrp)
        {
            try
            {
                var result = passagemServices.BuscaPorLocal(filtrp);
                if (!result.Result.Succeeded)
                    return BadRequest(new { status = false, message = "Não foi possivel completar a busca." });
                //var result  = await Skyscanner.BuscarLocalAsync(filtrp);
                return Ok(new { status = true, content = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = false, message = "Falha durante a busca.", errorMessage = ex.Message, error = ex.StackTrace });
            }

        }
        /// <summary>
        /// localIda e dataIda são obrigatorios.
        /// Osformatos de data devem ser no formatos: YYYY-MM-DD
        /// </summary>
        /// <param name="localDestino"></param>
        /// <param name="dataVolta"></param>
        /// <param name="localIda"></param>
        /// <param name="dataIda"></param>
        /// <returns></returns>
        [HttpGet("buscar/voos/{localIda}/{localVolta}/{dataIda}/{dataVolta}")]
        public async Task<ActionResult> BuscarVoos(string localIda, string localVolta, string dataIda, string dataVolta )
        {
            try
            {
                if (String.IsNullOrEmpty(localVolta) || String.IsNullOrEmpty(dataVolta) || String.IsNullOrEmpty(localIda) || String.IsNullOrEmpty(dataIda))
                    return BadRequest(new { status = false, message = "Todos os campos devem ser preenchido para a busca!" });

                var retorno = await passagemServices.BuscaPorVoos(localIda, localVolta, dataIda, dataVolta);
                if (!retorno.Succeeded)
                    return BadRequest(new { status = false, message = "Não foi possivel completar a busca." });
                //var result  = await Skyscanner.BuscarLocalAsync(filtrp);
                return Ok(new { status = true, content = retorno });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = false, message = "Falha durante a busca.", errorMessage = ex.Message, error = ex.StackTrace });
            }
        }
    }
}
