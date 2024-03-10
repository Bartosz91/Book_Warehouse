
using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Queries
{
    public class GetBookQuery : QueryBase<Book>
    {
        public int Id { get; set; }
        public async override Task<Book> Execute(WarehouseAppContext context)
        {
            return await context.Books.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
