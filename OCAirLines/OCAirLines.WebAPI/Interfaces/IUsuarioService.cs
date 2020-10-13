using Microsoft.AspNetCore.Mvc;
using OCAirLines.Database.Helpers;
using OCAirLines.Database.Models;
using OCAirLines.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.WebAPI.Interfaces
{
    public interface IUsuarioService
    {
        Task<IList<Usuario>> TodosAsync();
        Task<Usuario> BuscaPorId(int usuarioId);
        Task<QueryResult<Usuario>> IncluirUsuarioAsync([FromForm]UsuarioModel model);
        Task<QueryResult<Usuario>> AtualizarUsuarioAsync(int usuarioId, [FromBody]UsuarioModel model);
        Task<QueryResult<Usuario>> DeletarUsuarioAsync(int usuarioId);
    }
}
