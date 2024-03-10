using MediatR;

namespace Warehouse.ApplicationServices.API.Domain.BookElements
{
    public class GetBookByIdRequest : IRequest<GetBookByIdResponse>
    {
        public int BookId { get; set; }
    }
}
