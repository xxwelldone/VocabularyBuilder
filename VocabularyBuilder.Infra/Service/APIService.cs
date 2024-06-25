using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyBuilder.Infra.Service
{
    public class APIService
    {
         //Sera herdada para especificar a API de consumo dictionary
         private readonly IHttpClientFactory _httpClientFactory;
        public APIService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
    }
}
