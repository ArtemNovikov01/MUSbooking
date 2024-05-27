using MUSbooking.Domain.Models.Requests.EquipmentRequests.AddEquipmentRespons;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.GetEquipmentsListRequest;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.UpdateEquipmentResponse;
using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentResponse;
using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentsListResponse;
using MUSbooking.Exceptions.Common.Exceptions;
using MUSbooking.Services.Abstract;
using MUSbooking.Handlers.Abstract;

namespace MUSbooking.Handlers.Implement
{
    public class EquipmentHandler : IEquipmentHandler
    {

        private readonly IEquipmentService _equipmentService;
        public EquipmentHandler(IEquipmentService equipmentService) 
        {
            _equipmentService = equipmentService;
        }

        public async Task<GetEquipmentsListResponse> Get(GetEquipmentsListRequest request, CancellationToken cancellationToken)
        {
            if (request.Amount < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Оставшееся оборудование не может быть меньше 0");

            if (request.Price < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Цена не может быть меньше 0");

            if (request.Skip < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Нельзя пропустить меньше 0");

            if (request.Take < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Нельзя выбрать меньше 0");

            return await _equipmentService.Get(request, cancellationToken);
        }

        public async Task<GetEquipmentResponse> Get(int id, CancellationToken cancellationToken)
        {
            if ((id) <= 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Невалидный идентификатор");

            return await _equipmentService.Get(id, cancellationToken);
        }

        public async Task Insert(AddEquipmentRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name))
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле описание должно быть заполнено");

            if (request.Amount < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Оставшееся оборудование не может быть меньше 0");

            if (request.Price < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Цена не может быть меньше 0");

            await _equipmentService.Insert(request, cancellationToken);
        }

        public async Task<GetEquipmentResponse> Update(UpdateEquipmentRequest request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Невалидный идентификатор");

            if (string.IsNullOrEmpty(request.Name))
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Поле описание должно быть заполнено");

            if (request.Amount < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Оставшееся оборудование не может быть меньше 0");

            if (request.Price < 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Цена не может быть меньше 0");

            return await _equipmentService.Update(request, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
                throw new BadRequestException(ErrorCodes.Common.BadRequest, "Невалидный идентификатор");

            await _equipmentService.Delete(id, cancellationToken);
        }
    }
}
