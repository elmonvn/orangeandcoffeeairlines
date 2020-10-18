using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        // POST api/<CartaoController>
        [HttpPost]
        [Route("Pagar")]
        [Authorize(Roles = "pagamentoapi")]
        public async Task<IActionResult> Post([FromBody] CartaoModel model)
        {
            try
            {
                var result = await _cartaoService.RegistrarPagamento(model);
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
    }
}
