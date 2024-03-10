using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Commands
{
    public class AddBookCommand : CommandBase<Book, Book>
    {
        public override async Task<Book> Execute(WarehouseAppContext context)
        {
            await context.Books.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
