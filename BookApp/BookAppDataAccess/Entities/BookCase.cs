namespace Warehouse.DataAccess.Entities
{
    public class BookCase : EntityBase
    {
        public int Number { get; set; }
        public List<Book> Books { get; set; }
    }
}
