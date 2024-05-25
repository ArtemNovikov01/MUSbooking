namespace MUSbooking.Domain.Models.Requests.EquipmentRequests.AddEquipmentRespons
{
    public class AddEquipmentRequest
    {
        /// <summary>
        ///     Название оборудования.
        /// </summary>
        public string Name { get; init; } = null!;

        /// <summary>
        ///     Количество оборудования в наличии.
        /// </summary>
        public int Amount { get; init; }

        /// <summary>
        ///     Цена.
        /// </summary>
        public decimal Price { get; init; }
    }
}
