using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _authorsService;

        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM Author)
        {
            _authorsService.AddAuthor(Author);
            return Ok();
        }

        [HttpGet("get-book-with-author-by-id/{id}")]
        public IActionResult GetBookWithAuthor(int id)
        {
            var response = _authorsService.GetAuthorWithBooksVM(id);
            return Ok(response);
        }
    }
}