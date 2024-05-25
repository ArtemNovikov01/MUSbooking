using MUSbooking.Backend.Setting;
using System.Text.Json;
using System.Text.Json.Serialization;
using MUSbooking.Infrastructure.DataBase;
using MUSbooking.Handlers;
using MUSbooking.Services;

namespace MUSbooking.Backend
{
    public static class DependencyInjection
    {
        public static WebApplicationBuilder BuildWebApplication(this WebApplicationBuilder builder)
        {
            var webAppSettings = builder.Configuration.Get<WebAppSettings>()
                             ?? throw new NullReferenceException("Не заданы настройки приложения");

            // Services
            builder.Services
                .AddDatabase(webAppSettings.Database)
                .AddHandlers()
                .AddServices();

            builder.Services
                .AddMvc()
                .AddJsonOptions(o =>
                {
                    o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                });

            // Swagger
            builder.Services
                .AddSwaggerGen();

            return builder;
        }

        public static WebApplication ConfigureWebApplication(this WebApplication app)
        {
            // Localization
            app.UseRequestLocalization(opt =>
            {
                // configure localization
            });

            app.UseSwagger();
            app.UseSwaggerUI(opt => { opt.SwaggerEndpoint("v1/swagger.json", "AllSharing Backend"); });

            app.UseRouting();

            app.MapControllers();

            return app;
        }
    }
}
