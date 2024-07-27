namespace MVC.Domain.Services.Interfaces
{
    public interface IHostingEnvironmentService
    {
        string WebRootPath { get; }
        string ContentRootPath { get; }
    }
}
