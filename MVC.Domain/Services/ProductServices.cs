using MVC.Data.DTO.Category;
using MVC.Data.DTO.Invoice;
using MVC.Data.DTO.Product;
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
    public class ProductServices : IProductServices
    {
        #region Attributes
        private readonly IRepository<ProductEntity> _productRepository;
        #endregion

        #region Builder
        public ProductServices(IRepository<ProductEntity> productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region Methods

        public async Task<List<ProductDto>> GetAllProduct()
        {
            List<ProductEntity> products = await _productRepository.GetAll();

            List<ProductDto> productDtos = products.Select(x => new ProductDto()
            {
                Amount = x.Amount,
                IdCategory = x.IdCategory,
                IdProduct = x.IdProduct,
                Name = x.Name,
                Price = x.Price
            }).ToList();

            return productDtos;
        }


        public async Task<bool> AddProduct(AddProductDto add)
        {
            ProductEntity entity = new ProductEntity()
            {
                Name = add.Name,
                Amount = add.Amount,
                IdCategory = add.IdCategory,
                DateRegister = DateTime.Now,
                Price = add.Price,
            };

            return await _productRepository.Add(entity) > 0;
        }

        public async Task<bool> UpdateProduct(ProductDto update)
        {
            ProductEntity entity = await GetProductEntity(update.IdProduct);
            entity.DateUpdate = DateTime.Now;
            entity.Name = update.Name;
            entity.Amount = update.Amount;
            entity.IdCategory = update.IdCategory;
            entity.Price = update.Price;


            return await _productRepository.Update(entity) > 0;
        }

        public async Task<bool> DeleteProduct(int idProduct)
        {
            ProductEntity entity = await GetProductEntity(idProduct);

            return await _productRepository.Remove(entity) > 0;
        }



        public async Task UpdateStockProduct(List<AddInvoiceDetailDto> Details)
        {
            foreach (var detail in Details)
            {
                ProductEntity product = await GetProductEntity(detail.IdProduct);
                if (detail.Amount > product.Amount)
                {
                    string message = $"La cantidad de: [{product.Name}] es mayor a la que hay en Stock, disponibles: [{product.Amount}]";
                    throw new Exception(message);
                }

                if (detail.Price != product.Price)
                {
                    string message = $"El precio de: [{product.Name}] no coincide con la que hay en el sistema.";
                    throw new Exception(message);
                }

                product.Amount = (product.Amount - detail.Amount);
                product.DateUpdate = DateTime.Now;
                //pro

                await _productRepository.Update(product);
            }
        }

        private async Task<ProductEntity> GetProductEntity(int idProduct)
        {
            ProductEntity entity = await _productRepository.FirstOrDefault(x => x.IdProduct == idProduct);
            if (entity == null)
                throw new Exception("El producto no existe en base de datos");

            return entity;
        }
        #endregion
    }
}
