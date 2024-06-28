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
        private IMeaningRepository? _meaningRepository;

        private PostgreeSQL _context;
        public UnitOfWork(PostgreeSQL context)
        {
            _context = context;
        }
        public IBookRepository BookRepository => _bookRepository ?? new BookRepository(_context);

        public IVocabularyRepository VocabularyRepository => _vocabularyRepository ?? new VocabularyRepository(_context);

        public IMeaningRepository MeaningRepository => _meaningRepository ?? new MeaningRepository(_context);
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
