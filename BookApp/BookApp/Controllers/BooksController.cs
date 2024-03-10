using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehouse.ApplicationServices.API.Domain.BookElements;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator mediator;

        public BooksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllBooks([FromQuery] string title = "")
        {
            GetBooksRequest request = new GetBooksRequest()
            {
                Title = title

            };
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("{bookId}")]
        public async Task<IActionResult> GetAllBooks([FromRoute] int bookId)
        {
            var request = new GetBookByIdRequest()
            {
                BookId = bookId
            };
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddBook([FromQuery] /*string title, int year*/ AddBookRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("{bookId}")]
        public async Task<IActionResult> EditBook(int bookId)
        {
            var request = new EditBookRequest()
            {
                BookId = bookId
            };
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{bookId}")]
        public async Task<IActionResult> DeleteBook( int bookId)
        {
            var request = new DeleteBookRequest()
            {
                BookId = bookId
            };
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
