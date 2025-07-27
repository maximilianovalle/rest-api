using proj1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace proj1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BookController : ControllerBase
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
        }
    }
}