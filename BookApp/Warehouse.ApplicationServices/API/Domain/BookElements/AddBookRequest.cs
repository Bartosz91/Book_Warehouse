using MediatR;

namespace Warehouse.ApplicationServices.API.Domain.BookElements
{
    public class AddBookRequest : IRequest<AddBookResponse>
    {
        public string Title { get; set; }
        public int Year { get; set; }
    }
}
