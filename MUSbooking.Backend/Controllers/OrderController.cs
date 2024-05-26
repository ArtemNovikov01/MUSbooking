using Microsoft.AspNetCore.Mvc;
using MUSbooking.Domain.Models.Requests.OrderRequests.AddOrderResponse;
using MUSbooking.Domain.Models.Requests.OrderRequests.OrderFilterRequest;
using MUSbooking.Domain.Models.Requests.OrderRequests.UpdateOrderResponse;
using MUSbooking.Domain.Models.Responses.OrderResponses.OrderResponse;
using MUSbooking.Domain.Models.Responses.OrderResponses.OrdersListResponse;
using MUSbooking.Exceptions.Common.Exceptions;
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
            try
            {
                return Ok(_orderHandler.Get(request));
            }
            catch (BadRequestException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка получения списка заказов");
            }
        }

        [HttpGet]
        public ActionResult<GetOrderResponse> Get(int id)
        {
            try 
            { 
                return Ok(_orderHandler.Get(id));
            }
            catch (BadRequestException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при поучении информации об заказа");
            }
        }

        [HttpPost("addOrder")]
        public ActionResult Insert(AddOrderRequest request)
        {
            try
            {
                _orderHandler.Insert(request);
                return Ok();
            }
            catch (BadRequestException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при добавлении заказа");
            }
        }

        [HttpPut]
        public ActionResult<GetOrderResponse> Update(UpdateOrderRequest request)
        {
            try 
            { 
                return Ok(_orderHandler.Update(request));
            }
            catch (BadRequestException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при оьновлении заказа");
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try 
            { 
                _orderHandler.Delete(id);
                return Ok();
            }
            catch (BadRequestException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при удалении заказа");
            }
        }
    }
}
