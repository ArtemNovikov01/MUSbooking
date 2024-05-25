using MUSbooking.Domain.Models.Requests.OrderRequests.AddOrderResponse;
using MUSbooking.Domain.Models.Requests.OrderRequests.OrderFilterRequest;
using MUSbooking.Domain.Models.Requests.OrderRequests.UpdateOrderResponse;
using MUSbooking.Domain.Models.Responses.OrderResponses.OrderResponse;
using MUSbooking.Domain.Models.Responses.OrderResponses.OrdersListResponse;

namespace MUSbooking.Handlers.Abstract
{
    public interface IOrderHandler
    {
        GetOrdersListResponse Get(GetOrdersListRequest request);
        GetOrderResponse Get(int id);
        void Insert(AddOrderRequest request);
        GetOrderResponse Update(UpdateOrderRequest request);
        void Delete(int id);
    }
}
