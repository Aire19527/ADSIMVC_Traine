using System.ComponentModel.DataAnnotations;

namespace MVC.Data.DTO.Category
{
    public class AddCategoryDto
    {
        [MaxLength(100)]
        public string Category { get; set; }
    }
}
