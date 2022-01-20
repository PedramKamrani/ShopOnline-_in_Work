using Account.Management.Application;
using Account.Management.Infrastracure;
using AccountManagement.Application.Contract.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Account.Management.Configure
{
    public static class BootstraperMappingAccountConfigure
    {
        public static void Configure(IServiceCollection services, string connectionstring)
        {
            services.AddScoped<IAccountApplication,AccountApplication>();
            //services.AddScoped<IAccountApplication,AccountApplication>();
            services.AddDbContext<AccountContext>(op =>
            {
                op.UseSqlServer(connectionstring);
            });
        }
    }
}
