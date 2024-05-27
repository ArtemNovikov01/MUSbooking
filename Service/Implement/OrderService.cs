using Microsoft.EntityFrameworkCore;
using MUSbooking.Domain.Entities;
using MUSbooking.Domain.Entity;
using MUSbooking.Domain.Models.Requests.OrderRequests.AddOrderRequest;
using MUSbooking.Domain.Models.Requests.OrderRequests.AddOrderResponse;
using MUSbooking.Domain.Models.Requests.OrderRequests.OrderFilterRequest;
using MUSbooking.Domain.Models.Requests.OrderRequests.UpdateOrderResponse;
using MUSbooking.Domain.Models.Responses.OrderResponses.GetOrderResponse;
using MUSbooking.Domain.Models.Responses.OrderResponses.OrderResponse;
using MUSbooking.Domain.Models.Responses.OrderResponses.OrdersListResponse;
using MUSbooking.Exceptions.Common.Exceptions;
using MUSbooking.Exceptions.Resources;
using MUSbooking.Services.Abstract;
using MUSbooking.Services.Extensions;

namespace MUSbooking.Services.Implement
{
    public class OrderService : IOrderService
    {

        private readonly IMUSbookingDbContext _musBookingDbContext;

        public OrderService(IMUSbookingDbContext musBookingDbContext)
        {
            _musBookingDbContext = musBookingDbContext;
        }

        public async Task<GetOrdersListResponse> Get(GetOrdersListRequest request, CancellationToken cancellationToken)
        {
            var orderQuery = _musBookingDbContext.Orders
                .Include(o => o.Equipments)
                .FilterByDescription(request.Description)
                .FilterByPrice(request.Price)
                .FilterByCreatedAt(request.CreatedAt);

            var orderCount = await orderQuery.CountAsync(cancellationToken);

            var equipmentList = await orderQuery
                .OrderBy(e => e.Id)
                .ThenBy(e => e.CreatedAt)
                .Skip(request.Skip)
                .Take(request.Take)
                .Select(e => new OrderDto(e))
                .ToListAsync(cancellationToken);

            return new GetOrdersListResponse()
            {
                OrdersList = equipmentList,
                TotalCount = orderCount
            };
        }

        public async Task<GetOrderResponse> Get(int id, CancellationToken cancellationToken)
        {
            var order = await _musBookingDbContext.Orders
                .Include(o => o.Equipments)
                .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

            EntityNotFoundException.ThrowIfNull(order, OrderErrorString.OrderNotFoundTemplate, id);

            var equipments = _musBookingDbContext.Equipments.AsEnumerable()
                .Where(e => order.Equipments.Any(orderE => e.Id == orderE.EquipmentId)).ToList();

            var equipmentsDto = order.Equipments
                .Join(equipments, orderE => orderE.EquipmentId, e => e.Id,
                    (orderE, e) => new EquipmentInOrderDto(e, orderE.Count))
                .ToList();

            return new GetOrderResponse(order, equipmentsDto);
        }

