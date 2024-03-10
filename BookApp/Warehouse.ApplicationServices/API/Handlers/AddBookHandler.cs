using AutoMapper;
using MediatR;
using Warehouse.ApplicationServices.API.Domain.BookElements;
using Warehouse.DataAccess.CQRS;
using Warehouse.DataAccess.CQRS.Commands;

namespace Warehouse.ApplicationServices.API.Handlers
{
    public class AddBookHandler : IRequestHandler<AddBookRequest, AddBookResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddBookHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddBookResponse> Handle(AddBookRequest request, CancellationToken cancellationToken)
        {
            var book = mapper.Map<Warehouse.DataAccess.Entities.Book>(request);
            var command = new AddBookCommand() {Parameter = book};
            var bookFromDataBase = await commandExecutor.Execute(command);
            return new AddBookResponse()
            {
                Data = mapper.Map<API.Domain.Models.Book>(bookFromDataBase)
            };
        }
    }
}
