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
        Task<Vocabulary?> GetByFilter(Expression<Func<Vocabulary, bool>> expression);
        Vocabulary SaveVocabulary(Vocabulary vocabulary);
        Vocabulary UpdateVocabulary(Vocabulary vocabulary);
        Vocabulary DeleteVocabulary(Vocabulary vocabulary);


    }
}
