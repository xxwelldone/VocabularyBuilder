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
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var books = await _unitOfWork.BookRepository.GetAll();

            return books;
        }

        public async Task<Book> GetBookByFilter(Expression<Func<Book, bool>> expression)
        {
            var books = await _unitOfWork.BookRepository.GetBy(expression);
            if (books == null) { throw new NotFoundException("No books with argument provided was found"); }
            return books;
        }
        public async Task<Book> SaveBook(Book book)
        {
            var teste = await GetBookByFilter(x => x.Title == book.Title);
            if (teste != null)
            {
                throw new AlreadyExistsException("Cannot save this book because it already exists in the database");
            }
            var bookReturn = _unitOfWork.BookRepository.Create(book);
            return bookReturn;
        }

        public async Task<Book> UpdateBook(Book book, int id)
        {
            if (book.Id == id)
            {
                var teste = await GetBookByFilter(x => x.Id == book.Id);

                if (teste == null)
                {
                    throw new NotFoundException("Book not found");
                }
                var bookReturn = _unitOfWork.BookRepository.Update(book);
                return bookReturn;
            }
            else {
                throw new NotFoundException("ID and Book are different");
            }
        }
        public async Task<Book> DeleteBook(int id)
        {
            var bookToBeDeleted = await GetBookByFilter(x => x.Id == id);
            if (bookToBeDeleted == null) {
                throw new NotFoundException("No Book with such ID found");
            }
            var bookReturn = _unitOfWork.BookRepository.Delete(bookToBeDeleted);
            return bookToBeDeleted;
        }
    }

}
