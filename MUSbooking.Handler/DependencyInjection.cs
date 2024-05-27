using Microsoft.Extensions.DependencyInjection;
using MUSbooking.Handlers.Abstract;
using MUSbooking.Handlers.Implement;

namespace MUSbooking.Handlers
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<IEquipmentHandler, EquipmentHandler>();
            services.AddTransient<IOrderHandler, OrderHandler>();

            return services;
        }
    }
}

