using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.Entities
{
    public class Book : EntityBase
    {
        [ForeignKey("BookCase")]
        public int? BookCaseId { get; set; }
        public BookCase BookCase { get; set; }
        public List<Author> Authors { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        public int Year { get; set; }
    }
}
