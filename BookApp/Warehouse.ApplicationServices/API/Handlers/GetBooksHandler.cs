using AutoMapper;
using MediatR;
using Warehouse.ApplicationServices.API.Domain.BookElements;
using Warehouse.DataAccess.CQRS;
using Warehouse.DataAccess.CQRS.Queries;

namespace Warehouse.ApplicationServices.API.Handlers
{
    public class GetBooksHandler : IRequestHandler<GetBooksRequest, GetBooksResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetBooksHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetBooksResponse> Handle(GetBooksRequest request, CancellationToken cancellationToken)
        {
            var query = new GetBooksQuery()
            {
                Title = request.Title
            };
            var books = await queryExecutor.Execute(query);
            var mappedBooks = mapper.Map<List<Domain.Models.Book>>(books);

            var response = new GetBooksResponse()
            {
                Data = mappedBooks
            };

            return response;
        }
    }
}
