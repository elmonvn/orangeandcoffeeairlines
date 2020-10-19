using OCAirLines.Database.Helpers;
using OCAirLines.Passagem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.Passagem.Services.Interfaces
{
    public interface IPassagemServices
    {
        Task<QueryResult<List<Lugar>>> BuscaPorLocal(string filtro);
        Task<QueryResult<string>> BuscaPorVoos(string localIda, string localDestino, string dataIda, string dataVolta);
    }
}
