namespace MUSbooking.Domain.Models.Responses.OrderResponses.OrdersListResponse
{
    public class OrderDto
    {
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
