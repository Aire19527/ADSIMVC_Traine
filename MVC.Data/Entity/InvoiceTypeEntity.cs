using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Data.Entity
{
    [Table("InvoiceType")]
    public class InvoiceTypeEntity
    {
        public InvoiceTypeEntity()
        {
            InvoiceEntities = new HashSet<InvoiceEntity>();
        }

        [Key]
        public int IdInvoiceType { get; set; }


        [Required]
        [MaxLength(100)]
        public string InvoiceType { get; set; }

        public IEnumerable<InvoiceEntity> InvoiceEntities { get; set; }
    }
}
