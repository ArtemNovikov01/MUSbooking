using MUSbooking.Domain.Models.Requests.OrderRequests.AddOrderResponse;
using MUSbooking.Domain.Models.Requests.OrderRequests.OrderFilterRequest;
using MUSbooking.Domain.Models.Requests.OrderRequests.UpdateOrderResponse;
using MUSbooking.Domain.Models.Responses.OrderResponses.OrderResponse;
using MUSbooking.Domain.Models.Responses.OrderResponses.OrdersListResponse;
using MUSbooking.Exceptions.Common.Exceptions;
using MUSbooking.Validation.Abstract;
using MUSbooking.Services.Abstract;
using System.Threading;

namespace MUSbooking.Validation.Implement
{
    public class OrderValidator : IOrderValidator
    {
        private readonly IOrderService _orderService;

        public OrderValidator(IOrderService orderService) 
        {
            _orderService = orderService;
        }

        public async Task<GetOrdersListResponse> Get(GetOrdersListRequest request, CancellationToken cancellationToken)
        {
            if (request.Price < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Цена не может быть меньше 0");

            if (request.Skip < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Нельзя пропустить меньше 0");

            if (request.Take < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Нельзя выбрать меньше 0");

            return await _orderService.Get(request, cancellationToken);
        }

        public async Task<GetOrderResponse> Get(int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Невалидный идентификатор");

            return await _orderService.Get(id, cancellationToken);
        }

        public async Task Insert(AddOrderRequest request, CancellationToken cancellationToken)
        {

            if (string.IsNullOrEmpty(request.Description))
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле описание должно быть заполнено");

            if (request.Equipments is null || request.Equipments.Count == 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Должен быть выбранно хотя бы одно оборудование");

            if(request.Equipments.Any(e => e.Count <= 0))
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Количество выбранного оборудование не может быть равно 0 или быть меньше 0");

            await _orderService.Insert(request, cancellationToken);
        }

        public async Task<GetOrderResponse> Update(UpdateOrderRequest request, CancellationToken cancellationToken)
        {

            if (request.Id <= 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Невалидный идентификатор");

            if (string.IsNullOrEmpty(request.Description))
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле описание должно быть заполнено");

            if (request.Equipments is null || request.Equipments.Count == 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Должен быть выбранно хотя бы одно оборудование");

            return await _orderService.Update(request, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Невалидный идентификатор");

            await _orderService.Delete(id ,cancellationToken);
        }
    }
}
