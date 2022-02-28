using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Books_WebAPI.Models;

namespace Books_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _db;
        public BooksController (AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        //Get all books => api/book
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBook()
        {
            var books = _db.Books.ToList();
            return Ok(books);
        }
        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddBook(Book book)
        {
            return Ok(book);
        }
    }
}
