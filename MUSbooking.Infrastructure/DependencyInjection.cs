using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MUSbooking.Infrastructure.DataBase.Setting;
using MUSbooking.Services;

namespace MUSbooking.Infrastructure.DataBase
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, DatabaseSettings? databaseSettings)
        {
            if (databaseSettings?.ConnectionString is null)
            {
                throw new ArgumentNullException(nameof(databaseSettings), "Не заданы настройки БД");
            }

            services.AddDbContext<MUSbookingDbContext>(opt => opt.UseNpgsql(databaseSettings.ConnectionString));
            services.AddTransient<IMUSbookingDbContext, MUSbookingDbContext>();

            return services;
        }
    }
}
