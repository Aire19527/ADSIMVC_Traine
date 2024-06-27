namespace MVC.Data.DTO.Invoice
{
    public class AddInvoiceDto
    {
        public AddInvoiceDto()
        {
            Details = new List<AddInvoiceDetailDto>();
        }

        public int IdInvoiceType { get; set; }
        public List<AddInvoiceDetailDto> Details { get; set; }
    }
}
