using MUSbooking.Domain.Models.Requests.OrderRequests.AddOrderResponse;
using MUSbooking.Domain.Models.Requests.OrderRequests.OrderFilterRequest;
using MUSbooking.Domain.Models.Requests.OrderRequests.UpdateOrderResponse;
using MUSbooking.Domain.Models.Responses.OrderResponses.OrderResponse;
using MUSbooking.Domain.Models.Responses.OrderResponses.OrdersListResponse;
using MUSbooking.Handlers.Abstract;

namespace MUSbooking.Handlers.Implement
{
    public class OrderHandler : IOrderHandler
    {
        public OrderHandler() { }

        public void Insert(AddOrderRequest request)
        {
            throw new NotImplementedException();
        }

        public GetOrderResponse Update(UpdateOrderRequest request)
        {
            throw new NotImplementedException();
        }
        public GetOrdersListResponse Get(GetOrdersListRequest request)
        {
            throw new NotImplementedException();
        }

        public GetOrderResponse Get(int id)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
