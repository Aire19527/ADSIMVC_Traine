using Microsoft.AspNetCore.Mvc;
using MVC.Data.DTO.Invoice;
using MVC.Domain.Services.Interfaces;

namespace AppMVC.Controllers
{
    public class InvoiceTypeController : ControllerBase
    {
        #region Attributes
        private readonly IInvoiceTypeServices _invoiceTypeServices;
        #endregion

        #region Builder
        public InvoiceTypeController(IInvoiceTypeServices invoiceTypeServices)
        {
            _invoiceTypeServices = invoiceTypeServices;
        }
        #endregion

        #region Services

        [HttpGet("GetAllInvoiceType")]
        public async Task<IActionResult> GetAllInvoiceType()
        {
            List<InvoiceTypeDto> invoiceTypes = await _invoiceTypeServices.GetAllInvoiceType();

            return Ok(invoiceTypes);
        }

        #endregion
    }
}
