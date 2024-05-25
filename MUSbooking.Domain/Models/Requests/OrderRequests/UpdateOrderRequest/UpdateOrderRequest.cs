using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentsListResponse;

namespace MUSbooking.Domain.Models.Requests.OrderRequests.UpdateOrderResponse
{
    public class UpdateOrderRequest
    {
        public int Id { get; init; }

        /// <summary>
        ///     Дополнительное описание заказа.
        /// </summary>
        public string Description { get; init; } = null!;

        /// <summary>
        ///      Время, когда заказ был обновлен в последний раз
        /// </summary>
        public DateTime UpdatedAt { get; init; } = DateTime.Now;

        /// <summary>
        ///     Цена.
        /// </summary>
        public decimal Price { get; init; }

        public IList<EquipmentDto> Equipments { get; init; } = null!;
    }
}
