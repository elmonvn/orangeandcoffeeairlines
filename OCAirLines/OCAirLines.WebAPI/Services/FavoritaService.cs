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
    public class FavoritaService : IFavoritaService
    {
        private readonly IFavoritaRepository _favoritaRepository;

        public FavoritaService(IFavoritaRepository FavoritaRepository)
        {
            _favoritaRepository = FavoritaRepository;
        }

        public async Task<IList<Favorita>> TodosPorUsuarioAsync(int usuarioId) => await _favoritaRepository.TodosPorUsuario(usuarioId).ToListAsync();

        public async Task<Favorita> BuscaPorId(int favoritaId) => await _favoritaRepository.BuscaPorIdAsync(favoritaId);

        public async Task<QueryResult<Favorita>> IncluirFavoritaAsync([FromForm] FavoritaModel model)
        {

            if (!string.IsNullOrEmpty(model.Empresa))
            {
                if (!string.IsNullOrEmpty(model.Origem))
                {
                    if (!string.IsNullOrEmpty(model.Destino))
                    {

                        var favorita = new Favorita
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

                        await _favoritaRepository.InserirAsync(favorita);
                        await _favoritaRepository.SalvarAsync();

                        return new QueryResult<Favorita>
                        {
                            Succeeded = true,
                            Result = favorita
                        };

                        
                    }
                    else
                    {
                        return new QueryResult<Favorita>
                        {
                            Succeeded = false,
                            Message = "O campo Destino é obrigatório!"
                        };
                    }
                }
                else
                {
                    return new QueryResult<Favorita>
                    {
                        Succeeded = false,
                        Message = "O campo Origem é obrigatório!"
                    };
                }
            }
            else
            {
                return new QueryResult<Favorita>
                {
                    Succeeded = false,
                    Message = "O campo Empresa é obrigatório!"
                };
            }
        }


        public async Task<QueryResult<Favorita>> AtualizarFavoritaAsync(int favoritaId, [FromBody] FavoritaModel model)
        {
            var favorita = await _favoritaRepository.BuscaPorIdAsync(favoritaId);
            if (favorita != null)
            {
                if (!string.IsNullOrEmpty(model.Empresa))
                {
                    if (!string.IsNullOrEmpty(model.Origem))
                    {
                        if (!string.IsNullOrEmpty(model.Destino))
                        {


                            favorita.UsuarioId = model.UsuarioId;
                            favorita.EmpresaId = model.EmpresaId;
                            favorita.Empresa = model.Empresa;
                            favorita.OrigemId = model.OrigemId;
                            favorita.Origem = model.Origem;
                            favorita.DestinoId = model.DestinoId;
                            favorita.Destino = model.Destino;
                            favorita.Preco = model.Preco;
                            favorita.DtSaida = model.DtSaida;
                            favorita.DtChegada = model.DtChegada;

                            await _favoritaRepository.InserirAsync(favorita);
                            await _favoritaRepository.SalvarAsync();

                            return new QueryResult<Favorita>
                            {
                                Succeeded = true,
                                Result = favorita
                            };

                        }
                        else
                        {
                            return new QueryResult<Favorita>
                            {
                                Succeeded = false,
                                Message = "O campo Destino é obrigatório!"
                            };
                        }
                    }
                    else
                    {
                        return new QueryResult<Favorita>
                        {
                            Succeeded = false,
                            Message = "O campo Origem é obrigatório!"
                        };
                    }
                }
                else
                {
                    return new QueryResult<Favorita>
                    {
                        Succeeded = false,
                        Message = "O campo Empresa é obrigatório!"
                    };
                }
            }
            else
            {
                return new QueryResult<Favorita>
                {
                    Succeeded = false,
                    Message = "Cartão não encontrado!"
                };
            }
        }

        public async Task<QueryResult<Favorita>> DeletarFavoritaAsync(int favoritaId)
        {
            var favorita = await _favoritaRepository.BuscaPorIdAsync(favoritaId);
            if (favorita != null)
            {
                favorita.Status = false;

                _favoritaRepository.Atualizar(favorita);
                await _favoritaRepository.SalvarAsync();

                return new QueryResult<Favorita>
                {
                    Succeeded = true,
                    Message = "Favorita deletada com sucesso."
                };
            }
            else
            {
                return new QueryResult<Favorita>
                {
                    Succeeded = false,
                    Message = "Favorita não encontrado!"
                };
            }
        }
    }
}
