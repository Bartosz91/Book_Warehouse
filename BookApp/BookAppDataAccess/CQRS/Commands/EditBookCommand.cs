using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Commands
{
    public class EditBookCommand : CommandBase<Book, Book>
    {
        public async override Task<Book> Execute(WarehouseAppContext context)
        {
            var book = await context.Books.SingleOrDefaultAsync(x => x.Id == this.Parameter.Id);
            if (book == null)
            {
                return book;
            }
            else
            {
                book.Title = "Changed by Edit";
                await context.SaveChangesAsync();
                return book;
            }
        }
    }
}
