using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Warehouse.DataAccess
{
    public class WarehouseContextFactory : IDesignTimeDbContextFactory<WarehouseAppContext>
    {
        public WarehouseAppContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<WarehouseAppContext>();
            //PC
            optionBuilder.UseSqlServer("Data Source=DESKTOP-CBK7MCF\\SQLEXPRESS;Initial Catalog=WarehouseStorage;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            //Laptop
            //optionBuilder.UseSqlServer("Data Source=DESKTOP-N79UBH8\\SQLEXPRESS;Initial Catalog=WarehouseStorage;Integrated Security=True;Trust Server Certificate=True");
            return new WarehouseAppContext(optionBuilder.Options);
        }
    }
}
