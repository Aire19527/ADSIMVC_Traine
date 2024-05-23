using MVC.Data.Entity;

namespace MVC.Domain.Services.Interfaces
{
    public interface ICategoryServices
    {
        Task<List<CategoryEntity>> GetAll();
    }
}
