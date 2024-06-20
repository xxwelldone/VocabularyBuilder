using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyBuilder.Domain.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetBy(Expression<Func<T, bool>> expression);
        T Create(T obj);
        T Delete(T obj);
        T Update (T obj);
    }
}
