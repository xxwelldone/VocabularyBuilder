﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VocabularyBuilder.App.Interfaces;
using VocabularyBuilder.Domain.CustomException;
using VocabularyBuilder.Domain.Entities;

namespace VocabularyBuilder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll() { 
            return Ok(await _bookService.GetAllBooks());
        }
        [HttpGet("SearchById")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            try {
                var search = await _bookService.GetBookByFilter(x => x.Id == id);
                return Ok(search);
            
            } catch (NotFoundException e) {
                return NotFound($"No book found with such ID {id}");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Book>> Post(Book book) {
            try { 
                var SavedBook = await _bookService.SaveBook(book);
                return new CreatedAtRouteResult(await GetById(SavedBook.Id), SavedBook);
            }
            catch (AlreadyExistsException e) { 
                return BadRequest(e.Message);
            }
        }
        
    }
}
