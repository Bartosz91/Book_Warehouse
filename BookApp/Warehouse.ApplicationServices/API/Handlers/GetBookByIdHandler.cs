using AutoMapper;
using MediatR;
using Warehouse.ApplicationServices.API.Domain.BookElements;
using Warehouse.DataAccess.CQRS;
using Warehouse.DataAccess.CQRS.Queries;

namespace Warehouse.ApplicationServices.API.Handlers
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdRequest, GetBookByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetBookByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetBookByIdResponse> Handle(GetBookByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetBookQuery()
            {
                Id = request.BookId
            };
            var book = await queryExecutor.Execute(query);
            var mappedBook = mapper.Map<Domain.Models.Book>(book);

            var response = new GetBookByIdResponse()
            {
                Data = mappedBook
            };

            return response;
        }
    }
}
