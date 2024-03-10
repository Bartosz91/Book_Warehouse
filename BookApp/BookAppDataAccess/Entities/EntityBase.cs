using System.ComponentModel.DataAnnotations;

namespace Warehouse.DataAccess.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
