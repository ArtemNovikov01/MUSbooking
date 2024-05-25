using MUSbooking.Domain.Models.Requests.EquipmentRequests.AddEquipmentRespons;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.GetEquipmentsListRequest;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.UpdateEquipmentResponse;
using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentResponse;
using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentsListResponse;
using MUSbooking.Exceptions.Common.Exceptions;
using MUSbooking.Services.Abstract;
using MUSbooking.Validation.Abstract;

namespace MUSbooking.Validation.Implement
{
    public class EquipmentValidator : IEquipmentValidator
    {
        private readonly IEquipmentService _equipmentService;
        public EquipmentValidator(IEquipmentService equipmentService) 
        {
            _equipmentService = equipmentService;
        }
        public GetEquipmentsListResponse Get(GetEquipmentsListRequest request)
        {
            if (request.Amount < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Оставшееся оборудование не может быть меньше 0");

            if (request.Price < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Цена не может быть меньше 0");

            if (request.Skip < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Нельзя пропустить меньше 0");

            if (request.Take < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Нельзя выбрать меньше 0");

            return _equipmentService.Get(request);
        }

        public GetEquipmentResponse Get(int id)
        {
            if ((id) <= 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Невалидный идентификатор");

            return _equipmentService.Get(id);
        }

        public void Insert(AddEquipmentRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле описание должно быть заполнено");

            if (request.Amount < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Оставшееся оборудование не может быть меньше 0");

            if (request.Price < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Цена не может быть меньше 0");

            _equipmentService.Insert(request);
        }

        public GetEquipmentResponse Update(UpdateEquipmentRequest request)
        {
            if (request.Id <= 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Невалидный идентификатор");

            if (string.IsNullOrEmpty(request.Name))
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле описание должно быть заполнено");

            if (request.Amount < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Оставшееся оборудование не может быть меньше 0");

            if (request.Price < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Цена не может быть меньше 0");

            return _equipmentService.Update(request);
        }
        public void Delete(int id)
        {
            if (id <= 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Невалидный идентификатор");

            _equipmentService.Delete(id);
        }
    }
}
