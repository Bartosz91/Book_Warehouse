using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehouse.ApplicationServices.API.Domain;
using Warehouse.ApplicationServices.API.Domain.BookCaseElements;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookCaseController : ControllerBase
    {
        private readonly IMediator mediator;

        public BookCaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllBookCasesOrById([FromQuery] int bookCaseId)
        {
            var request = new GetAllBookCasesOrByIdRequest()
            {
                BookCaseId = bookCaseId
            };
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddBookCase([FromBody] AddBookCaseRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("{bookCaseId}")]
        public async Task<IActionResult> EditBookCase([FromRoute] int bookCaseId)
        {
            var request = new EditBookCaseRequest()
            {
                BookCaseId = bookCaseId
            };
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{bookCaseId}")]
        public async Task<IActionResult> DeleteBookCase([FromRoute] int bookCaseId)
        {
            var request = new DeleteBookCaseRequest()
            {
                BookCaseId = bookCaseId
            };
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
