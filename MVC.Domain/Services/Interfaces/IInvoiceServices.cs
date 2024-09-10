using MVC.Data.DTO.Invoice;

namespace MVC.Domain.Services.Interfaces
{

    

    


    #region Viewws
    public interface IInvoiceServices
    {
        Task<bool> AddInvoice(AddInvoiceDto invoice);
    } 
    #endregion
}
