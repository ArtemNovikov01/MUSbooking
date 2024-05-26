using MUSbooking.Domain.Entity;
using MUSbooking.Domain.Models.Responses.OrderResponses.GetOrderResponse;

namespace MUSbooking.Domain.Models.Responses.OrderResponses.OrderResponse
{
    public class GetOrderResponse
    {

        public GetOrderResponse(Order order, List<EquipmentInOrderDto> equipmentsDto) 
        {
            Id = order.Id;
            Description = order.Description;
            CreatedAt = order.CreatedAt.ToString("dd.MM.yyyy");
            UpdatedAt = order.UpdatedAt?.ToString("dd.MM.yyyy");
            Price = order.Price;
            Equipments = equipmentsDto;
        }
        public int Id { get; init; }

        /// <summary>
        ///     Дополнительное описание заказа.
        /// </summary>
        public string Description { get; init; } = null!;

        /// <summary>
        ///     Время, когда заказ был создан.
        /// </summary>
        public string CreatedAt { get; init; }

        /// <summary>
        ///      Время, когда заказ был обновлен в последний раз
        /// </summary>
        public string? UpdatedAt { get; init; }

        /// <summary>
        ///     Цена.
        /// </summary>
        public decimal Price { get; init; }

        /// <summary>
        ///     Оборудование в заказе.
        /// </summary>
        public IList<EquipmentInOrderDto> Equipments { get; init; } = new List<EquipmentInOrderDto>();
    }
}
