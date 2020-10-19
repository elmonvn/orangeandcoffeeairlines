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
    public class CompraController : ControllerBase
    {
        private readonly ILogger<CompraController> _logger;
        private readonly ICompraService _compraService;

        public CompraController(ILogger<CompraController> logger,
            ICompraService compraService)
        {
            _logger = logger;
            _compraService = compraService;
        }

        // GET: api/<CompraController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _compraService.TodosAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: {ex.Message}");
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // GET api/<CompraController>/5
        [HttpGet("{compraId}")]
        public async Task<IActionResult> Get(int compraId)
        {
            try
            {
                var result = await _compraService.BuscaPorId(compraId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: {ex.Message}");
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // POST api/<CompraController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CompraModel model)
        {
            try
            {
                var result = await _compraService.IncluirCompraAsync(model);
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

        // PUT api/<CompraController>/5
        [HttpPut("{compraId}")]
        public async Task<IActionResult> Put(int compraId, [FromBody] CompraModel model)
        {
            try
            {
                var result = await _compraService.AtualizarCompraAsync(compraId, model);
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

        // DELETE api/<CompraController>/5
        [HttpDelete("{compraId}")]
        public async Task<IActionResult> Delete(int compraId)
        {
            try
            {
                var result = await _compraService.DeletarCompraAsync(compraId);
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
