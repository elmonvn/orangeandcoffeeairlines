using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OCAirLines.WebAPI.Interfaces;
using OCAirLines.WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OCAirLines.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "webapi")]
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
        [HttpGet("BuscaPorUsuario/{usuarioId}")]
        public async Task<IActionResult> GetByUserId(int usuarioId)
        {
            try
            {
                var result = await _cartaoService.TodosPorUsuarioAsync(usuarioId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: {ex.Message}");
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{cartaoId}")]
        public async Task<IActionResult> Get(int cartaoId)
        {
            try
            {
                var result = await _cartaoService.BuscaPorId(cartaoId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: {ex.Message}");
                return BadRequest($"Erro: {ex.Message}");
            }
        }


        // GET: api/<CartaoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CartaoModel model)
        {
            try
            {
                var result = await _cartaoService.IncluirCartaoAsync(model);
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

        // PUT api/<CartaoController>/5
        [HttpPut("{cartaoId}")]
        public async Task<IActionResult> Put(int cartaoId, [FromBody] CartaoModel model)
        {
            try
            {
                var result = await _cartaoService.AtualizarCartaoAsync(cartaoId, model);
                if (result.Succeeded)
                    return Ok(result.Result);
                else
                    return NotFound(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: {ex.Message}");
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{cartaoId}")]
        public async Task<IActionResult> Delete(int cartaoId)
        {
            try
            {
                var result = await _cartaoService.DeletarCartaoAsync(cartaoId);
                if (result.Succeeded)
                    return Ok(new { message = result.Message });
                else
                    return NotFound(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: {ex.Message}");
                return BadRequest($"Erro: {ex.Message}");
            }
        }

    }
}


