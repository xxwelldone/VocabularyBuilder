using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VocabularyBuilder.Domain.Interface;
using VocabularyBuilder.Infra.Context;

namespace VocabularyBuilder.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private PostgreeSQL _context;
        public BaseRepository(PostgreeSQL context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToArrayAsync();

        }

        public async Task<T> GetBy(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }
        public T Create(T obj)
        {
            _context.Set<T>().Add(obj);
            return obj;
        }

        public T Update(T obj)
        {
            _context.Set<T>().Update(obj);
            return obj;
        }
        public T Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            return obj;



        }
    }
}
