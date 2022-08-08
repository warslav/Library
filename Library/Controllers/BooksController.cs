using Library.Domain.DTO.Book;
using Library.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    [Route("api")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/<BooksController>
        [HttpGet]
        [Route("books")]
        public async Task<IActionResult> GetBooksAsync(string? order)
        {
            return Ok(await _bookService.GetBooksAsync(order ??= "id"));
        }

        // GET: api/<BooksController>
        [HttpGet]
        [Route("recommended")]
        public async Task<IActionResult> GetRecommendedAsync(string? genre)
        {
            return Ok(await _bookService.GetTop10BooksAsync(genre));
        }

        // GET api/<BooksController>/5
        [HttpGet("books/{id}")]
        public async Task<IActionResult> GetBookAsync(int id)
        {
            var entity = await _bookService.GetBookAsync(id);
            if (entity != null)
            {
                return Ok(entity);
            }
            return NotFound();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("books/{id}")]
        public async Task<IActionResult> DeleteAsync(int id, string secret)
        {
            if (await _bookService.DeleteBookAsync(id, secret))
            {
                return NoContent();
            }
            return BadRequest();
        }

        // POST api/<BooksController>
        [HttpPost]
        [Route("books/save")]
        public async Task<IActionResult> PostAsync([FromBody] SaveBookDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = await _bookService.SaveBookAsync(model);
            return Ok(id);
        }

    }
}
