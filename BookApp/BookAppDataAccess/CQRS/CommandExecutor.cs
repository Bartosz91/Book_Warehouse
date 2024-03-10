
using Warehouse.DataAccess.CQRS.Commands;

namespace Warehouse.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly WarehouseAppContext context;

        public CommandExecutor(WarehouseAppContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TParameter, TResult>(CommandBase<TParameter, TResult> command)
        {
            return command.Execute(this.context);
        }
    }
}
