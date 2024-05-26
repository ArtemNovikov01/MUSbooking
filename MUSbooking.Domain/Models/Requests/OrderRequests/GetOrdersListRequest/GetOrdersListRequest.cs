namespace MUSbooking.Domain.Models.Requests.OrderRequests.OrderFilterRequest
{
    public class GetOrdersListRequest
    {
        public string? Description { get; init; }
        public decimal? Price { get; init; }
        public DateTime? CreatedAt { get; init; }
        public int Skip { get; init; }
        public int Take { get; init; }
    }
}
