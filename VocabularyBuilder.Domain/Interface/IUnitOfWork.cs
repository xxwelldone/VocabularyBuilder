using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyBuilder.Domain.Interface
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        IVocabularyRepository VocabularyRepository { get; }
        IMeaningRepository MeaningRepository { get; }
        Task Commit();
        void Dispose();
    }
}
