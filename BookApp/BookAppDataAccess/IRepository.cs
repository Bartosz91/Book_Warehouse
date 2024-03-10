using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<List<T>> GetAll();
        Task<T> GetByID(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
