using Microsoft.AspNetCore.Mvc;
using OCAirLines.Database.Helpers;
using OCAirLines.Database.Models;
using OCAirLines.Database.Repositories.Pagamento;
using OCAirLines.Database.Repositories.WebAPI;
using OCAirLines.Pagamento.Interfaces;
using OCAirLines.Pagamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace OCAirLines.Pagamento.Services
{
    public class CartaoService : ICartaoService
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public CartaoService(IPagamentoRepository pagamentoRepository,
            IUsuarioRepository usuarioRepository)
        {
            _pagamentoRepository = pagamentoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public string GeraToken()
        {
            return "13rb3-2bd7g-don38-2dh03-fhsid";
        }

        public async Task<QueryResult<Compra>> RegistrarPagamento([FromHeader]string token, [FromForm]CartaoModel model)
        {
            var cartao = await _pagamentoRepository.BuscaCartaoPorIdAsync(model.CartaoId);
            if (cartao != null)
            {
                var usuario = _usuarioRepository.BuscaPorIdAsync(model.UsuarioId);
                if (usuario != null)
                {
                    if (cartao.UsuarioId == usuario.Id)
                    {
                        if (model.QtdParcela > 0)
                        {
                            if (model.Itens.Count > 0)
                            {
                                var compra = new Compra
                                {
                                    UsuarioId = usuario.Id,
                                    CartaoId = cartao.Id,
                                    DtCompra = DateTime.Now,
                                    QtdParcela = model.QtdParcela,
                                    Status = true,
                                    Itens = model.Itens.Select(x =>
                                    new CompraItem
                                    { 
                                        EmpresaId = x.EmpresaId,
                                        Empresa = x.Empresa,
                                        OrigemId = x.OrigemId,
                                        Origem = x.Origem,
                                        DestinoId = x.DestinoId,
                                        Destino = x.Destino,
                                        Preco = x.Preco,
                                        DtSaida = x.DtSaida,
                                        DtChegada = x.DtChegada
                                    }).ToList()
                                };

                                await _pagamentoRepository.InserirAsync(cartao);
                                await _pagamentoRepository.SalvarAsync();

                                return new QueryResult<Compra>
                                {
                                    Succeeded = false,
                                    Result = compra
                                };
                            }
                            else
                            {
                                return new QueryResult<Compra>
                                {
                                    Succeeded = false,
                                    Message = "A quantidade de parcelas deve ser maior que Zero!"
                                };
                            }
                        }
                        else
                        {
                            return new QueryResult<Compra>
                            {
                                Succeeded = false,
                                Message = "A quantidade de parcelas deve ser maior que Zero!"
                            };
                        }
                    }
                    else
                    {
                        return new QueryResult<Compra>
                        {
                            Succeeded = false,
                            Message = "Esté cartão não pertence a esse usário!"
                        };
                    }
                }
                else
                {
                    return new QueryResult<Compra>
                    {
                        Succeeded = false,
                        Message = "Usuário não cadastrado!"
                    };
                }
                
            }
            else
            {
                return new QueryResult<Compra>
                {
                    Succeeded = false,
                    Message = "Cartão não cadastrado!"
                };
            }
        }
    }
}
