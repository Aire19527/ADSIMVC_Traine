using Microsoft.AspNetCore.Mvc;
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
            List<CategoryEntity> categories = await _categoryServices.GetAll();

            return Ok(categories);
        }


        #endregion
    }
}