        public async Task Insert(AddOrderRequest request, CancellationToken cancellationToken)
        {
            var equipments = _musBookingDbContext.Equipments.AsEnumerable()
                .Where(e => request.Equipments.Any(eFromRequest => eFromRequest.Id == e.Id))
                .ToList();

            ValidateEquipments(request.Equipments.ToList(), equipments);

            var order = _musBookingDbContext.Orders.Add(new Order(request.Description)).Entity;

            var orderedEquipment = ManageOrderedEquipment(order.Id, request.Equipments.ToList(), equipments.ToList());
            order.AddEquipments(orderedEquipment);

            await _musBookingDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<GetOrderResponse> Update(UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _musBookingDbContext.Orders
                .Include(o => o.Equipments)
                .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

            EntityNotFoundException.ThrowIfNull(order, OrderErrorString.OrderNotFoundTemplate, request.Id);

            var equipments = _musBookingDbContext.Equipments.AsEnumerable()
                .Where(e => request.Equipments.Any(eFromRequest => eFromRequest.Id == e.Id))
                .ToList();

            ValidateEquipments(request.Equipments.ToList(), equipments);

            var restoredOrderedEquipment = ManageOrderedEquipment(order.Id, request.Equipments.ToList(),
                RecoveryAmountEquipment(equipments, order.Equipments.ToList()));

            order.UpdateDescription(request.Description);

            _musBookingDbContext.OrderedEquipments.RemoveRange(order.Equipments.ToList());

            order.AddEquipments(restoredOrderedEquipment);
            await _musBookingDbContext.SaveChangesAsync(cancellationToken);

            var equipmentsDto = order.Equipments
                .Join(equipments, orderE => orderE.EquipmentId, e => e.Id, 
                    (oe, e) => new EquipmentInOrderDto(e, oe.Count))
                .ToList();

            return new GetOrderResponse(order, equipmentsDto);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var order = await _musBookingDbContext.Orders
                .Include(o => o.Equipments)
                .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

            EntityNotFoundException.ThrowIfNull(order, OrderErrorString.OrderNotFoundTemplate, id);

            var equipments = _musBookingDbContext.Equipments
                .AsEnumerable()
                .Where(e => order.Equipments
                    .Any(oe => e.Id == oe.EquipmentId)).ToList();

            var restoredEquipments = RecoveryAmountEquipment(equipments, order.Equipments.ToList());

            _musBookingDbContext.Equipments.UpdateRange(restoredEquipments);

            _musBookingDbContext.Orders.Remove(order);
            await _musBookingDbContext.SaveChangesAsync(cancellationToken);
        }

        private List<Equipment> RecoveryAmountEquipment(List<Equipment> equipments, List<OrderedEquipment> oldEquipments)
        {
            equipments.ForEach(equipment =>
            {
                var oldEquipment = oldEquipments.FirstOrDefault(oe => oe.EquipmentId == equipment.Id);
                if (oldEquipment != null)
                    equipment.CancelBuyEquipment(oldEquipment.Count);
            });
            return equipments;
        }

        private List<OrderedEquipment> ManageOrderedEquipment(int orderId, List<OrderedEquipmentDto> requestedEquipment, List<Equipment> availableEquipment)
        {
            List<OrderedEquipment> restoredOrderedEquipments = requestedEquipment
                .Select(requestedItem =>
            {
                var available = availableEquipment
                    .FirstOrDefault(a => a.Id == requestedItem.Id);
                if (available == null)
                    throw new BadRequestException(ErrorCodes.Common.BadRequest,
                        $"Оборудование с ID {requestedItem.Id} не найдено.");

                if (available.Amount < requestedItem.Count)
                    throw new BadRequestException(ErrorCodes.Common.BadRequest,
                        $"Запрашиваемое количество оборудования превышает доступное количество - {available.Amount}.");

                available.BuyEquipment(requestedItem.Count);
                return _musBookingDbContext.OrderedEquipments.Add(
                    new OrderedEquipment(requestedItem.Id, orderId, requestedItem.Count, available.Price)).Entity;
            }).ToList();

            return restoredOrderedEquipments;
        }

        private void ValidateEquipments(List<OrderedEquipmentDto> requestedEquipment, List<Equipment> availableEquipment)
        {
            var equipmentsNotFound = availableEquipment
                .Select(equipment => equipment.Id)
                .Except(requestedEquipment
                    .Select(equipment => equipment.Id))
                .ToList();

            var missingEquipmentIds = string.Join(", ", equipmentsNotFound);
            var errorMessageTemplate = equipmentsNotFound.Count > 1
                ? EquipmentErrorString.EquipmentsNotFoundTemplate
                : EquipmentErrorString.EquipmentNotFoundTemplate;

            EntityNotFoundException.ThrowIfAny(equipmentsNotFound, errorMessageTemplate, missingEquipmentIds);
        }
    }
}
