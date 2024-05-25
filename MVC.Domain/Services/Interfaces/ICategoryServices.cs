using MVC.Data.DTO.Category;
using MVC.Data.Entity;

namespace MVC.Domain.Services.Interfaces
{
    public interface ICategoryServices
    {
        Task<List<CategoryDto>> GetAll();
        Task<bool> AddCategory(AddCategoryDto add);
        Task<bool> UpdateCategory(CategoryDto update);
        Task<bool> DeleteCategory(int idCategory);
    }
}
