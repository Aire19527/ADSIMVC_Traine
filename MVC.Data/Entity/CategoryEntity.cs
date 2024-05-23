using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Data.Entity
{
    [Table("Category")]
    public class CategoryEntity
    {
        public CategoryEntity()
        {
            ProductEntities = new HashSet<ProductEntity>();
        }

        [Key]
        public int IdCategory { get; set; }

        [MaxLength(100)]
        public string Category { get; set; }

        public IEnumerable<ProductEntity> ProductEntities { get; set; }
    }
}
