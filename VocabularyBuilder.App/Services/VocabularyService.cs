using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VocabularyBuilder.App.Interfaces;
using VocabularyBuilder.Domain.CustomException;
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

        public async Task<Vocabulary> GetVocabularyByFilter(Expression<Func<Vocabulary, bool>> expression)
        {

            var vocab = await _unitOfWork.VocabularyRepository.GetBy(expression);
            if (vocab == null) { throw new NotFoundException("No Vocabulary found"); }
            return vocab;

        }

        public async Task<Vocabulary> SaveVocabulary(Vocabulary vocabulary)
        {
            var teste = await GetVocabularyByFilter(x => x.Word == vocabulary.Word);
            if (teste != null) { throw new AlreadyExistsException($"You are trying to save a Word that already Exists, ID: {teste.Id}."); }
            var vocab = _unitOfWork.VocabularyRepository.Create(vocabulary);
            return vocab;
        }

        public async Task<Vocabulary> UpdateVocabulary(Vocabulary vocabulary, int id)
        {
            if (vocabulary.Id == id)
            {
                var teste = await GetVocabularyByFilter(x => x.Id == id);
                if (teste == null)
                {
                    throw new NotFoundException($"No vocabulary found to be updated, try saving first");
                }
                var vocab = _unitOfWork.VocabularyRepository.Update(vocabulary);
                return vocab;

            }
            else
            {
                throw new NotFoundException($"ID provided: {id} and object ID {vocabulary.Id} must be the same"); ;
            }
        }
        public async Task<Vocabulary> DeleteVocabulary(string word)
        {
            var vocabularyToBeDeleted = await GetVocabularyByFilter(x => x.Word == word);
            if (vocabularyToBeDeleted != null)
            {
                var vocab = _unitOfWork.VocabularyRepository.Delete(vocabularyToBeDeleted);
                return vocab;


            }
            else
            {
                throw new NotFoundException($"No vocabulary with such word {word} was found to be deleted");
            }

        }
    }
}
