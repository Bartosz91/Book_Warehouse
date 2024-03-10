using Warehouse.DataAccess.CQRS.Queries;

namespace Warehouse.DataAccess.CQRS
{
    public class QueryExecutor : IQueryExecutor
    {
        public WarehouseAppContext context;

        public QueryExecutor(WarehouseAppContext context)
        {
            this.context = context;
        }


        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(context);
        }
    }
}
