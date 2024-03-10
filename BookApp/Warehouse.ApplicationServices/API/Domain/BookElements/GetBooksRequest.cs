using MediatR;

namespace Warehouse.ApplicationServices.API.Domain.BookElements
{
    public class GetBooksRequest : IRequest<GetBooksResponse>
    {
        public string Title { get; set; }
    }
}
