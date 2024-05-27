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
        public async Task<ActionResult<GetOrdersListResponse>> Get(GetOrdersListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _orderHandler.Get(request, cancellationToken));
            }
            catch (BaseException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка получения списка заказов");
            }
        }

        [HttpGet]
        public async Task<ActionResult<GetOrderResponse>> Get(int id, CancellationToken cancellationToken)
        {
            try 
            { 
                return Ok(await _orderHandler.Get(id, cancellationToken));
            }
            catch (BaseException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при поучении информации об заказа");
            }
        }

        [HttpPost("addOrder")]
        public async Task<ActionResult> Insert(AddOrderRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _orderHandler.Insert(request, cancellationToken);
                return Ok();
            }
            catch (BaseException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при добавлении заказа");
            }
        }

        [HttpPut]
        public async Task<ActionResult<GetOrderResponse>> Update(UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            try 
            { 
                return Ok(await _orderHandler.Update(request, cancellationToken));
            }
            catch (BaseException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при оьновлении заказа");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            try 
            { 
                await _orderHandler.Delete(id, cancellationToken);
                return Ok();
            }
            catch (BaseException exception)
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
