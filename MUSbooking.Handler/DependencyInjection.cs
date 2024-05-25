using Microsoft.Extensions.DependencyInjection;
using MUSbooking.Validation.Abstract;
using MUSbooking.Validation.Implement;

namespace MUSbooking.Handlers
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<IEquipmentValidator, EquipmentValidator>();
            services.AddTransient<IOrderValidator, OrderValidator>();

            return services;
        }
    }
}

