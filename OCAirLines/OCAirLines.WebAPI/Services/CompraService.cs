using OCAirLines.WebAPI.Interfaces;
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OCAirLines.Database.Contexts;
using OCAirLines.Database.Helpers;
using OCAirLines.Database.Models;
using OCAirLines.Database.Repositories.WebAPI;
using OCAirLines.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.WebAPI.Services
{
    public class CompraService : ICompraService
    {
        private readonly ICompraRepository _compraRepository;

        public CompraService(ICompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }

        public async Task<IList<Compra>> TodosAsync() => await _compraRepository.Todos().ToListAsync();

        public async Task<Compra> BuscaPorId(int compraId) => await _compraRepository.BuscaPorIdAsync(compraId);

        public async Task<QueryResult<Compra>> IncluirCompraAsync([FromForm] CompraModel model)
        {
            
            var compra = new Compra
            { 
                UsuarioId = model.UsuarioId,
                CartaoId = model.CartaoId,
                DtCompra = model.DtCompra,
                QtdParcela = model.QtdParcela,
                Status = model.Status
            };

            await _compraRepository.InserirAsync(compra);
            await _compraRepository.SalvarAsync();

            return new QueryResult<Compra>
            {
                Succeeded = true,
                Result = compra
            };
                                        
        }

        public async Task<QueryResult<Compra>> AtualizarCompraAsync(int compraId, [FromBody]CompraModel model)
        {
            var compra = await _compraRepository.BuscaPorIdAsync(compraId);
            if (compra != null)
            {

                compra.UsuarioId = model.UsuarioId;
                compra.CartaoId = model.CartaoId;
                compra.DtCompra = model.DtCompra;
                compra.QtdParcela = model.QtdParcela;
                compra.Status = model.Status;

                _compraRepository.Atualizar(compra);
                await _compraRepository.SalvarAsync();

                return new QueryResult<Compra>
                {
                    Succeeded = true,
                    Result = compra
                };
            }
            else
            { 
                return new QueryResult<Compra>
                {
                    Succeeded = false,
                    Message = "Compra não encontrada!"
                };
            }
        }

        public async Task<QueryResult<Compra>> DeletarCompraAsync(int compraId)
        {
            var compra = await _compraRepository.BuscaPorIdAsync(compraId);
            if (compra != null)
            {
                compra.Status = false;

                _compraRepository.Atualizar(compra);
                await _compraRepository.SalvarAsync();

                return new QueryResult<Compra>
                {
                    Succeeded = true,
                    Message = "Compra deletada com sucesso."
                };
            }
            else
            {
                return new QueryResult<Compra>
                {
                    Succeeded = false,
                    Message = "Compra não encontrada!"
                };
            }
        }
    }
}
