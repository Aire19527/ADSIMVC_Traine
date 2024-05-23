using MVC.Data.Entity;
using MVC.Data.Repository.Interfaces;
using MVC.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Services
{
    public class CategoryServices : ICategoryServices
    {
        #region Attributes
        private readonly IRepository<CategoryEntity> _categoryRepository;
        #endregion

        #region Builder
        public CategoryServices(IRepository<CategoryEntity> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        #endregion
        
        #region Methods

        public async Task<List<CategoryEntity>> GetAll()
        {
            List<CategoryEntity> categories = await _categoryRepository.GetAll();

            return categories;
        }




        #endregion
    }
}
