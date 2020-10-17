using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OCAirLines.Pagamento.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OCAirLines.Pagamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly ILogger<PagamentoController> _logger;
        private readonly IPagamentoService _pagamentoService;

        public PagamentoController(ILogger<PagamentoController> logger,
            IPagamentoService pagamentoService)
        {
            _logger = logger;
            _pagamentoService = pagamentoService;
        }

        // GET: api/<PagamentoController>
        [HttpGet("Status/{usuarioId}/{compraId}")]
        public async Task<IActionResult> Get([FromHeader] string token, int usuarioId, int compraId)
        {
            try
            {
                var result = await _pagamentoService.StatusPagamentoAsync(token, usuarioId, compraId);
                if (result.Succeeded)
                    return Ok(result.Result);
                else
                    return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: {ex.Message}");
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        //// GET api/<PagamentoController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<PagamentoController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PagamentoController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PagamentoController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
