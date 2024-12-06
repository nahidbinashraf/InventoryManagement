using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Service.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServiceDI(this IServiceCollection services)
        {

            return services;
        }
    }
}
