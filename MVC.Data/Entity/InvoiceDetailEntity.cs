using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Data.Entity
{
    [Table("InvoiceDetail")]
    public class InvoiceDetailEntity
    {
        [Key]
        public int IdInvoiceDetail { get; set; }

        [ForeignKey("InvoiceEntity")]
        public int IdInvoice { get; set; }
        public InvoiceEntity InvoiceEntity { get; set; }

        [ForeignKey("ProductEntity")]
        public int IdProduct { get; set; }
        public ProductEntity ProductEntity { get; set; }

        public decimal Price { get; set; }
        public int Amount { get; set; }
        public decimal SubTotal { get; set; }

    }
}
