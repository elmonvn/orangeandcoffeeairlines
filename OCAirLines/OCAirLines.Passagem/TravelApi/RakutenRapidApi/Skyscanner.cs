using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.Filters;
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
        static string urlBase = Environment.GetEnvironmentVariable("SKYSCANNER_URL");
        static string apiHost = Environment.GetEnvironmentVariable("SKYSCANNER_API_HOST");
        static string apiKey = Environment.GetEnvironmentVariable("SKYSCANNER_API_KEY");
        static string apiQueriString = Environment.GetEnvironmentVariable("SKYSCANNER_QUERYSTRING");
        public static async Task<List<Lugar>> BuscarLocalAsync(string filtro)
        {

            client = new HttpClient();
            string url = urlBase + $@"/autosuggest/v1.0/BR/BRL/pt-BR/?query={filtro}";
            client.DefaultRequestHeaders.Add("x-rapidapi-host", apiHost);
            client.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);
            client.DefaultRequestHeaders.Add("useQueryString", apiQueriString);
            HttpResponseMessage response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new WebException("Não foi possivel completar a busca.");

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var localResultList = new List<Lugar>();
            foreach (var local in data.Places)
            {
                var localResult = new Lugar();
                localResult.AeroportoId = local.PlaceId;
                localResult.CidadeId = local.CityId;
                localResult.CidadeNome = local.PlaceName;
                localResult.PaisNome = local.CountryName;
                localResult.PaisId = local.CountryId;
                localResultList.Add(localResult);
            }
            return localResultList;
        }

        internal static async Task<string> BuscarPorVoos(string localIda, string localDestino, string dataIda, string dataVolta)
        {
            client = new HttpClient();
            string url = urlBase + $@"/browsedates/v1.0/BR/BRL/pt-BR/{localIda}/{localDestino}/{dataIda}/{dataVolta}";
            client.DefaultRequestHeaders.Add("x-rapidapi-host", apiHost);
            client.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);
            client.DefaultRequestHeaders.Add("useQueryString", apiQueriString);
            HttpResponseMessage response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new WebException("Não foi possivel completar a busca.");

            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
