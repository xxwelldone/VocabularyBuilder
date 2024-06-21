using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabularyBuilder.Domain.Interface;
using VocabularyBuilder.Infra.Context;
using VocabularyBuilder.Infra.Repositories;

namespace VocabularyBuilder.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IBookRepository? _bookRepository;
        private IVocabularyRepository? _vocabularyRepository;

        private PostgreeSQL _context;
        public UnitOfWork(PostgreeSQL context)
        {
            _context = context;
        }
        public IBookRepository BookRepository => _bookRepository ?? new BookRepository(_context);

        public IVocabularyRepository VocabularyRepository => _vocabularyRepository ?? new VocabularyRepository(_context);


        public Task Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
