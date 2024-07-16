using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VocabularyBuilder.Domain.Entities;
using VocabularyBuilder.Domain.Entities.ExternalAPI;
using VocabularyBuilder.Domain.Interface.Adapter;

namespace VocabularyBuilder.Infra.Adapter
{
    public class DictionaryAPIAdapter : BaseAdapter, IDictionaryAPIAdapter
    {
       
        private const string _endpoint = "/api/v2/entries/en";

        public DictionaryAPIAdapter(ILogger<BaseAdapter> logger, IConfiguration configuration) : base(logger, configuration)
        {
            _baseUrl = configuration["ServiceUri:FreeDictionaryAPI"];
        }

        public async Task<Dictionary> GetOnDictionary(string word)
        {
            string url = _baseUrl + _endpoint + word;

            var result = await CallAPI(url, HttpMethod.Get, null, null);

            if (result != null && result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var dictionary = JsonConvert.DeserializeObject<Dictionary>(content); //criar uma classe dictionary abrangente para puxar dados para classes individuais
                return dictionary;
            }

            return null; // Handle error cases appropriately
        }
    }

}

