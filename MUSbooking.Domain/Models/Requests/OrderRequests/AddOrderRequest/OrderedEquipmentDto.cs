using MUSbooking.Domain.Entity;

namespace MUSbooking.Domain.Models.Requests.OrderRequests.AddOrderRequest
{
    public class OrderedEquipmentDto
    {
        public int Id { get; init; }

        /// <summary>
        ///     Количество оборудования добавленное в заказ.
        /// </summary>
        public int Count { get; init; }
    }
}
