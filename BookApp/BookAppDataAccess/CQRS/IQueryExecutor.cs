using Warehouse.DataAccess.CQRS.Queries;

namespace Warehouse.DataAccess.CQRS
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
