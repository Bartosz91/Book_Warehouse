using AutoMapper;
using MediatR;
using Warehouse.ApplicationServices.API.Domain.BookCaseElements;
using Warehouse.DataAccess.CQRS;
using Warehouse.DataAccess.CQRS.Commands;
using Warehouse.DataAccess.Entities;

namespace Warehouse.ApplicationServices.API.Handlers
{
    public class AddBookCaseHandler : IRequestHandler<AddBookCaseRequest, AddBookCaseResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddBookCaseHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddBookCaseResponse> Handle(AddBookCaseRequest request, CancellationToken cancellationToken)
        {
            var bookCase = mapper.Map<BookCase>(request);
            var command = new AddBookCaseCommand() { Parameter = bookCase };
            var bookCaseFromDb = await commandExecutor.Execute(command);
            return new AddBookCaseResponse
            {
                Data = mapper.Map<Domain.Models.BookCase>(bookCaseFromDb)
            };
        }
    }
}
