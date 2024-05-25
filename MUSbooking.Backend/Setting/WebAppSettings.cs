using MUSbooking.Infrastructure.DataBase.Setting;

namespace MUSbooking.Backend.Setting
{
    public sealed record WebAppSettings
    {
        /// <summary>
        /// Настройки БД
        /// </summary>
        public DatabaseSettings? Database { get; init; }
    }
}
