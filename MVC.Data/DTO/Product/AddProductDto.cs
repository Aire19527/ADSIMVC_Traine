using System.ComponentModel.DataAnnotations;

namespace MVC.Data.DTO.Product
{
    public class AddProductDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public int IdCategory { get; set; }

        public decimal Price { get; set; }
    }
}
