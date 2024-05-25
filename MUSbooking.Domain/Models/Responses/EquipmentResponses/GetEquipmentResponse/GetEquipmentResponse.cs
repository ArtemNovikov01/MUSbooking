namespace MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentResponse
{
    public class GetEquipmentResponse
    {
        public int Id { get; init; }

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

        /// <summary>
        ///     Количество заказов с данным оборудованием.
        /// </summary>
        public int OrderCount { get; init; }
    }
}
