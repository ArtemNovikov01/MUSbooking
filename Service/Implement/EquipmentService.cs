using MUSbooking.Domain.Models.Requests.EquipmentRequests.AddEquipmentRespons;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.GetEquipmentsListRequest;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.UpdateEquipmentResponse;
using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentResponse;
using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentsListResponse;
using MUSbooking.Services.Abstract;

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
            throw new NotImplementedException();
        }

        public GetEquipmentResponse Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(AddEquipmentRequest request)
        {
            throw new NotImplementedException();
        }

        public GetEquipmentResponse Update(UpdateEquipmentRequest request)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
