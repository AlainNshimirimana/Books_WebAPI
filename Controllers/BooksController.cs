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
        // Create/Add a new book
        [HttpPost]
        public ActionResult<List<Book>> AddBook(Book newBook)
        {
            _db.Books.Add(newBook);
            _db.SaveChanges();
            return Ok(newBook);
        }

        //Get all books => api/book
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBook()
        {
            return Ok(await _db.Books.ToListAsync());
        }
        // Get a specific book [HttpGet("{id}")]
        [HttpGet("{id}")]
        public ActionResult<Book> GetSingleBook(int id)
        {
            //if database is empty just return BadRequest
            if (_db.Books == null || id <= 0)
            {
                return BadRequest("Invalid Book id");
            }

            //else find the book with matching id
            var book = _db.Books.Single(b => b.Id == id);
            return Ok(book);
        }
        // Update a book
        [HttpPut]
        public ActionResult<List<Book>> UpdateBook(Book request)
        {
            var book = _db.Books.Single(b => b.Id == request.Id);
            if(book == null)
            {
                return BadRequest("Book not found");
            }
            // new/updated information for the book
            book.firstName = request.firstName;
            book.lastName = request.lastName;
            book.bookTitle = request.bookTitle;
            _db.Books.Update(book); // add the updates to the database
            _db.SaveChanges(); // save database
            return Ok(book);
        }
        // Delete a Book
        [HttpDelete("{id}")]
        public ActionResult<List<Book>> DeleteBook(int id)
        {
            //if database is empty just return BadRequest
            if (_db.Books == null || id <= 0)
            {
                return BadRequest("Invalid Book id");
            }
            var book = _db.Books.Single(b => b.Id == id);
            _db.Books.Remove(book);
            _db.SaveChanges();
            return Ok(book);

        }
    }
}
