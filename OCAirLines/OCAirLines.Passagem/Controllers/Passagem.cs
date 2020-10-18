using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OCAirLines.Passagem.TravelApi.RakutenRapidApi;

namespace OCAirLines.Passagem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Passagem : ControllerBase
    {
        public enum TesteEnum
        {
            opcao01,
            teste,
            opcao03
        };
        static string[] options = { "opcao01", "opcao02", "opcao03" };
        /// <summary>
        /// Opção 01 - text
        /// Opção 02 - text
        /// Opção 03 - text
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> BuscarPor(string filtrp)
        {
            var result  = await Skyscanner.BuscarLocalAsync(filtrp);
            return Ok(result);

            //Pegar keys fo enviromment
            //Pesquisa por Data
            //Pesquisar por Local
            //
        }


    }

}
