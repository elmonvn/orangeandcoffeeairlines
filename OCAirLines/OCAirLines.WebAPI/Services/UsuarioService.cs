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
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IList<Usuario>> TodosAsync() => await _usuarioRepository.Todos().ToListAsync();

        public async Task<Usuario> BuscaPorId(int usuarioId) => await _usuarioRepository.BuscaPorIdAsync(usuarioId);

        public async Task<QueryResult<Usuario>> IncluirUsuarioAsync([FromForm] UsuarioModel model)
        {
            if (!string.IsNullOrEmpty(model.Nome))
            {
                if (!string.IsNullOrEmpty(model.Sobrenome))
                {
                    if (!string.IsNullOrEmpty(model.TpIdentificacao))
                    {
                        if (!string.IsNullOrEmpty(model.NrIdentificacao))
                        {
                            if (!string.IsNullOrEmpty(model.Email))
                            {
                                var emailValidado = await _usuarioRepository.ValidaEmialAsync(model.Email);
                                if (emailValidado == null)
                                {
                                    if (!string.IsNullOrEmpty(model.Senha))
                                    {
                                        if (!string.IsNullOrEmpty(model.Telefone1))
                                        {
                                            var usuario = new Usuario
                                            { 
                                                Nome = model.Nome,
                                                Sobrenome = model.Sobrenome,
                                                TpIdentificacao = model.TpIdentificacao,
                                                NrIdentificacao = model.NrIdentificacao,
                                                Sexo = model.Sexo,
                                                Endereco = model.Endereco,
                                                Cidade = model.Cidade,
                                                UF = model.UF,
                                                Pais = model.Pais,
                                                Email = model.Email,
                                                Senha = model.Senha,
                                                Telefone1 = model.Telefone1,
                                                Telefone2 = model.Telefone2,
                                                Status = model.Status
                                            };

                                            await _usuarioRepository.InserirAsync(usuario);
                                            await _usuarioRepository.SalvarAsync();

                                            return new QueryResult<Usuario>
                                            {
                                                Succeeded = true,
                                                Result = usuario
                                            };
                                        }
                                        else
                                        {
                                            return new QueryResult<Usuario>
                                            {
                                                Succeeded = false,
                                                Message = "O campo Telefone é obrigatório!"
                                            };
                                        }
                                    }
                                    else
                                    {
                                        return new QueryResult<Usuario>
                                        {
                                            Succeeded = false,
                                            Message = "O campo Senha é obrigatório!"
                                        };
                                    }
                                }
                                else
                                {
                                    return new QueryResult<Usuario>
                                    {
                                        Succeeded = false,
                                        Message = "Email já cadastrado!"
                                    };
                                }
                            }
                            else
                            {
                                return new QueryResult<Usuario>
                                {
                                    Succeeded = false,
                                    Message = "O campo Email é obrigatório!"
                                };
                            }
                        }
                        else
                        {
                            return new QueryResult<Usuario>
                            {
                                Succeeded = false,
                                Message = "O campo Número da Identificação é obrigatório!"
                            };
                        }
                    }
                    else
                    {
                        return new QueryResult<Usuario>
                        {
                            Succeeded = false,
                            Message = "O campo Tipo da Identificação é obrigatório!"
                        };
                    }
                }
                else
                {
                    return new QueryResult<Usuario>
                    {
                        Succeeded = false,
                        Message = "O campo Sobrenome é obrigatório!"
                    };
                }
            }
            else
            {
                return new QueryResult<Usuario>
                {
                    Succeeded = false,
                    Message = "O campo Nome é obrigatório!"
                };
            }
        }

        public async Task<QueryResult<Usuario>> AtualizarUsuarioAsync(int usuarioId, [FromBody]UsuarioModel model)
        {
            var usuario = await _usuarioRepository.BuscaPorIdAsync(usuarioId);
            if (usuario != null)
            {
                if (!string.IsNullOrEmpty(model.Nome))
                {
                    if (!string.IsNullOrEmpty(model.Sobrenome))
                    {
                        if (!string.IsNullOrEmpty(model.TpIdentificacao))
                        {
                            if (!string.IsNullOrEmpty(model.NrIdentificacao))
                            {
                                if (!string.IsNullOrEmpty(model.Email))
                                {
                                    var emailValidado = await _usuarioRepository.ValidaEmialAsync(model.Email);
                                    if (emailValidado == null || (emailValidado != null && emailValidado.Id == usuarioId))
                                    {
                                        if (!string.IsNullOrEmpty(model.Senha))
                                        {
                                            if (!string.IsNullOrEmpty(model.Telefone1))
                                            {
                                                usuario.Nome = model.Nome;
                                                usuario.Sobrenome = model.Sobrenome;
                                                usuario.TpIdentificacao = model.TpIdentificacao;
                                                usuario.NrIdentificacao = model.NrIdentificacao;
                                                usuario.Sexo = model.Sexo;
                                                usuario.Endereco = model.Endereco;
                                                usuario.Cidade = model.Cidade;
                                                usuario.UF = model.UF;
                                                usuario.Pais = model.Pais;
                                                usuario.Email = model.Email;
                                                usuario.Senha = model.Senha;
                                                usuario.Telefone1 = model.Telefone1;
                                                usuario.Telefone2 = model.Telefone2;
                                                usuario.Status = model.Status;

                                                _usuarioRepository.Atualizar(usuario);
                                                await _usuarioRepository.SalvarAsync();

                                                return new QueryResult<Usuario>
                                                {
                                                    Succeeded = true,
                                                    Result = usuario
                                                };
                                            }
                                            else
                                            {
                                                return new QueryResult<Usuario>
                                                {
                                                    Succeeded = false,
                                                    Message = "O campo Telefone é obrigatório!"
                                                };
                                            }
                                        }
                                        else
                                        {
                                            return new QueryResult<Usuario>
                                            {
                                                Succeeded = false,
                                                Message = "O campo Senha é obrigatório!"
                                            };
                                        }
                                    }
                                    else
                                    {
                                        return new QueryResult<Usuario>
                                        {
                                            Succeeded = false,
                                            Message = "Email já cadastrado!"
                                        };
                                    }
                                }
                                else
                                {
                                    return new QueryResult<Usuario>
                                    {
                                        Succeeded = false,
                                        Message = "O campo Email é obrigatório!"
                                    };
                                }
                            }
                            else
                            {
                                return new QueryResult<Usuario>
                                {
                                    Succeeded = false,
                                    Message = "O campo Número da Identificação é obrigatório!"
                                };
                            }
                        }
                        else
                        {
                            return new QueryResult<Usuario>
                            {
                                Succeeded = false,
                                Message = "O campo Tipo da Identificação é obrigatório!"
                            };
                        }
                    }
                    else
                    {
                        return new QueryResult<Usuario>
                        {
                            Succeeded = false,
                            Message = "O campo Sobrenome é obrigatório!"
                        };
                    }
                }
                else
                {
                    return new QueryResult<Usuario>
                    {
                        Succeeded = false,
                        Message = "O campo Nome é obrigatório!"
                    };
                }
            }
            else
            {
                return new QueryResult<Usuario>
                {
                    Succeeded = false,
                    Message = "Usuário não encontrado!"
                };
            }
        }

        public async Task<QueryResult<Usuario>> DeletarUsuarioAsync(int usuarioId)
        {
            var usuario = await _usuarioRepository.BuscaPorIdAsync(usuarioId);
            if (usuario != null)
            {
                usuario.Status = false;

                _usuarioRepository.Atualizar(usuario);
                await _usuarioRepository.SalvarAsync();

                return new QueryResult<Usuario>
                {
                    Succeeded = true,
                    Message = "Usuário deletado com sucesso."
                };
            }
            else
            {
                return new QueryResult<Usuario>
                {
                    Succeeded = false,
                    Message = "Usuário não encontrado!"
                };
            }
        }
    }
}
