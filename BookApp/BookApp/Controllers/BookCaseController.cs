using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehouse.ApplicationServices.API.Domain;
using Warehouse.ApplicationServices.API.Domain.BookCaseElements;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookCaseController : ApiControllerBase
    {
        public BookCaseController(IMediator mediator) : base(mediator) 
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllBookCasesOrById([FromQuery] int bookCaseId)
        {
            var request = new GetAllBookCasesOrByIdRequest()
            {
                BookCaseId = bookCaseId
            };
            return HandleRequest<GetAllBookCasesOrByIdRequest, GetAllBookCasesOrByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddBookCase([FromBody] AddBookCaseRequest request)
        {
            return HandleRequest<AddBookCaseRequest, AddBookCaseResponse>(request);
        }

        [HttpPut]
        [Route("{bookCaseId}")]
        public Task<IActionResult> EditBookCase([FromRoute] int bookCaseId)
        {
            var request = new EditBookCaseRequest()
            {
                BookCaseId = bookCaseId
            };
            return HandleRequest<EditBookCaseRequest, EditBookCaseResponse>(request);
        }

        [HttpDelete]
        [Route("{bookCaseId}")]
        public Task<IActionResult> DeleteBookCase([FromRoute] int bookCaseId)
        {
            var request = new DeleteBookCaseRequest()
            {
                BookCaseId = bookCaseId
            };
            return HandleRequest<DeleteBookCaseRequest, DeleteBookCaseResponse>(request);
        }
    }
}
