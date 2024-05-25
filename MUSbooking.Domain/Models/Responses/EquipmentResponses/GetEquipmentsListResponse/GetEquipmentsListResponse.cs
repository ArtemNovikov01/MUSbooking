namespace MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentsListResponse
{
    public class GetEquipmentsListResponse
    {
        public IList<EquipmentDto> Equipments { get; init; } = new List<EquipmentDto>();

        public int TotalCount { get; init; }
    }
}
