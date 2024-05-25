namespace MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentsListResponse
{
    public class EquipmentDto
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
    }
}
