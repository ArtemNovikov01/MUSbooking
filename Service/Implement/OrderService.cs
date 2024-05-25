using MUSbooking.Domain.Models.Requests.OrderRequests.AddOrderResponse;
using MUSbooking.Domain.Models.Requests.OrderRequests.OrderFilterRequest;
using MUSbooking.Domain.Models.Requests.OrderRequests.UpdateOrderResponse;
using MUSbooking.Domain.Models.Responses.OrderResponses.OrderResponse;
using MUSbooking.Domain.Models.Responses.OrderResponses.OrdersListResponse;
using MUSbooking.Services.Abstract;

namespace MUSbooking.Services.Implement
{
    public class OrderService : IOrderService
    {

        private readonly IMUSbookingDbContext _musBookingDbContext;

        public OrderService(IMUSbookingDbContext musBookingDbContext)
        {
            _musBookingDbContext = musBookingDbContext;
        }

        public GetOrdersListResponse Get(GetOrdersListRequest request)
        {
            throw new NotImplementedException();
        }

        public GetOrderResponse Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(AddOrderRequest request)
        {
            throw new NotImplementedException();
        }

        public GetOrderResponse Update(UpdateOrderRequest request)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
