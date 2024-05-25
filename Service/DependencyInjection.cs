using Microsoft.Extensions.DependencyInjection;
using MUSbooking.Services.Abstract;
using MUSbooking.Services.Implement;

namespace MUSbooking.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IEquipmentService, EquipmentService>();

            return services;
        }
    }
}
