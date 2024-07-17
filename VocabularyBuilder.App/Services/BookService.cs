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
    public class BookService : IBookService
    {
        readonly IUnitOfWork _unitOfWork;
        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Book>> GetAllBooks()
        {
            var books = _unitOfWork.BookRepository.GetAll();
          
            return books;
        }

        public Task<Book?> GetBookByFilter(Expression<Func<Book, bool>> expression)
        {
            var books = _unitOfWork.BookRepository.GetBy(expression);
            return books;
        }
        public Book SaveBook(Book book)
        {
           var bookReturn = _unitOfWork.BookRepository.Create(book);
            return bookReturn;
        }

        public Book UpdateBook(Book book)
        {
            var bookReturn = _unitOfWork.BookRepository.Update(book);
            return bookReturn;
        }
        public Book DeleteBook(Book book)
        {
            var bookReturn = _unitOfWork.BookRepository.Delete(book);
            return bookReturn;
        }
    }
    
 }
