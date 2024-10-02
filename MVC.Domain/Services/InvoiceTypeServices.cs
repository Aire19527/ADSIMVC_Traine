using MVC.Data.DTO.Invoice;
using MVC.Data.Entity;
using MVC.Data.Repository.Interfaces;
using MVC.Domain.Services.Interfaces;

namespace MVC.Domain.Services
{
    public class InvoiceTypeServices : IInvoiceTypeServices
    {
        #region Attributes
        private readonly IRepository<InvoiceTypeEntity> _invoiceTypeRepository;
        #endregion

        #region Builder
        public InvoiceTypeServices(IRepository<InvoiceTypeEntity> invoiceTypeRepository)
        {
            _invoiceTypeRepository = invoiceTypeRepository;
        }
        #endregion

        #region Methods
        public async Task<List<InvoiceTypeDto>> GetAllInvoiceType()
        {
            List<InvoiceTypeEntity> invoiceTypes = await _invoiceTypeRepository.GetAll();
            List<InvoiceTypeDto> result = invoiceTypes.Select(x => new InvoiceTypeDto()
            {
                IdInvoiceType = x.IdInvoiceType,
                InvoiceType = x.InvoiceType,
            }).ToList();

            return result;
        }
        #endregion
    }
}
