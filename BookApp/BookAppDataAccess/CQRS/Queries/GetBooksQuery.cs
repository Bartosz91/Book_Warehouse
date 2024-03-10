
using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Queries
{
    public class GetBooksQuery : QueryBase<List<Book>>
    {
        public string Title { get; set; }

        public override Task<List<Book>> Execute(WarehouseAppContext context)
        {
            if (string.IsNullOrWhiteSpace(this.Title))
            {
                return context.Books.ToListAsync();
            }
            return context.Books.Where(x => x.Title == Title).ToListAsync();
        }
    }
}
