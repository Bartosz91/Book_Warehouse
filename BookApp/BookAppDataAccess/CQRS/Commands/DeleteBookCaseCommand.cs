using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Commands
{
    public class DeleteBookCaseCommand : CommandBase<BookCase, string>
    {
        public override async Task<string> Execute(WarehouseAppContext context)
        {
            var bookCase = await context.BookCases.SingleOrDefaultAsync(x => x.Id == Parameter.Id);
            if (bookCase == null)
            {
                throw new Exception("Object not found");
            }
            else
            {
                context.Remove(bookCase);
                context.SaveChanges();
                return $"Bookcase sucesfully deleted from database";
            }
        }
    }
}
