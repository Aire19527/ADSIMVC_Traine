using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Data.Entity
{
    [Table("ImageProduct")]
    public class ImageProductEntity
    {
        [Key]
        public int IdImageProduct { get; set; }

        [ForeignKey("ProductEntity")]
        public int IdProduct { get; set; }
        public ProductEntity ProductEntity { get; set; }

        public string UrlImage { get; set; }
    }
}
