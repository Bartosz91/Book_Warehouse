namespace Warehouse.ApplicationServices.API.Domain.Models
{
    public class BookCase
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
