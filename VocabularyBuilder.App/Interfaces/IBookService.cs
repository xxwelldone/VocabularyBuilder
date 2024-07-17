using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VocabularyBuilder.Domain.Entities;

namespace VocabularyBuilder.App.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookByFilter(Expression<Func<Book, bool>> expression);
        Book SaveBook(Book book);
        Book UpdateBook(Book book);

       Book DeleteBook(Book book);
    }
}
