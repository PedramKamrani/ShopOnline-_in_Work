using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application.Contract.ProductCategoryDTO;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastrucer;
using ShopManagement.Infrastrucer.Repository;
using ShopManagment.Application;

namespace ShopManagement.Configure
{
    public class ShopManagementBootstraper
    {
        public static void Configure(IServiceCollection service, string connectionstring)
        {
            service.AddScoped<IProductCategoryApplication,ProductCategoryApplication>();
            service.AddScoped<IProductCategory,ProductCategoryRepository>();
            service.AddDbContext<ShopContext>(Option =>
            {
                Option.UseSqlServer(connectionstring);
            });
        }
    }
}
