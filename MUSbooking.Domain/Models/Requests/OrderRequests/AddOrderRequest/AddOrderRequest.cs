using MUSbooking.Domain.Models.Requests.OrderRequests.AddOrderRequest;

namespace MUSbooking.Domain.Models.Requests.OrderRequests.AddOrderResponse
{
    public class AddOrderRequest
    {
        /// <summary>
        ///     Дополнительное описание заказа.
        /// </summary>
        public string Description { get; init; } = null!;

        /// <summary>
        ///     Оборудование добавленное в заказ.
        /// </summary>
        public IList<OrderedEquipmentDto> Equipments { get; init; } = null!;
    }
}
