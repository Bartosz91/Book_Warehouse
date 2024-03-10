using MediatR;

namespace Warehouse.ApplicationServices.API.Domain.BookCaseElements
{
    public class GetAllBookCasesOrByIdRequest : IRequest<GetAllBookCasesOrByIdResponse>
    {
        public int BookCaseId { get; set; }
    }
}
