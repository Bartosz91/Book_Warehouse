using MediatR;

namespace Warehouse.ApplicationServices.API.Domain.BookCaseElements
{
    public class DeleteBookCaseRequest : IRequest<DeleteBookCaseResponse>
    {
        public int BookCaseId { get; set; }
    }
}
