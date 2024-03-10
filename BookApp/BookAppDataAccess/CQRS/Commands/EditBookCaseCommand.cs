using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Commands
{
    public class EditBookCaseCommand : CommandBase<BookCase, BookCase>
    {
        public override async Task<BookCase> Execute(WarehouseAppContext context)
        {
            var bookCase = await context.BookCases.SingleOrDefaultAsync(x => x.Id == this.Parameter.Id);
            if (bookCase == null)
            {
                return bookCase;
            }
            else
            {
                bookCase.Number = 999;
                await context.SaveChangesAsync();
                return bookCase;
            }
        }
    }
}
