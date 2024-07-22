using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VocabularyBuilder.App.Interfaces;
using VocabularyBuilder.Domain.Entities;
using VocabularyBuilder.Domain.Interface;

namespace VocabularyBuilder.App.Services
{
    public class VocabularyService : IVocabularyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VocabularyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Vocabulary>> GetAllVocabularies()
        {
            var vocabs = await _unitOfWork.VocabularyRepository.GetAll();
            return vocabs;
        }

        public async Task<Vocabulary?> GetByFilter(Expression<Func<Vocabulary, bool>> expression)
        {
           
            var vocab = await _unitOfWork.VocabularyRepository.GetBy(expression);
            if (vocab == null) { return null; }
            return vocab;

        }

        public Vocabulary SaveVocabulary(Vocabulary vocabulary)
        {
            var vocab = _unitOfWork.VocabularyRepository.Create(vocabulary);
            return vocab;
        }

        public Vocabulary UpdateVocabulary(Vocabulary vocabulary)
        {
            var vocab = _unitOfWork.VocabularyRepository.Update(vocabulary);
            return vocab;
        }
        public Vocabulary DeleteVocabulary(Vocabulary vocabulary)
        {
            var vocab = _unitOfWork.VocabularyRepository.Delete(vocabulary);   
            return vocab;
        }

    }
}
