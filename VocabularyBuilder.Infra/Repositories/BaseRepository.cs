using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VocabularyBuilder.Domain.Interface;

namespace VocabularyBuilder.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        public BaseRepository()
        {
            
        }
        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();

        }

        public Task<T> GetById(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }
        public T Create(T obj)
        {
            throw new NotImplementedException();
        }

        public T Update(T obj)
        {
            throw new NotImplementedException();
        }
        public T Delete(T obj)
        {
            throw new NotImplementedException();
        }


    }
}
