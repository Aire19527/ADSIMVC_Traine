using MVC.Data.DTO.Invoice;
using MVC.Data.DTO.Product;

namespace MVC.Domain.Services.Interfaces
{
    public interface IProductServices
    {
        Task<List<ProductDto>> GetAllProduct();

        Task<bool> AddProduct(AddProductDto add);

        Task<bool> UpdateProduct(ProductDto update);

        Task<bool> DeleteProduct(int idProduct);

        Task UpdateStockProduct(List<AddInvoiceDetailDto> Details);
    }
}
