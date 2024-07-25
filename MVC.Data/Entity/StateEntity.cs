using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Data.Entity
{
    [Table("State")]
    public class StateEntity
    {
        public StateEntity()
        {
            ProductEntities = new HashSet<ProductEntity>();
        }

        [Key]
        public int IdState { get; set; }

        [Required]
        [MaxLength(200)]
        public string State { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; } = null;

        [Required]
        [MaxLength(100)]
        public string Ambit { get; set; }

        public IEnumerable<ProductEntity> ProductEntities { get; set; }
    }
}
