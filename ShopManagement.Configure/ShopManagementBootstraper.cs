using _1_QueryLayer.Query;
using _1_QueryLayer.Query.Contract.Slider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application.Contract.ProductCategoryDTO;
using ShopManagement.Application.Contract.ProductDTO;
using ShopManagement.Application.Contract.ProductPictureDTO;
using ShopManagement.Application.Contract.SliderDTO;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SliderAgg;
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

            //Slider
            service.AddScoped<ISlider,SliderRepository>();
            service.AddScoped<ISliderApplication,SliderApplication>();

            ///Query
            service.AddScoped<ISliderQuery, SliderQuery>();
            //Context
            service.AddDbContext<ShopContext>(Option =>
            {
                Option.UseSqlServer(connectionstring);
            });
        }
    }
}
