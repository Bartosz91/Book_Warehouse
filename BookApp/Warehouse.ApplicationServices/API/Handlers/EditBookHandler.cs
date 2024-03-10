using AutoMapper;
using MediatR;
using Warehouse.ApplicationServices.API.Domain.BookElements;
using Warehouse.DataAccess.CQRS;
using Warehouse.DataAccess.CQRS.Commands;
using Warehouse.DataAccess.Entities;

namespace Warehouse.ApplicationServices.API.Handlers
{
    public class EditBookHandler : IRequestHandler<EditBookRequest, EditBookResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public EditBookHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<EditBookResponse> Handle(EditBookRequest request, CancellationToken cancellationToken)
        {
            var book = mapper.Map<Book>(request);
            var command = new EditBookCommand() { Parameter = book};
            var bookFromDatabase =  await commandExecutor.Execute(command);
            return new EditBookResponse()
            {
                Data = mapper.Map<Domain.Models.Book>(bookFromDatabase)
            };
        }
    }
}
