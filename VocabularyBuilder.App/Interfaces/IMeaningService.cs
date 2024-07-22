
using System.Linq.Expressions;
using VocabularyBuilder.Domain.Entities;

namespace VocabularyBuilder.App.Interfaces
{
    public interface IMeaningService
    {
        Task<IEnumerable<Meaning>> GetAllByMeaning();
        Task<Meaning?> GetByFilter(Expression<Func<Meaning, bool>> expression);
        Meaning SaveMeaning(Meaning meaning);
        Meaning UpdateMeaning(Meaning meaning);
        Meaning DeleteMeaning(Meaning meaning);

    }
}
