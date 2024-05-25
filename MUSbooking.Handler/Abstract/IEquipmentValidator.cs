using MUSbooking.Domain.Models.Requests.EquipmentRequests.AddEquipmentRespons;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.GetEquipmentsListRequest;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.UpdateEquipmentResponse;
using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentResponse;
using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentsListResponse;

namespace MUSbooking.Validation.Abstract
{
    public interface IEquipmentValidator
    {
        GetEquipmentsListResponse Get(GetEquipmentsListRequest request);
        GetEquipmentResponse Get(int id);
        void Insert(AddEquipmentRequest request);
        GetEquipmentResponse Update(UpdateEquipmentRequest request);
        void Delete(int id);
    }
}
