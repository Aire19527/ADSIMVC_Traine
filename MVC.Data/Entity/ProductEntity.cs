using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Data.Entity
{
    [Table("Product")]
    public class ProductEntity
    {
        [Key]
        public int IdProduct { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Amount { get; set; }

        public decimal Price { get; set; }

        [Required]
        public DateTime DateRegister { get; set; }
        public DateTime? DateUpdate { get; set; }


        [ForeignKey("CategoryEntity")]
        public int IdCategory { get; set; }
        public CategoryEntity CategoryEntity { get; set; }

    }
}
