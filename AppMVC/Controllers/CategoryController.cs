using Microsoft.AspNetCore.Mvc;
using MVC.Data.DTO.Category;
using MVC.Data.Entity;
using MVC.Domain.Services.Interfaces;

namespace AppMVC.Controllers
{
    public class CategoryController : Controller
    {
        #region Attributes
        private readonly ICategoryServices _categoryServices;
        #endregion

        #region Builder
        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
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
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            List<CategoryDto> categories = await _categoryServices.GetAll();

            return Ok(categories);
        }

        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddCategory(AddCategoryDto add)
        {
            bool result = await _categoryServices.AddCategory(add);

            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(CategoryDto update)
        {
            bool result = await _categoryServices.UpdateCategory(update);

            return Ok(result);
        }


        [HttpDelete]
        [Route("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int idCategory)
        {
            bool result = await _categoryServices.DeleteCategory(idCategory);

            return Ok(result);
        }
        #endregion
    }
}
