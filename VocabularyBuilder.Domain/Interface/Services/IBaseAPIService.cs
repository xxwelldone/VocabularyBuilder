using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyBuilder.Domain.Interface.Services
{
    public interface IBaseAPIService<T> where T : class
    {
        Task<IEnumerable<T>> GetData(string word);
    }
}
