using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly WarehouseAppContext context;
        private DbSet<T> entities;

        public Repository(WarehouseAppContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public Task<List<T>> GetAll()
        {
            return entities.ToListAsync();
        }

        public Task<T> GetByID(int id)
        {
            return entities.SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            return context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            return context.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            var entity = entities.SingleOrDefault(e => e.Id == id);
            entities.Remove(entity);
            return context.SaveChangesAsync();
        }
    }
}
