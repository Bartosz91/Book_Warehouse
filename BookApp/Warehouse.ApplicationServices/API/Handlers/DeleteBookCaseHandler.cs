using AutoMapper;
using MediatR;
using Warehouse.ApplicationServices.API.Domain.BookCaseElements;
using Warehouse.DataAccess.CQRS;
using Warehouse.DataAccess.CQRS.Commands;
using Warehouse.DataAccess.Entities;

namespace Warehouse.ApplicationServices.API.Handlers
{
    public class DeleteBookCaseHandler : IRequestHandler<DeleteBookCaseRequest, DeleteBookCaseResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteBookCaseHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<DeleteBookCaseResponse> Handle(DeleteBookCaseRequest request, CancellationToken cancellationToken)
        {
            var bookCase = mapper.Map<BookCase>(request);
            var command = new DeleteBookCaseCommand() { Parameter = bookCase};
            var communicate = await commandExecutor.Execute(command);
            var response = new DeleteBookCaseResponse()
            {
                Data = communicate
            };
            return response;
        }
    }
}
