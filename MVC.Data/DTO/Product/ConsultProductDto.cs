namespace MVC.Data.DTO.Product
{
    public class ConsultProductDto : ProductDto
    {
        public ConsultProductDto()
        {
            UrlImages = new List<string>();
        }

        public string State { get; set; }
        public string Category { get; set; }

        public List<string> UrlImages { get; set; }
    }
}
