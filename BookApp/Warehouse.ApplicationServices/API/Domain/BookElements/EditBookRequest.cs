using MediatR;

namespace Warehouse.ApplicationServices.API.Domain.BookElements
{
    public class EditBookRequest : IRequest<EditBookResponse>
    {
        public int BookId { get; set; }
    }
}
