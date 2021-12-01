using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application.Contract.ProductCategoryDTO;
using ShopManagement.Application.Contract.ProductDTO;
using ShopManagement.Application.Contract.ProductPictureDTO;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
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
            //Product
            service.AddScoped<IProduct, ProductRepository>();
            service.AddScoped<IProductApplication, ProductApplication>();
            //Product Picture
            service.AddScoped<IProductPicture, ProductPictureRepository>();
            service.AddScoped<IProductPictureApplication, ProductPictureApplication>();
            //Context
            service.AddDbContext<ShopContext>(Option =>
            {
                Option.UseSqlServer(connectionstring);
            });
        }
    }
}
