using MVC.Domain.Services.Interfaces;

namespace AppMVC.Handlers
{
    public class HostingEnvironmentHandler: IHostingEnvironmentService
    {
        #region Attributes
        private readonly IWebHostEnvironment _webHostEnvironment;
        #endregion

        #region Builder
        public HostingEnvironmentHandler(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion


        public string WebRootPath => _webHostEnvironment.WebRootPath;
        public string ContentRootPath => _webHostEnvironment.ContentRootPath;
    }
}
