using MUSbooking.Domain.Entity;

namespace MUSbooking.Domain.Models.Responses.OrderResponses.OrdersListResponse
{
    public class OrderDto
    {
        public OrderDto(Order order)
        {
            Id = order.Id;
            ShortDescription = (order.Description.Length > 10) ? order.Description.Substring(0, 10) + "..." : order.Description;
            CreatedAt = order.CreatedAt;
            EquipmentsCount = order.Equipments.Count;
            Price = order.Price;
        }
        public int Id { get; init; }

        /// <summary>
        ///     Краткое описание заказа.
        /// </summary>
        public string ShortDescription { get; init; } = null!;

        /// <summary>
        ///     Время, когда заказ был создан.
        /// </summary>
        public DateTime CreatedAt { get; init; }

        public int EquipmentsCount { get; init; }

        /// <summary>
        ///     Цена.
        /// </summary>
        public decimal Price { get; init; }
    }
}
