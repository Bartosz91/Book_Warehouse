using MediatR;

namespace Warehouse.ApplicationServices.API.Domain.BookCaseElements
{
    public class EditBookCaseRequest : IRequest<EditBookCaseResponse>
    {
        public int BookCaseId { get; set; }
    }
}
