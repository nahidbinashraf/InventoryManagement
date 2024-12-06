using Microsoft.Extensions.DependencyInjection;
using InventoryManagement.Infrastructure.Services;
using InventoryManagement.Service.Interfaces;

namespace InventoryManagement.Service.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServiceDI(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
