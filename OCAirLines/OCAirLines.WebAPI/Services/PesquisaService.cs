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
    public class PesquisaService : IPesquisaService
    {
        private readonly IPesquisaRepository _pesquisaRepository;

        public PesquisaService(IPesquisaRepository PesquisaRepository)
        {
            _pesquisaRepository = PesquisaRepository;
        }

        public async Task<IList<Pesquisa>> TodosPorUsuarioAsync(int usuarioId) => await _pesquisaRepository.TodosPorUsuario(usuarioId).ToListAsync();

        public async Task<Pesquisa> BuscaPorId(int pesquisaId) => await _pesquisaRepository.BuscaPorIdAsync(pesquisaId);

        public async Task<QueryResult<Pesquisa>> IncluirPesquisaAsync([FromForm] PesquisaModel model)
        {

            if (!string.IsNullOrEmpty(model.Empresa))
            {
                if (!string.IsNullOrEmpty(model.Origem))
                {
                    if (!string.IsNullOrEmpty(model.Destino))
                    {

                        var pesquisa = new Pesquisa
                        {
                            UsuarioId = model.UsuarioId,
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

                        await _pesquisaRepository.InserirAsync(pesquisa);
                        await _pesquisaRepository.SalvarAsync();

                        return new QueryResult<Pesquisa>
                        {
                            Succeeded = true,
                            Result = pesquisa
                        };

                        
                    }
                    else
                    {
                        return new QueryResult<Pesquisa>
                        {
                            Succeeded = false,
                            Message = "O campo Destino é obrigatório!"
                        };
                    }
                }
                else
                {
                    return new QueryResult<Pesquisa>
                    {
                        Succeeded = false,
                        Message = "O campo Origem é obrigatório!"
                    };
                }
            }
            else
            {
                return new QueryResult<Pesquisa>
                {
                    Succeeded = false,
                    Message = "O campo Empresa é obrigatório!"
                };
            }
        }


        public async Task<QueryResult<Pesquisa>> AtualizarPesquisaAsync(int pesquisaId, [FromBody] PesquisaModel model)
        {
            var pesquisa = await _pesquisaRepository.BuscaPorIdAsync(pesquisaId);
            if (pesquisa != null)
            {
                if (!string.IsNullOrEmpty(model.Empresa))
                {
                    if (!string.IsNullOrEmpty(model.Origem))
                    {
                        if (!string.IsNullOrEmpty(model.Destino))
                        {


                            pesquisa.UsuarioId = model.UsuarioId;
                            pesquisa.EmpresaId = model.EmpresaId;
                            pesquisa.Empresa = model.Empresa;
                            pesquisa.OrigemId = model.OrigemId;
                            pesquisa.Origem = model.Origem;
                            pesquisa.DestinoId = model.DestinoId;
                            pesquisa.Destino = model.Destino;
                            pesquisa.Preco = model.Preco;
                            pesquisa.DtSaida = model.DtSaida;
                            pesquisa.DtChegada = model.DtChegada;

                            await _pesquisaRepository.InserirAsync(pesquisa);
                            await _pesquisaRepository.SalvarAsync();

                            return new QueryResult<Pesquisa>
                            {
                                Succeeded = true,
                                Result = pesquisa
                            };

                        }
                        else
                        {
                            return new QueryResult<Pesquisa>
                            {
                                Succeeded = false,
                                Message = "O campo Destino é obrigatório!"
                            };
                        }
                    }
                    else
                    {
                        return new QueryResult<Pesquisa>
                        {
                            Succeeded = false,
                            Message = "O campo Origem é obrigatório!"
                        };
                    }
                }
                else
                {
                    return new QueryResult<Pesquisa>
                    {
                        Succeeded = false,
                        Message = "O campo Empresa é obrigatório!"
                    };
                }
            }
            else
            {
                return new QueryResult<Pesquisa>
                {
                    Succeeded = false,
                    Message = "Cartão não encontrado!"
                };
            }
        }

        public async Task<QueryResult<Pesquisa>> DeletarPesquisaAsync(int pesquisaId)
        {
            var pesquisa = await _pesquisaRepository.BuscaPorIdAsync(pesquisaId);
            if (pesquisa != null)
            {
                pesquisa.Status = false;

                _pesquisaRepository.Atualizar(pesquisa);
                await _pesquisaRepository.SalvarAsync();

                return new QueryResult<Pesquisa>
                {
                    Succeeded = true,
                    Message = "Pesquisa deletada com sucesso."
                };
            }
            else
            {
                return new QueryResult<Pesquisa>
                {
                    Succeeded = false,
                    Message = "Pesquisa não encontrado!"
                };
            }
        }
    }
}
