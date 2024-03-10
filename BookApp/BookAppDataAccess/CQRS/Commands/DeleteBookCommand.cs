using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Commands
{
    public class DeleteBookCommand : CommandBase<Book, string>
    {
        public async override Task<string> Execute(WarehouseAppContext context)
        {
            var book = await context.Books.SingleOrDefaultAsync(x => x.Id == Parameter.Id);
            if (book == null)
            {
                throw new Exception("Object not found");
            }
            else
            {
                context.Remove(book);
                context.SaveChanges();
                return $"Bookcase sucesfully deleted from database";
            }
        }
    }
}
