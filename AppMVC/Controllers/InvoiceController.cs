using AppMVC.Handlers;
using Microsoft.AspNetCore.Mvc;
using MVC.Domain.Services.Interfaces;

namespace AppMVC.Controllers
{
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class InvoiceController : Controller
    {
        #region Attributes
        private readonly IInvoiceServices _invoiceServices;
        #endregion

        #region Builder
        public InvoiceController(IInvoiceServices invoiceServices)
        {
            _invoiceServices = invoiceServices;
        }
        #endregion


        #region Views
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Invoice()
        {
            return View();
        }
        #endregion
    }
}
