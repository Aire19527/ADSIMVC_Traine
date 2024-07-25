using Microsoft.AspNetCore.Mvc;
using MVC.Data.DTO.Product;
using MVC.Domain.Services.Interfaces;

namespace AppMVC.Controllers
{
    public class ProductController : Controller
    {
        #region Attributes
        private readonly IProductServices _productServices;
        #endregion

        #region Builder
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        #endregion

        #region Views
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region Services

        [HttpGet]
        [Route("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            List<ConsultProductDto> categories = await _productServices.GetAllProduct();

            return Ok(categories);
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(AddProductDto add)
        {
            bool result = await _productServices.AddProduct(add);

            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(ProductDto update)
        {
            bool result = await _productServices.UpdateProduct(update);

            return Ok(result);
        }


        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int idProduct)
        {
            bool result = await _productServices.DeleteProduct(idProduct);

            return Ok(result);
        }
        #endregion
    }
}
