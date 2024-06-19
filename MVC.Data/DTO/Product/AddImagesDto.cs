using Microsoft.AspNetCore.Http;

namespace MVC.Data.DTO.Product
{
    public class AddImagesDto
    {
        public AddImagesDto()
        {
            Images = new List<IFormFile>();
        }

        public int IdProduct { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
