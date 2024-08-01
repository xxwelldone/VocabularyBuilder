using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VocabularyBuilder.Domain.Entities;

namespace VocabularyBuilder.App.Interfaces
{
    public interface IVocabularyService
    {
        Task<IEnumerable<Vocabulary>> GetAllVocabularies();
        Task<Vocabulary> GetVocabularyByFilter(Expression<Func<Vocabulary, bool>> expression);
        Task<Vocabulary> SaveVocabulary(Vocabulary vocabulary);
        Task<Vocabulary> UpdateVocabulary(Vocabulary vocabulary, int id);
        Task<Vocabulary> DeleteVocabulary(string word);


    }
}
