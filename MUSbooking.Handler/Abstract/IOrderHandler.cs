using MUSbooking.Domain.Models.Requests.OrderRequests.AddOrderResponse;
using MUSbooking.Domain.Models.Requests.OrderRequests.OrderFilterRequest;
using MUSbooking.Domain.Models.Requests.OrderRequests.UpdateOrderResponse;
using MUSbooking.Domain.Models.Responses.OrderResponses.OrderResponse;
using MUSbooking.Domain.Models.Responses.OrderResponses.OrdersListResponse;

namespace MUSbooking.Handlers.Abstract
{
    public interface IOrderHandler
    {
        Task<GetOrdersListResponse> Get(GetOrdersListRequest request, CancellationToken cancellationToken);
        Task<GetOrderResponse> Get(int id, CancellationToken cancellationToken);
        Task Insert(AddOrderRequest request, CancellationToken cancellationToken);
        Task<GetOrderResponse> Update(UpdateOrderRequest request, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
