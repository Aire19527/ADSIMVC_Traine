using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MVC.Data.DTO.Product;
using MVC.Data.Entity;
using MVC.Data.Repository.Interfaces;
using MVC.Domain.Services.Interfaces;

namespace MVC.Domain.Services
{
    public class ImagesProductServices : IImagesProductServices
    {
        #region Attributes
        private readonly IRepository<ImageProductEntity> _imagesProductRepository;
        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _environment;
        #endregion

        #region Builder
        public ImagesProductServices(IRepository<ImageProductEntity> imagesProductRepository,
                                     IConfiguration configuration,
                                     IHostEnvironment environment)
        {
            _imagesProductRepository = imagesProductRepository;
            _configuration = configuration;
            _environment = environment;
        }
        #endregion

        #region Methods

        public async Task<bool> AddImages(AddImagesDto imagesDto)
        {
            if (!imagesDto.Images.Any())
                throw new Exception("Imagene obligatorías");

            var configFile = _configuration.GetSection("PathFiles");
            int size = Convert.ToInt32(configFile["SizeFile"]);
            long maxBytes = size * 1024 * 1024;
            List<string> urls = new List<string>();
            foreach (var image in imagesDto.Images)
            {
                if (image.Length > maxBytes)
                    throw new Exception($"El archivo  {image.FileName} es mayor a : [{size} MB]");

                string extension = Path.GetExtension(image.FileName);
                if (!ValidExtension(extension))
                {
                    string allowedExtensions = _configuration["PathFiles:AllowedExtensions"];
                    throw new Exception($"El archivo  {image.FileName} no es permitido, los permitidos son: [{allowedExtensions}]");
                }

                string url = configFile["PathImages"];
                string upload = Path.Combine(_environment.ContentRootPath, url);
                if (!Directory.Exists(upload))
                    Directory.CreateDirectory(upload);

                string uniqueFileName = GetUniqueFileName(image.FileName);
                string pathFinal = $"{upload}/{uniqueFileName}";
                using (var stream = new FileStream(pathFinal, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                urls.Add($"{url}/{uniqueFileName}");
            }

            var imagesEntity = urls.Select(x => new ImageProductEntity()
            {
                IdProduct = imagesDto.IdProduct,
                UrlImage = x
            }).ToList();

            bool result = await _imagesProductRepository.AddRange(imagesEntity) > 0;

            if (!result)
            {
                foreach (var file in urls)
                {
                    DeleteFilePath(file);
                }
            }

            return result;
        }

        public void DeleteFilePath(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                string fullPath = Path.Combine(_environment.ContentRootPath, filePath);
                if (File.Exists(fullPath))
                    File.Delete(fullPath);
            }

        }

        private bool ValidExtension(string currentExtension)
        {
            string extensions = _configuration["PathFiles:AllowedExtensions"];
            string[] validExtensions = extensions.Split(",");

            return validExtensions.Any(ext => currentExtension.Equals(ext, StringComparison.OrdinalIgnoreCase));
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return $"{Guid.NewGuid().ToString()}{Path.GetExtension(fileName)}";
        }
        #endregion
    }
}
