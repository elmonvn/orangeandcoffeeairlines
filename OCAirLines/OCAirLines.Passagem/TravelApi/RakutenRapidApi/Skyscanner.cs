using Microsoft.AspNetCore.Server.IIS.Core;
using Newtonsoft.Json.Linq;
using OCAirLines.Passagem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace OCAirLines.Passagem.TravelApi.RakutenRapidApi
{
    public class Skyscanner
    {
        static HttpClient client = new HttpClient();
        static string urlPrefix = "https://skyscanner-skyscanner-flight-search-v1.p.rapidapi.com/apiservices";
        public static async Task<List<Lugar>> BuscarLocalAsync(string filtro)
        {

            client = new HttpClient();
            string urlListPlaces = urlPrefix + $@"/autosuggest/v1.0/BR/BRL/pt-BR/?query={filtro}";

            client.DefaultRequestHeaders.Add("x-rapidapi-host", "skyscanner-skyscanner-flight-search-v1.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("x-rapidapi-key", "505a08782emshf600d4645df7d16p196c75jsnc38df934880a");
            client.DefaultRequestHeaders.Add("useQueryString", "true");
            HttpResponseMessage response = await client.GetAsync(urlListPlaces);

            if (!response.IsSuccessStatusCode)
                throw new WebException("Não foi possivel completar a busca.");

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var localResultList = new List<Lugar>();
            foreach (var local in data.Places)
            {
                var localResult = new Lugar();
                localResult.LugarId = local.PlaceId;
                localResult.CidadeId = local.CityId;
                localResult.CidadeNome = local.PlaceName;
                localResult.PaisNome = local.CountryName;
                localResult.PaisId = local.CountryId;
                localResultList.Add(localResult);
            }

            return localResultList;

        }
    }
}
