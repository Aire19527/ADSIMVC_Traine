﻿using AppMVC.Handlers;
using Microsoft.AspNetCore.Mvc;
using MVC.Data.DTO.Product;
using MVC.Domain.Services.Interfaces;

namespace AppMVC.Controllers
{
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class ProductController : Controller
    {
        #region Attributes
        private readonly IProductServices _productServices;
        private readonly IImagesProductServices _imagesProductServices;
        #endregion

        #region Builder
        public ProductController(IProductServices productServices, IImagesProductServices imagesProductServices )
        {
            _productServices = productServices;
            _imagesProductServices = imagesProductServices;
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

        [HttpGet]
        [Route("GetAllProductAutoComplete")]
        public IActionResult GetAllProductAutoComplete(string code)
        {
            List<ConsultProductDto> categories =  _productServices.GetAllProductAutoComplete(code);

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


        [HttpPost]
        [Route("AddImages")]
        public async Task<IActionResult> AddImages(AddImagesDto add)
        {
            bool result = await _imagesProductServices.AddImages(add);

            return Ok(result);
        }


        [HttpGet]
        [Route("GetImagesByProduct")]
        public async Task<IActionResult> GetImagesByProduct(int idProduct)
        {
            List<ImageDto> result = await _imagesProductServices.GetImagesByProduct(idProduct);

            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteImageProduct")]
        public async Task<IActionResult> DeleteImageProduct(int idImageProduct)
        {
            bool result = await _imagesProductServices.DeleteImageProduct(idImageProduct);

            return Ok(result);
        }

        #endregion
    }
}
