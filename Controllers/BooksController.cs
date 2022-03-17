using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Books_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

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
            return Ok(await _db.Books.ToListAsync());
        }
        // Get a specific book [HttpGet("{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            //if database is empty just return BadRequest
            if (_db.Books == null)
            {
                return BadRequest("Book Not Found");
            }

            //else find the book with matching id
            var book = _db.Books.SingleAsync(b => b.Id == id);
            return Ok(await book);
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddBook(Book book)
        {
            return Ok(book);
        }
    }
}
