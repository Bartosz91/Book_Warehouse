
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Commands
{
    public class AddBookCaseCommand : CommandBase<BookCase, BookCase>
    {
        public override async Task<BookCase> Execute(WarehouseAppContext context)
        {
            await context.BookCases.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
