using MVC.Data.DTO.Invoice;

namespace MVC.Domain.Services.Interfaces
{
    public interface IInvoiceTypeServices
    {
        Task<List<InvoiceTypeDto>> GetAllInvoiceType();
    }
}
