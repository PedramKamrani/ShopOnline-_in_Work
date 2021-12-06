using Discount.Managment.Application.Contract.Discount.Managment.DTO;
using Discount.Managment.Infrastrucer.EFCore;
using Discount.Managment.Infrastrucer.EFCore.Repository;
using DisCount.Manangment.Domain.CustomerDiscounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Discount.Managment.Configure
{
    public class DiscountManagementBootstraper
    {
        public static void Configure(IServiceCollection service, string connectionstring)
        {
            service.AddScoped<ICustomerDiscount, CustomerDiscountRepository>();
            //service.AddScoped<ICustomerDiscount,CustomerDiscountApplication>();

            service.AddDbContext<CustomerDisCountContext>(option =>
            {
                option.UseSqlServer(connectionstring);
            });
        }
    }
}
