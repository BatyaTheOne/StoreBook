using BookStore.Application.Services;
using BookStore.Core.Model;
using Microsoft.AspNetCore.Mvc;
using StoreBook.Api.Contracts;

namespace StoreBook.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookRespons>>> GetBooks()
        {
            var books = await _bookService.GetAllBooks();

            var respons = books.Select(b => new BookRespons(b.Id, b.Title, b.Description, b.Price));

            return Ok(respons);
        }
    }
}
