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
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(ILogger<UsuarioController> logger,
            IUsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _usuarioService.TodosAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: {ex.Message}");
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> Get(int usuarioId)
        {
            try
            {
                var result = await _usuarioService.BuscaPorId(usuarioId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: {ex.Message}");
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UsuarioModel model)
        {
            try
            {
                var result = await _usuarioService.IncluirUsuarioAsync(model);
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

        // PUT api/<UsuarioController>/5
        [HttpPut("{usuarioId}")]
        public async Task<IActionResult> Put(int usuarioId, [FromBody]UsuarioModel model)
        {
            try
            {
                var result = await _usuarioService.AtualizarUsuarioAsync(usuarioId, model);
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
        [HttpDelete("{usuarioId}")]
        public async Task<IActionResult> Delete(int usuarioId)
        {
            try
            {
                var result = await _usuarioService.DeletarUsuarioAsync(usuarioId);
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
