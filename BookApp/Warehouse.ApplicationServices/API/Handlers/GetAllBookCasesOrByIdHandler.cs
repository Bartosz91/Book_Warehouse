using AutoMapper;
using MediatR;
using Warehouse.DataAccess.CQRS;
using Warehouse.DataAccess.CQRS.Queries;
using Warehouse.ApplicationServices.API.Domain.BookCaseElements;

namespace Warehouse.ApplicationServices.API.Handlers
{
    public class GetAllBookCasesOrByIdHandler : IRequestHandler<GetAllBookCasesOrByIdRequest, GetAllBookCasesOrByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAllBookCasesOrByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetAllBookCasesOrByIdResponse> Handle(GetAllBookCasesOrByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllBookCasesOrByIdQuery()
            {
                BookCaseId = request.BookCaseId
            };
            var bookCases = await queryExecutor.Execute(query);
            var mappedBookCases = mapper.Map<List<Domain.Models.BookCase>>(bookCases);

            var response = new GetAllBookCasesOrByIdResponse()
            {
                Data = mappedBookCases
            };

            return response;
        }
    }
}
