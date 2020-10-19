using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OCAirLines.Database.Helpers;
using OCAirLines.Passagem.Services.Interfaces;
using OCAirLines.Passagem.TravelApi.RakutenRapidApi;
using OCAirLines.Passagem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OCAirLines.Passagem.Services
{
    public class PassagemServices : IPassagemServices
    {
        public async Task<QueryResult<string>> BuscaPorVoos(string localIda, string localDestino, string dataIda, string dataVolta)
        {
            var result = new QueryResult<string>();
            var retorno = await Skyscanner.BuscarPorVoos(localIda, localDestino, dataIda, dataVolta);
            result.Result = retorno;
            result.Succeeded = true;
            return result;
        }

        public async Task<QueryResult<List<Lugar>>> BuscaPorLocal(string filtro) 
        {
            var result = new QueryResult<List<Lugar>>();
            result.Result = await Skyscanner.BuscarLocalAsync(filtro);
            result.Succeeded = true;
            return result;
        }
    }
}
