using MUSbooking.Domain.Entity;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.AddEquipmentRespons;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.GetEquipmentsListRequest;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.UpdateEquipmentResponse;
using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentResponse;
using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentsListResponse;
using MUSbooking.Exceptions.Common.Exceptions;
using MUSbooking.Services.Abstract;
using MUSbooking.Exceptions.Resources;
using Microsoft.EntityFrameworkCore;
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

        public GetEquipmentsListResponse Get(GetEquipmentsListRequest request)
        {
            var equipmentQuery = _musBookingDbContext.Equipments
                .FilterByName(request.Name)
                .FilterByAmount(request.Amount)
                .FilterByPrice(request.Price);

            var equipmentCount = equipmentQuery.Count();

            var equipmentList = equipmentQuery
                .OrderBy(e => e.Id)
                .Skip(request.Skip)
                .Take(request.Take)
                .Select(e => new EquipmentDto(e))
                .ToList();

            return new GetEquipmentsListResponse()
            {
                EquipmentsList = equipmentList,
                TotalCount = equipmentCount
            };
        }

        public GetEquipmentResponse Get(int id)
        {
            var equipment = _musBookingDbContext.Equipments
                .Include(e => e.Orders)
                .FirstOrDefault(e => e.Id == id);

            EntityNotFoundException.ThrowIfNull(equipment, EquipmentErrorString.EquipmentNotFoundTemplate, id);

            return new GetEquipmentResponse(equipment);
        }

        public void Insert(AddEquipmentRequest request)
        {
            if (_musBookingDbContext.Equipments.Any(e => e.Name == request.Name))
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Оборудование с таким названием уже существует.");

            _musBookingDbContext.Equipments.Add(new Equipment(request));
            _musBookingDbContext.SaveChanges();
        }

        public GetEquipmentResponse Update(UpdateEquipmentRequest request)
        {
            var equipment = _musBookingDbContext.Equipments
                .Include(e => e.Orders)
                .FirstOrDefault(e => e.Id == request.Id);

            EntityNotFoundException.ThrowIfNull(equipment, EquipmentErrorString.EquipmentNotFoundTemplate, request.Id);

            if (_musBookingDbContext.Equipments.Any(e => e.Id != equipment.Id && e.Name == request.Name))
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Оборудование с таким названием уже существует.");

            equipment.UpdateEquipment(request);

            _musBookingDbContext.Equipments.Update(equipment);
            _musBookingDbContext.SaveChanges();

            return new GetEquipmentResponse(equipment);
        }
        public void Delete(int id)
        {
            var equipment = _musBookingDbContext.Equipments
                .Include(e => e.Orders)
                .FirstOrDefault(e => e.Id == id);

            EntityNotFoundException.ThrowIfNull(equipment, EquipmentErrorString.EquipmentNotFoundTemplate, id);

            if (equipment.Orders.Count > 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Данное оборудование кто то заказал.");

            _musBookingDbContext.Equipments.Remove(equipment);
            _musBookingDbContext.SaveChanges();
        }
    }
}
