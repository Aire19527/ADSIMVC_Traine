using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Data.Entity
{
    [Table("Invoice")]
    public class InvoiceEntity
    {
        [Key]
        public int IdInvoice { get; set; }

        public DateTime DateRegister { get; set; }
        public decimal Total { get; set; }

        public IEnumerable<InvoiceDetailEntity> InvoiceDetailEntities { get; set; }
    }
}
