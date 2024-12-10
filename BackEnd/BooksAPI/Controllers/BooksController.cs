using BooksAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private Book[] _books = new Book[]
        {
            new Book{Id = 1, Title = "Title One", Author = "Author One"},
            new Book{Id = 2, Title = "Title Two", Author = "Author Two"},
            new Book{Id = 3, Title = "Title Three", Author = "Author Three"}
        };

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return _books;
        }
    }
}
 