namespace MVC.Data.DTO.Product
{
    public class ConsultProductDto : ProductDto
    {
        public ConsultProductDto()
        {
            UrlImages = new List<ImageDto>();
        }

        public string State { get; set; }
        public string Category { get; set; }

        public List<ImageDto> UrlImages { get; set; }
    }
}
