using Microsoft.AspNetCore.Mvc;
using TestThiBackEnd.Models;
using TestThiBackEnd.Repository;

namespace TestThiBackEnd.Controller { 
    [ApiController]
    [Route("api/[controller]")]

    public class BooksController : ControllerBase
    {
        private readonly IBookRepository<Book> _bookRepo;
        // --- BỔ SUNG ĐOẠN NÀY ---
        public BooksController(IBookRepository<Book> bookRepo)
        {
            _bookRepo = bookRepo;
        }
        // ------------------------

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepo.GetAll();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepo.GetById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            var newBook = await _bookRepo.Add(book);
            return Ok(newBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Book book) { await _bookRepo.Update(book);
        return Ok(book);}


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookRepo.Delete(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
