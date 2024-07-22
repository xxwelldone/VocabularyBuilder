


using System.Linq.Expressions;
using VocabularyBuilder.App.Interfaces;
using VocabularyBuilder.Domain.Entities;
using VocabularyBuilder.Domain.Interface;

namespace VocabularyBuilder.App.Services
{
    public class MeaningService : IMeaningService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MeaningService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Meaning>> GetAllByMeaning()
        {
            var meanings = await _unitOfWork.MeaningRepository.GetAll();
            return meanings;
        }

        public async Task<Meaning?> GetByFilter(Expression<Func<Meaning, bool>> expression)
        {
            var meaning = await _unitOfWork.MeaningRepository.GetBy(expression);
            if (meaning == null) { return null; }
            return meaning;
        }

        public Meaning SaveMeaning(Meaning meaning)
        {
            var meaningretorno = _unitOfWork.MeaningRepository.Create(meaning);
            return meaningretorno;
        }

        public Meaning UpdateMeaning(Meaning meaning)
        {
           var meaningretorno = _unitOfWork.MeaningRepository.Update(meaning);
            return meaningretorno;
        }
        public Meaning DeleteMeaning(Meaning meaning)
        {
            var meaningretorno = _unitOfWork.MeaningRepository.Delete(meaning);
            return meaningretorno;
        }
    }
}
