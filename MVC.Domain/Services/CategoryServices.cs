using MVC.Data.DTO.Category;
using MVC.Data.Entity;
using MVC.Data.Repository.Interfaces;
using MVC.Domain.Services.Interfaces;

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

        public async Task<List<CategoryDto>> GetAll()
        {
            List<CategoryEntity> categories = await _categoryRepository.GetAll();

            //List<CategoryDto> list = new List<CategoryDto>();
            //foreach (var item in categories)
            //{
            //    CategoryDto dto = new CategoryDto()
            //    {
            //        Category=item.Category,
            //        IdCategory=item.IdCategory
            //    };

            //    list.Add(dto);
            //}

            List<CategoryDto> list = categories.Select(x => new CategoryDto()
            {
                Category = x.Category,
                IdCategory = x.IdCategory
            }).ToList();


            return list;
        }

        public async Task<bool> AddCategory(AddCategoryDto add)
        {
            CategoryEntity entity = new CategoryEntity()
            {
                Category = add.Category
            };

            return await _categoryRepository.Add(entity) > 0;
        }

        public async Task<bool> UpdateCategory(CategoryDto update)
        {
            CategoryEntity entity = await GetCategoryEntity(update.IdCategory);
            entity.Category = update.Category;

            return await _categoryRepository.Update(entity) > 0;
        }

        public async Task<bool> DeleteCategory(int idCategory)
        {
            CategoryEntity entity = await GetCategoryEntity(idCategory);

            return await _categoryRepository.Remove(entity) > 0;
        }

        //TODO: validar si el resultado es null
        private async Task<CategoryEntity> GetCategoryEntity(int idCategory)
        {
            CategoryEntity entity = await _categoryRepository.FirstOrDefault(x => x.IdCategory == idCategory);

            return entity;
        }

        #endregion
    }
}
