using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Core.Models;
using InventoryManagement.Infrastructure.Data;
using InventoryManagement.Infrastructure.Repositories;

namespace InventoryManagement.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSetting = new ApplicationSetting();
            configuration.Bind(applicationSetting);
            services.AddSingleton(applicationSetting);

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(applicationSetting.ConnectionStrings.DefaultConnection)
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
