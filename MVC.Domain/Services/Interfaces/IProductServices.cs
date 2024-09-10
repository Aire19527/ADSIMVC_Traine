using MVC.Data.DTO.Invoice;
using MVC.Data.DTO.Product;

namespace MVC.Domain.Services.Interfaces
{
    public interface IProductServices
    {
        List<ConsultProductDto> GetAllProductAutoComplete(string code);
        Task<List<ConsultProductDto>> GetAllProduct();

        Task<bool> AddProduct(AddProductDto add);

        Task<bool> UpdateProduct(ProductDto update);

        Task<bool> DeleteProduct(int idProduct);

        Task UpdateStockProduct(List<AddInvoiceDetailDto> Details);
    }
}
