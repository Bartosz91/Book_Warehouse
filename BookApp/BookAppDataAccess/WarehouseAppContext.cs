using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess
{
    public class WarehouseAppContext : DbContext
    {
        public WarehouseAppContext(DbContextOptions<WarehouseAppContext> options) : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookCase> BookCases { get; set; }
        public DbSet<Author> Authors { get; set; }

    }
}
