using MVC.Data.DTO.Product;

namespace MVC.Domain.Services.Interfaces
{
    public interface IImagesProductServices
    {
        Task<bool> AddImages(AddImagesDto imagesDto);

        void DeleteFilePath(string filePath);

        Task<List<ImageDto>> GetImagesByProduct(int idProduct);
    }
}
