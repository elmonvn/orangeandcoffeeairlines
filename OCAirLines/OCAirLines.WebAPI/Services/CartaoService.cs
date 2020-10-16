using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OCAirLines.Database.Contexts;
using OCAirLines.Database.Helpers;
using OCAirLines.Database.Models;
using OCAirLines.Database.Repositories.WebAPI;
using OCAirLines.WebAPI.Interfaces;
using OCAirLines.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.WebAPI.Services
{
    public class CartaoService : ICartaoService
    {
        private readonly ICartaoRepository _cartaoRepository;

        public CartaoService(ICartaoRepository CartaoRepository)
        {
            _cartaoRepository = CartaoRepository;
        }

        public async Task<IList<Cartao>> TodosPorUsuarioAsync(int usuarioId) => await _cartaoRepository.TodosPorUsuario(usuarioId).ToListAsync();

        public async Task<Cartao> BuscaPorId(int cartaoId) => await _cartaoRepository.BuscaPorIdAsync(cartaoId);

        public async Task<QueryResult<Cartao>> IncluirCartaoAsync([FromForm] CartaoModel model)
        {

            if (!string.IsNullOrEmpty(model.Bandeira))
            {
                if (!string.IsNullOrEmpty(model.Numero))
                {
                    if (!string.IsNullOrEmpty(model.CodSeguranca))
                    {
                        if (!string.IsNullOrEmpty(model.Vencimento))
                        {

                            var cartao = new Cartao
                            {
                                UsuarioId = model.UsuarioId,
                                Bandeira = model.Bandeira,
                                Numero = model.Numero,
                                CodSeguranca = model.CodSeguranca,
                                Vencimento = model.Vencimento,
                                Status = model.Status
                            };

                            await _cartaoRepository.InserirAsync(cartao);
                            await _cartaoRepository.SalvarAsync();

                            return new QueryResult<Cartao>
                            {
                                Succeeded = true,
                                Result = cartao
                            };

                        }
                        else
                        {
                            return new QueryResult<Cartao>
                            {
                                Succeeded = false,
                                Message = "O campo Vencimento é obrigatório!"
                            };
                        }
                    }
                    else
                    {
                        return new QueryResult<Cartao>
                        {
                            Succeeded = false,
                            Message = "O campo Código de Segurança da Identificação é obrigatório!"
                        };
                    }
                }
                else
                {
                    return new QueryResult<Cartao>
                    {
                        Succeeded = false,
                        Message = "O campo Tipo da Número é obrigatório!"
                    };
                }
            }
            else
            {
                return new QueryResult<Cartao>
                {
                    Succeeded = false,
                    Message = "O campo Bandeira é obrigatório!"
                };
            }
        }


        public async Task<QueryResult<Cartao>> AtualizarCartaoAsync(int cartaoId, [FromBody] CartaoModel model)
        {
            var cartao = await _cartaoRepository.BuscaPorIdAsync(cartaoId);
            if (cartao != null)
            {
                if (!string.IsNullOrEmpty(model.Bandeira))
                {
                    if (!string.IsNullOrEmpty(model.Numero))
                    {
                        if (!string.IsNullOrEmpty(model.CodSeguranca))
                        {
                            if (!string.IsNullOrEmpty(model.Vencimento))
                            {

                                cartao.UsuarioId = model.UsuarioId;
                                cartao.Bandeira = model.Bandeira;
                                cartao.Numero = model.Numero;
                                cartao.CodSeguranca = model.CodSeguranca;
                                cartao.Vencimento = model.Vencimento;
                                cartao.Status = model.Status;

                                await _cartaoRepository.InserirAsync(cartao);
                                await _cartaoRepository.SalvarAsync();

                                return new QueryResult<Cartao>
                                {
                                    Succeeded = true,
                                    Result = cartao
                                };

                            }
                            else
                            {
                                return new QueryResult<Cartao>
                                {
                                    Succeeded = false,
                                    Message = "O campo Vencimento é obrigatório!"
                                };
                            }
                        }
                        else
                        {
                            return new QueryResult<Cartao>
                            {
                                Succeeded = false,
                                Message = "O campo Código de Segurança da Identificação é obrigatório!"
                            };
                        }
                    }
                    else
                    {
                        return new QueryResult<Cartao>
                        {
                            Succeeded = false,
                            Message = "O campo Tipo da Número é obrigatório!"
                        };
                    }
                }
                else
                {
                    return new QueryResult<Cartao>
                    {
                        Succeeded = false,
                        Message = "O campo Bandeira é obrigatório!"
                    };
                }
            }
            else
            {
                return new QueryResult<Cartao>
                {
                    Succeeded = false,
                    Message = "Cartão não encontrado!"
                };
            }
        }

        public async Task<QueryResult<Cartao>> DeletarCartaoAsync(int usuarioId)
        {
            var cartao = await _cartaoRepository.BuscaPorIdAsync(usuarioId);
            if (cartao != null)
            {
                cartao.Status = false;

                _cartaoRepository.Atualizar(cartao);
                await _cartaoRepository.SalvarAsync();

                return new QueryResult<Cartao>
                {
                    Succeeded = true,
                    Message = "Cartão deletado com sucesso."
                };
            }
            else
            {
                return new QueryResult<Cartao>
                {
                    Succeeded = false,
                    Message = "Cartão não encontrado!"
                };
            }
        }
    }
}
