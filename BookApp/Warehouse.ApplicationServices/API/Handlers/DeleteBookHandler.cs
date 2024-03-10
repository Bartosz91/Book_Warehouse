using AutoMapper;
using MediatR;
using Warehouse.ApplicationServices.API.Domain.BookElements;
using Warehouse.DataAccess.CQRS;
using Warehouse.DataAccess.CQRS.Commands;
using Warehouse.DataAccess.Entities;

namespace Warehouse.ApplicationServices.API.Handlers
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookRequest, DeleteBookResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteBookHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<DeleteBookResponse> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
        {
            var book = mapper.Map<Book>(request);
            var command = new DeleteBookCommand() { Parameter = book };
            var communicate = await commandExecutor.Execute(command);
            return new DeleteBookResponse()
            {
                Data = communicate
            };
        }
    }
}
