using MUSbooking.Domain.Models.Requests.OrderRequests.AddOrderRequest;
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

        public IList<OrderedEquipmentDto> Equipments { get; init; } = null!;
    }
}
