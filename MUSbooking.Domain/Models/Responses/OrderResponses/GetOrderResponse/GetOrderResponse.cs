using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentsListResponse;

namespace MUSbooking.Domain.Models.Responses.OrderResponses.OrderResponse
{
    public class GetOrderResponse
    {
        public int Id { get; init; }

        /// <summary>
        ///     Дополнительное описание заказа.
        /// </summary>
        public string Description { get; init; } = null!;

        /// <summary>
        ///     Время, когда заказ был создан.
        /// </summary>
        public DateTime CreatedAt { get; init; }

        /// <summary>
        ///      Время, когда заказ был обновлен в последний раз
        /// </summary>
        public DateTime? UpdatedAt { get; init; }

        /// <summary>
        ///     Цена.
        /// </summary>
        public decimal Price { get; init; }

        /// <summary>
        ///     Оборудование в заказе.
        /// </summary>
        public IList<EquipmentDto> Equipments { get; init; } = new List<EquipmentDto>();
    }
}
