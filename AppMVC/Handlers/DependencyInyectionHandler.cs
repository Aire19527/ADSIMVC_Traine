using MVC.Data.Repository;
using MVC.Data.Repository.Interfaces;
using MVC.Domain.Services;
using MVC.Domain.Services.Interfaces;

namespace AppMVC.Handlers
{
    public static class DependencyInyectionHandler
    {
        public static void AddDependencyInyection(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<ICategoryServices, CategoryServices>();
            services.AddTransient<IProductServices, ProductServices>();
            services.AddTransient<IImagesProductServices, ImagesProductServices>();
            services.AddTransient<IInvoiceServices, InvoiceServices>();
            services.AddTransient<IInvoiceTypeServices, InvoiceTypeServices>();

            services.AddSingleton<IHostingEnvironmentService, HostingEnvironmentHandler>();

        }
    }
}
