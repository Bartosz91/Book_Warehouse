using MediatR;

namespace Warehouse.ApplicationServices.API.Domain.BookCaseElements
{
    public class AddBookCaseRequest : IRequest<AddBookCaseResponse>
    {
        public int Number { get; set; }
    }
}
