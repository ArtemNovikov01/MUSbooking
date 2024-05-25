using MUSbooking.Domain.Entity;
using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentsListResponse;

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
        public IList<EquipmentDto> Equipments { get; init; } = null!;
    }
}
