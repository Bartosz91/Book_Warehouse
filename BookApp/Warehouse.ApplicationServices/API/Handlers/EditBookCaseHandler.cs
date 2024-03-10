using AutoMapper;
using MediatR;
using Warehouse.ApplicationServices.API.Domain.BookCaseElements;
using Warehouse.DataAccess.CQRS;
using Warehouse.DataAccess.CQRS.Commands;
using Warehouse.DataAccess.Entities;

namespace Warehouse.ApplicationServices.API.Handlers
{
    public class EditBookCaseHandler : IRequestHandler<EditBookCaseRequest, EditBookCaseResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public EditBookCaseHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<EditBookCaseResponse> Handle(EditBookCaseRequest request, CancellationToken cancellationToken)
        {
            var bookCase = mapper.Map<BookCase>(request);
            var command = new EditBookCaseCommand() { Parameter = bookCase };
            var bookCaseFromDb = await commandExecutor.Execute(command);
            var response = new EditBookCaseResponse()
            {
                Data = mapper.Map<Domain.Models.BookCase>(bookCaseFromDb)
            };
            return response;
        }
    }
}
