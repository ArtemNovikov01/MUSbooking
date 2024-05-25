namespace MUSbooking.Domain.Models.Requests.EquipmentRequests.UpdateEquipmentResponse
{
    public class UpdateEquipmentRequest
    {
        public int Id { get; set; }
        /// <summary>
        ///     Название оборудования.
        /// </summary>
        public string Name { get; init; } = null!;

        /// <summary>
        ///     Оставшееся оборудование в наличии.
        /// </summary>
        public int Amount { get; init; }

        /// <summary>
        ///     Цена.
        /// </summary>
        public decimal Price { get; init; }
    }
}
