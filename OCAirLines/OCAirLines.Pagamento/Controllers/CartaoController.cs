using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OCAirLines.Pagamento.Interfaces;
using OCAirLines.Pagamento.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OCAirLines.Pagamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartaoController : ControllerBase
    {
        private readonly ILogger<CartaoController> _logger;
        private readonly ICartaoService _cartaoService;

        public CartaoController(ILogger<CartaoController> logger,
            ICartaoService cartaoService)
        {
            _logger = logger;
            _cartaoService = cartaoService;
        }

        // GET: api/<CartaoController>
        [HttpGet, ActionName("GeraToken")]
        [Route("GetToken")]
        public string Get() => _cartaoService.GeraToken();

        //// GET api/<CartaoController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CartaoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromHeader] string token, [FromBody] CartaoModel model)
        {
            try
            {
                var result = await _cartaoService.RegistrarPagamento(token, model);
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

        //// PUT api/<CartaoController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CartaoController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
