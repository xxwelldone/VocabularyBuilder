using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VocabularyBuilder.Domain.Entities;
using VocabularyBuilder.Domain.Interface.Services;

namespace VocabularyBuilder.Infra.Service
{

    public class VocabularyAPIService : BaseAPIService<Vocabulary>, IVocabularyAPIService
    {
        public VocabularyAPIService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }
    }
}
