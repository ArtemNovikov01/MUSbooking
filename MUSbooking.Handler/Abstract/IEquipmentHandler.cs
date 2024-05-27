using MUSbooking.Domain.Models.Requests.EquipmentRequests.AddEquipmentRespons;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.GetEquipmentsListRequest;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.UpdateEquipmentResponse;
using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentResponse;
using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentsListResponse;

namespace MUSbooking.Handlers.Abstract
{
    public interface IEquipmentHandler
    {
        Task<GetEquipmentsListResponse> Get(GetEquipmentsListRequest request, CancellationToken cancellationToken);
        Task<GetEquipmentResponse> Get(int id, CancellationToken cancellationToken);
        Task Insert(AddEquipmentRequest request, CancellationToken cancellationToken);
        Task<GetEquipmentResponse> Update(UpdateEquipmentRequest request, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
