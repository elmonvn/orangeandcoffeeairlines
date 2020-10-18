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
    public class CompraItemController : ControllerBase
    {
        private readonly ILogger<CompraItemController> _logger;
        private readonly ICompraItemService _compraItemService;

        public CompraItemController(ILogger<CompraItemController> logger,
        ICompraItemService compraItemService)
        {
            _logger = logger;
            _compraItemService = compraItemService;
        }

        // GET: api/<CartaoController>
        [HttpGet("{compraId}")]
        public async Task<IActionResult> GetByCompraId(int compraId)
        {
            try
            {
                var result = await _compraItemService.TodosPorCompraAsync(compraId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: {ex.Message}");
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{compraItemId}")]
        public async Task<IActionResult> GetById(int compraItemId)
        {
            try
            {
                var result = await _compraItemService.BuscaPorId(compraItemId);
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
        public async Task<IActionResult> Post([FromBody] CompraItemModel model)
        {
            try
            {
                var result = await _compraItemService.IncluirCompraItemAsync(model);
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
        [HttpPut("{compraItemId}")]
        public async Task<IActionResult> Put(int compraItemId, [FromBody] CompraItemModel model)
        {
            try
            {
                var result = await _compraItemService.AtualizarCompraItemAsync(compraItemId, model);
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
        [HttpDelete("{compraItemId}")]
        public async Task<IActionResult> Delete(int compraItemId)
        {
            try
            {
                var result = await _compraItemService.DeletarCompraItemAsync(compraItemId);
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


