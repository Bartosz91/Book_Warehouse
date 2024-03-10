using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Queries
{
    public class GetAllBookCasesOrByIdQuery : QueryBase<List<BookCase>>
    {
        public int BookCaseId { get; set; }

        public override Task<List<BookCase>> Execute(WarehouseAppContext context)
        {
            if (this.BookCaseId == 0)
            {
                return context.BookCases.ToListAsync();
            }
            return context.BookCases.Where(x => x.Id == BookCaseId).ToListAsync();
        }
    }
}
