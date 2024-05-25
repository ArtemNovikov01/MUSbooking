namespace MUSbooking.Domain.Models.Responses.OrderResponses.OrdersListResponse
{
    public class GetOrdersListResponse
    {
        public IList<OrderDto> OrdersList { get; init; } = new List<OrderDto>();

        public int TotalCount { get; init; }
    }
}
