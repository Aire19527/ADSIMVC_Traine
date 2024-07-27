using Microsoft.Extensions.Configuration;
using MVC.Common.Enums;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MVC.Domain.Services
{
    public class ProductServices : IProductServices
    {
        #region Attributes
        private readonly IRepository<ProductEntity> _productRepository;
        private readonly IConfiguration _configuration;
        private readonly IImagesProductServices _imagesProductServices;
        #endregion

        #region Builder
        public ProductServices(IRepository<ProductEntity> productRepository, IConfiguration configuration, IImagesProductServices imagesProductServices)
        {
            _productRepository = productRepository;
            _configuration = configuration;
            _imagesProductServices = imagesProductServices;
        }
        #endregion

        #region Methods

        public async Task<List<ConsultProductDto>> GetAllProduct()
        {
            List<ProductEntity> products = await _productRepository.GetAll(x => x.StateEntity,
                                                                           c => c.CategoryEntity,
                                                                           i => i.ImageProductEntities);
            List<ConsultProductDto> productDtos = products.Select(x => new ConsultProductDto()
            {
                Amount = x.Amount,
                IdCategory = x.IdCategory,
                IdProduct = x.IdProduct,
                Name = x.Name,
                Price = x.Price,
                State = x.StateEntity.State,
                Category = x.CategoryEntity.Category,
                UrlImages = x.ImageProductEntities.Select(x => x.UrlImage).ToList(),
            }).ToList();

            return productDtos;
        }


        public async Task<bool> AddProduct(AddProductDto add)
        {
            int stockLimit = Convert.ToInt32(_configuration["ConfigProduct:StockLimit"]);
            int idState = (int)Enums.State.ProductoDisponible;

            if (add.Amount == 0)
                throw new Exception("El stock mínimo es de 1 producto.");
            else if (add.Amount >= 1 && add.Amount <= stockLimit)
                idState = (int)Enums.State.ProductoLimitado;

            ProductEntity entity = new ProductEntity()
            {
                Name = add.Name,
                Amount = add.Amount,
                IdCategory = add.IdCategory,
                DateRegister = DateTime.Now,
                Price = add.Price,
                IdState = idState
            };

            bool result = false;
            using (var transaction = await _productRepository.BeginTransactionAsync())
            {
                try
                {
                    result = await _productRepository.Add(entity) > 0;

                    if (result && add.Images != null)
                    {
                        result = await _imagesProductServices.AddImages(new AddImagesDto()
                        {
                            IdProduct = entity.IdProduct,
                            Images = add.Images,
                        });
                    }

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

        public async Task<bool> UpdateProduct(ProductDto update)
        {
            ProductEntity entity = await GetProductEntity(update.IdProduct);
            entity.DateUpdate = DateTime.Now;
            entity.Name = update.Name;
            entity.Amount = update.Amount;
            entity.IdCategory = update.IdCategory;
            entity.Price = update.Price;
            entity.IdState = GetStateProduct(update.Amount);

            bool result = await _productRepository.Update(entity) > 0;

            return result;
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
                product.IdState = GetStateProduct(product.Amount);

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

        private int GetStateProduct(int stock)
        {
            int idState = 0;
            int stockLimit = Convert.ToInt32(_configuration["ConfigProduct:StockLimit"]);
            int stockMinimum = Convert.ToInt32(_configuration["ConfigProduct:StockMinimum"]);

            if (stock >= stockLimit)
                idState = (int)Enums.State.ProductoDisponible;
            else if (stock >= stockMinimum)
                idState = (int)Enums.State.ProductoLimitado;
            else
                idState = (int)Enums.State.ProductoAgotado;

            return idState;
        }
        #endregion
    }
}
