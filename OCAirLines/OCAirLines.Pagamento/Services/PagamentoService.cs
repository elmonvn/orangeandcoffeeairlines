using Microsoft.AspNetCore.Mvc;
using OCAirLines.Database.Helpers;
using OCAirLines.Database.Repositories.Pagamento;
using OCAirLines.Database.Repositories.WebAPI;
using OCAirLines.Pagamento.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.Pagamento.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public PagamentoService(IPagamentoRepository pagamentoRepository,
            IUsuarioRepository usuarioRepository)
        {
            _pagamentoRepository = pagamentoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<QueryResult<bool>> StatusPagamentoAsync([FromHeader]string token, int usuarioId, int compraId)
        {
            var usuario = await _usuarioRepository.BuscaPorIdAsync(usuarioId);
            if (usuario != null)
            {
                var compra = await _pagamentoRepository.BuscaCompraPorIdAsycn(compraId);
                if (compra != null)
                {
                    if (compra.UsuarioId == usuario.Id)
                    {
                        return new QueryResult<bool>
                        { 
                            Succeeded = true,
                            Result = compra.Status
                        };
                    }
                    else
                    {
                        return new QueryResult<bool>
                        {
                            Succeeded = false,
                            Message = "Esse pagamento não pertence a esse usário!"
                        };
                    }
                }
                else
                {
                    return new QueryResult<bool>
                    {
                        Succeeded = false,
                        Message = "Pagamento não registrado!"
                    };
                }
            }
            else
            {
                return new QueryResult<bool>
                {
                    Succeeded = false,
                    Message = "Usuário não cadastrado!"
                };
            }
        }
    }
}
