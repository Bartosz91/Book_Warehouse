using MediatR;

namespace Warehouse.ApplicationServices.API.Domain.BookElements
{
    public class DeleteBookRequest : IRequest<DeleteBookResponse>
    {
        public int BookId { get; set; }
    }
}
