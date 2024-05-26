using MUSbooking.Domain.Models.Requests.OrderRequests.AddOrderResponse;
using MUSbooking.Domain.Models.Requests.OrderRequests.OrderFilterRequest;
using MUSbooking.Domain.Models.Requests.OrderRequests.UpdateOrderResponse;
using MUSbooking.Domain.Models.Responses.OrderResponses.OrderResponse;
using MUSbooking.Domain.Models.Responses.OrderResponses.OrdersListResponse;
using MUSbooking.Exceptions.Common.Exceptions;
using MUSbooking.Validation.Abstract;
using MUSbooking.Services.Abstract;

namespace MUSbooking.Validation.Implement
{
    public class OrderValidator : IOrderValidator
    {
        private readonly IOrderService _orderService;
        public OrderValidator(IOrderService orderService) 
        {
            _orderService = orderService;
        }

        public GetOrdersListResponse Get(GetOrdersListRequest request)
        {
            if (request.Price < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Цена не может быть меньше 0");

            if (request.Skip < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Нельзя пропустить меньше 0");

            if (request.Take < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Нельзя выбрать меньше 0");

            return _orderService.Get(request);
        }

        public GetOrderResponse Get(int id)
        {
            if (id <= 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Невалидный идентификатор");

            return _orderService.Get(id);
        }
        public void Insert(AddOrderRequest request)
        {

            if (string.IsNullOrEmpty(request.Description))
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле описание должно быть заполнено");

            if (request.Equipments is null || request.Equipments.Count == 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Должен быть выбранно хотя бы одно оборудование");

            if(request.Equipments.Any(e => e.Count <= 0))
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Количество выбранного оборудование не может быть равно 0 или быть меньше 0");

            _orderService.Insert(request);
        }

        public GetOrderResponse Update(UpdateOrderRequest request)
        {

            if (request.Id <= 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Невалидный идентификатор");

            if (string.IsNullOrEmpty(request.Description))
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле описание должно быть заполнено");

            if (request.Equipments is null || request.Equipments.Count == 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Должен быть выбранно хотя бы одно оборудование");

            return _orderService.Update(request);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Невалидный идентификатор");

            _orderService.Delete(id);
        }
    }
}
