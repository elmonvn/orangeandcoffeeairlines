using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OCAirLines.Passagem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Passagem : ControllerBase
    {
        /// <summary>
        /// Passagens
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public async Task<ActionResult> BuscarPor(IEnumerable<string> filtro)
        {
            return NotFound();
        }
    }
}
