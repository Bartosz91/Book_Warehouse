using System.ComponentModel.DataAnnotations;

namespace Warehouse.DataAccess.Entities
{
    public class Author : EntityBase
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
