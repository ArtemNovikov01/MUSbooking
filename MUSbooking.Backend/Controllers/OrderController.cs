using Microsoft.AspNetCore.Mvc;
using MUSbooking.Domain.Models.Requests.OrderRequests.AddOrderResponse;
using MUSbooking.Domain.Models.Requests.OrderRequests.OrderFilterRequest;
using MUSbooking.Domain.Models.Requests.OrderRequests.UpdateOrderResponse;
using MUSbooking.Domain.Models.Responses.OrderResponses.OrderResponse;
using MUSbooking.Domain.Models.Responses.OrderResponses.OrdersListResponse;
using MUSbooking.Validation.Abstract;

namespace MUSbooking.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderValidator _orderHandler;
        public OrderController(IOrderValidator orderHandler)
        {
            _orderHandler = orderHandler;
        }

        [HttpPost("getOrdersList")]
        public ActionResult<GetOrdersListResponse> Get(GetOrdersListRequest request)
        {
            return Ok(_orderHandler.Get(request));
        }

        [HttpGet]
        public ActionResult<GetOrderResponse> Get(int id)
        {
            return Ok(_orderHandler.Get(id));
        }

        [HttpPost("addOrder")]
        public ActionResult Insert(AddOrderRequest request)
        {
            _orderHandler.Insert(request);
            return Ok();
        }

        [HttpPut]
        public ActionResult<GetOrderResponse> Update(UpdateOrderRequest request)
        {
            return Ok(_orderHandler.Update(request));
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _orderHandler.Delete(id);
            return Ok();
        }
    }
}
