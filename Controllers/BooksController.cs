using proj1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace proj1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BooksController : ControllerBase
    {
        // "static" keeps the list the same for each API call, like passing by reference
        // w/ out "static", each HTTP call would create a new list and any modifications would be lost
        static private List<Book> books = new List<Book>
        {
            new Book {
                ID = 1,
                Title = "The Last Dragonlord",
                Author = "Joanne Bertin",
                YearPublished = 1998,
            },

            new Book {
                ID = 2,
                Title = "Miss Peregrine's Home for Peculiar Children",
                Author = "Ransom Riggs",
                YearPublished = 2011,
            },

            new Book {
                ID = 3,
                Title = "Pawn of Prophecy (The Belgariad, Book 1)",
                Author = "David Eddings",
                YearPublished = 1982,
            },

            new Book {
                ID = 4,
                Title = "Wizard's First Rule (The Legend of the Seeker of Truth)",
                Author = "Terry Goodkind",
                YearPublished = 1995,
            },
        };

        [HttpGet]
        public ActionResult<List<Book>> GetBooks()
        {
            return Ok(books);   // 200 OK + books List response
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookByID(int id)
        {
            var book = books.FirstOrDefault(x => x.ID == id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        // send a POST request to API from terminal:
        // $ curl -X POST -H "Content-Type: application/json" -d '{ "ID": 5, "Title": "Queen of Sorcery (The Belgariad, Book 2)", "Author": "David Eddings", "YearPublished": 1982 }'
        [HttpPost]
        public ActionResult<Book> AddBook(Book newBook)
        {
            if (newBook == null) return BadRequest();

            books.Add(newBook);
            return CreatedAtAction(nameof(GetBookByID), new { id = newBook.ID }, newBook);
        }

        // send a PUT request to API from terminal:
        // $ curl -X PUT http://localhost:5107/api/books/4 -H "Content-Type: application/json" -d '{ "Title": "Edited", "Author": "N/A", "YearPublished": 0 }'
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book updatedBook)
        {
            var book = books.FirstOrDefault(x => x.ID == id);
            if (book == null) return NotFound();

            book.ID = updatedBook.ID;
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.YearPublished = updatedBook.YearPublished;

            return NoContent();
        }
    }
}