using MVC.Data.DTO.Invoice;
using MVC.Data.Entity;
using MVC.Data.Repository.Interfaces;
using MVC.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Services
{
    public class InvoiceServices : IInvoiceServices
    {
        #region Attributes
        private readonly IRepository<InvoiceEntity> _invoiceRepository;
        private readonly IProductServices _productServices;
        #endregion

        #region Builder
        public InvoiceServices(IRepository<InvoiceEntity> invoiceRepository, IProductServices productServices)
        {
            _invoiceRepository = invoiceRepository;
            _productServices = productServices;
        }
        #endregion


        #region Methods

        public async Task<bool> AddInvoice(AddInvoiceDto invoice)
        {
            bool result = false;

            if (!invoice.Details.Any())
                throw new Exception("Los productos son obligatorios para crear una factura");


            var details = invoice.Details.Select(x => new InvoiceDetailEntity()
            {
                IdProduct = x.IdProduct,
                Amount = x.Amount,
                Price = x.Price,
                SubTotal = (x.Amount * x.Price)
            }).ToList();

            InvoiceEntity invoiceEntity = new InvoiceEntity()
            {
                DateRegister = DateTime.Now,
                IdInvoiceType = invoice.IdInvoiceType,
                InvoiceDetailEntities = details,
                Total = details.Sum(x => x.SubTotal)
            };



            using (var transaction = await _invoiceRepository.BeginTransactionAsync())
            {
                try
                {
                    result = await _invoiceRepository.Add(invoiceEntity) > 1;
                    if (result)
                        await _productServices.UpdateStockProduct(invoice.Details);

                    if (!result)
                        await transaction.RollbackAsync();
                    else
                        await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }


            return result;
        }
        #endregion
    }
}
