using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VocabularyBuilder.Domain.Interface.Services;

namespace VocabularyBuilder.Infra.Service
{
    public class BaseAPIService<T> : IBaseAPIService<T> where T : class
    {
        //Sera herdada para especificar a API de consumo dictionary
        public readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _serializerOptions;
        protected readonly HttpClient _client;
        

        private IEnumerable<T> list;

        public BaseAPIService(IHttpClientFactory httpClientFactory, string clientName)
        {
            _httpClientFactory = httpClientFactory;
            _client = _httpClientFactory.CreateClient(clientName); ///api/v2/entries/en será enviada pelas filhas
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
           
        }

        public async Task<IEnumerable<T>> GetData(string word)
        {
            using (var response = await _client.GetAsync($"/{word}"))
            {
                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    list = await JsonSerializer.DeserializeAsync<IEnumerable<T>>(apiResponse, _serializerOptions);

                }
                else
                {
                    return null;
                }
                return list;
            }
        }
    }
}
