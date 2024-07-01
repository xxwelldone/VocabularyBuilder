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

        private const string apiEndpoint = "/en/";
        private IEnumerable<T> list;

        public BaseAPIService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<T>> GetData(string word)
        {
            var client = _httpClientFactory.CreateClient("dictionaryapi");
            using (var response = await client.GetAsync($"{apiEndpoint}/{word}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    
                    var apiResponse= await response.Content.ReadAsStreamAsync();
                   
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
