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
    public class CompraItemService : ICompraItemService
    {
        private readonly ICompraItemRepository _compraItemRepository;

        public CompraItemService(ICompraItemRepository CompraItemRepository)
        {
            _compraItemRepository = CompraItemRepository;
        }

        public async Task<IList<CompraItem>> TodosPorUsuarioAsync(int compraId) => await _compraItemRepository.TodosPorCompra(compraId).ToListAsync();

        public async Task<CompraItem> BuscaPorId(int compraItemId) => await _compraItemRepository.BuscaPorIdAsync(compraItemId);

        public async Task<QueryResult<CompraItem>> IncluirCompraItemAsync([FromForm] CompraItemModel model)
        {

            if (!string.IsNullOrEmpty(model.Empresa))
            {
                if (!string.IsNullOrEmpty(model.Origem))
                {
                    if (!string.IsNullOrEmpty(model.Destino))
                    {

                        var compraItem = new CompraItem
                        {
                            CompraId = model.CompraId,
                            EmpresaId = model.EmpresaId,
                            Empresa = model.Empresa,
                            OrigemId = model.OrigemId,
                            Origem = model.Origem,
                            DestinoId = model.DestinoId,
                            Destino = model.Destino,
                            Preco = model.Preco,
                            DtSaida = model.DtSaida,
                            DtChegada = model.DtChegada
                        };

                        await _compraItemRepository.InserirAsync(compraItem);
                        await _compraItemRepository.SalvarAsync();

                        return new QueryResult<CompraItem>
                        {
                            Succeeded = true,
                            Result = compraItem
                        };

                        
                    }
                    else
                    {
                        return new QueryResult<CompraItem>
                        {
                            Succeeded = false,
                            Message = "O campo Destino é obrigatório!"
                        };
                    }
                }
                else
                {
                    return new QueryResult<CompraItem>
                    {
                        Succeeded = false,
                        Message = "O campo Origem é obrigatório!"
                    };
                }
            }
            else
            {
                return new QueryResult<CompraItem>
                {
                    Succeeded = false,
                    Message = "O campo Empresa é obrigatório!"
                };
            }
        }


        public async Task<QueryResult<CompraItem>> AtualizarCompraItemAsync(int compraItemId, [FromBody] CompraItemModel model)
        {
            var compraItem = await _compraItemRepository.BuscaPorIdAsync(compraItemId);
            if (compraItem != null)
            {
                if (!string.IsNullOrEmpty(model.Empresa))
                {
                    if (!string.IsNullOrEmpty(model.Origem))
                    {
                        if (!string.IsNullOrEmpty(model.Destino))
                        {


                            compraItem.CompraId = model.CompraId;
                            compraItem.EmpresaId = model.EmpresaId;
                            compraItem.Empresa = model.Empresa;
                            compraItem.OrigemId = model.OrigemId;
                            compraItem.Origem = model.Origem;
                            compraItem.DestinoId = model.DestinoId;
                            compraItem.Destino = model.Destino;
                            compraItem.Preco = model.Preco;
                            compraItem.DtSaida = model.DtSaida;
                            compraItem.DtChegada = model.DtChegada;

                            await _compraItemRepository.InserirAsync(compraItem);
                            await _compraItemRepository.SalvarAsync();

                            return new QueryResult<CompraItem>
                            {
                                Succeeded = true,
                                Result = compraItem
                            };

                        }
                        else
                        {
                            return new QueryResult<CompraItem>
                            {
                                Succeeded = false,
                                Message = "O campo Destino é obrigatório!"
                            };
                        }
                    }
                    else
                    {
                        return new QueryResult<CompraItem>
                        {
                            Succeeded = false,
                            Message = "O campo Origem é obrigatório!"
                        };
                    }
                }
                else
                {
                    return new QueryResult<CompraItem>
                    {
                        Succeeded = false,
                        Message = "O campo Empresa é obrigatório!"
                    };
                }
            }
            else
            {
                return new QueryResult<CompraItem>
                {
                    Succeeded = false,
                    Message = "Cartão não encontrado!"
                };
            }
        }

        public async Task<QueryResult<CompraItem>> DeletarCompraItemAsync(int compraItemId)
        {
            var compraItem = await _compraItemRepository.BuscaPorIdAsync(compraItemId);
            if (compraItem != null)
            {
                compraItem.Status = false;

                _compraItemRepository.Atualizar(compraItem);
                await _compraItemRepository.SalvarAsync();

                return new QueryResult<CompraItem>
                {
                    Succeeded = true,
                    Message = "CompraItem deletada com sucesso."
                };
            }
            else
            {
                return new QueryResult<CompraItem>
                {
                    Succeeded = false,
                    Message = "CompraItem não encontrado!"
                };
            }
        }
    }
}
