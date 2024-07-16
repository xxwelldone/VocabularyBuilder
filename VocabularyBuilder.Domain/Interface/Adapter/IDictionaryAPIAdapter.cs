using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabularyBuilder.Domain.Entities;
using VocabularyBuilder.Domain.Entities.ExternalAPI;

namespace VocabularyBuilder.Domain.Interface.Adapter
{
    public interface IDictionaryAPIAdapter
    {
        Task<Dictionary> GetOnDictionary(string word);
    }
}
