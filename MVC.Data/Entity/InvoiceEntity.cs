using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        [ForeignKey("InvoiceTypeEntity")]
        public int IdInvoiceType { get; set; }
        public InvoiceTypeEntity InvoiceTypeEntity { get; set; }



        public IEnumerable<InvoiceDetailEntity> InvoiceDetailEntities { get; set; }
    }
}
