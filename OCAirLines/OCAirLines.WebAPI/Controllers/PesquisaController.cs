using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OCAirLines.WebAPI.Interfaces;
using OCAirLines.WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OCAirLines.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisaController : ControllerBase
    {
        private readonly ILogger<CartaoController> _logger;
        private readonly IPesquisaService _pesquisaService;

        public PesquisaController(ILogger<CartaoController> logger,
        IPesquisaService pesquisaService)
        {
            _logger = logger;
            _pesquisaService = pesquisaService;
        }

        // GET: api/<CartaoController>
        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> GetByUserId(int usuarioId)
        {
            try
            {
                var result = await _pesquisaService.TodosPorUsuarioAsync(usuarioId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: {ex.Message}");
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{cartaoId}")]
        public async Task<IActionResult> GetById(int cartaoId)
        {
            try
            {
                var result = await _pesquisaService.BuscaPorId(cartaoId);
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
        public async Task<IActionResult> Post([FromBody] PesquisaModel model)
        {
            try
            {
                var result = await _pesquisaService.IncluirPesquisaAsync(model);
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
        [HttpPut("{pesquisaId}")]
        public async Task<IActionResult> Put(int pesquisaId, [FromBody] PesquisaModel model)
        {
            try
            {
                var result = await _pesquisaService.AtualizarPesquisaAsync(pesquisaId, model);
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
        [HttpDelete("{pesquisaId}")]
        public async Task<IActionResult> Delete(int pesquisaId)
        {
            try
            {
                var result = await _pesquisaService.DeletarPesquisaAsync(pesquisaId);
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


