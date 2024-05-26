namespace MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentsListResponse
{
    public class GetEquipmentsListResponse
    {
        public IList<EquipmentDto> EquipmentsList { get; init; } = new List<EquipmentDto>();

        public int TotalCount { get; init; }
    }
}
