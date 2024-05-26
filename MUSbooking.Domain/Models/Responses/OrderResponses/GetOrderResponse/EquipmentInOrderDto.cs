using MUSbooking.Domain.Entity;

namespace MUSbooking.Domain.Models.Responses.OrderResponses.GetOrderResponse
{
    public class EquipmentInOrderDto
    {
        public EquipmentInOrderDto(Equipment equipment, int count)
        {
            Id = equipment.Id;
            Name = equipment.Name;
            Price = equipment.Price;
            Count = count;
        }

        public int Id { get; init; }

        /// <summary>
        ///     Название оборудования.
        /// </summary>
        public string Name { get; init; } = null!;

        /// <summary>
        ///     Цена.
        /// </summary>
        public decimal Price { get; init; }

        /// <summary>
        ///     Количество оборудования в заказе.
        /// </summary>
        public int? Count { get; init; }
    }
}
