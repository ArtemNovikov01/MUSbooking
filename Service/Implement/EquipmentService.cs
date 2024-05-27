using Microsoft.EntityFrameworkCore;
using MUSbooking.Domain.Entity;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.AddEquipmentRespons;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.GetEquipmentsListRequest;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.UpdateEquipmentResponse;
using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentResponse;
using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentsListResponse;
using MUSbooking.Exceptions.Common.Exceptions;
using MUSbooking.Exceptions.Resources;
using MUSbooking.Services.Abstract;
using MUSbooking.Services.Extensions;

namespace MUSbooking.Services.Implement
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IMUSbookingDbContext _musBookingDbContext;

        public EquipmentService(IMUSbookingDbContext musBookingDbContext) 
        {
            _musBookingDbContext = musBookingDbContext;
        }

        public async Task<GetEquipmentsListResponse> Get(GetEquipmentsListRequest request, CancellationToken cancellationToken)
        {
            var equipmentQuery = _musBookingDbContext.Equipments
                .FilterByName(request.Name)
                .FilterByAmount(request.Amount)
                .FilterByPrice(request.Price);

            var equipmentCount = await equipmentQuery.CountAsync(cancellationToken);

            var equipmentList = await equipmentQuery
                .OrderBy(e => e.Id)
                .Skip(request.Skip)
                .Take(request.Take)
                .Select(e => new EquipmentDto(e))
                .ToListAsync(cancellationToken);

            return new GetEquipmentsListResponse()
            {
                EquipmentsList = equipmentList,
                TotalCount = equipmentCount
            };
        }

        public async Task<GetEquipmentResponse> Get(int id, CancellationToken cancellationToken)
        {
            var equipment = await _musBookingDbContext.Equipments
                .Include(e => e.Orders)
                .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

            EntityNotFoundException.ThrowIfNull(equipment, EquipmentErrorString.EquipmentNotFoundTemplate, id);

            return new GetEquipmentResponse(equipment);
        }

        public async Task Insert(AddEquipmentRequest request, CancellationToken cancellationToken)
        {
            if (await _musBookingDbContext.Equipments.AnyAsync(e => e.Name == request.Name, cancellationToken))
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Оборудование с таким названием уже существует.");

            _musBookingDbContext.Equipments.Add(new Equipment(request));
            await _musBookingDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<GetEquipmentResponse> Update(UpdateEquipmentRequest request, CancellationToken cancellationToken)
        {
            var equipment = await _musBookingDbContext.Equipments
                .Include(e => e.Orders)
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            EntityNotFoundException.ThrowIfNull(equipment, EquipmentErrorString.EquipmentNotFoundTemplate, request.Id);

            if (await _musBookingDbContext.Equipments.AnyAsync(e => e.Id != equipment.Id && e.Name == request.Name, cancellationToken))
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Оборудование с таким названием уже существует.");

            equipment.UpdateEquipment(request);

            _musBookingDbContext.Equipments.Update(equipment);
            await _musBookingDbContext.SaveChangesAsync(cancellationToken);

            return new GetEquipmentResponse(equipment);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var equipment = await _musBookingDbContext.Equipments
                .Include(e => e.Orders)
                .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

            EntityNotFoundException.ThrowIfNull(equipment, EquipmentErrorString.EquipmentNotFoundTemplate, id);

            if (equipment.Orders.Count > 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Данное оборудование кто то заказал.");

            _musBookingDbContext.Equipments.Remove(equipment);
            await _musBookingDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
