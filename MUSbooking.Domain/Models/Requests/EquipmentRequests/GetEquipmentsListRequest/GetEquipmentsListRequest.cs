namespace MUSbooking.Domain.Models.Requests.EquipmentRequests.GetEquipmentsListRequest
{
    public class GetEquipmentsListRequest
    {
        /// <summary>
        ///     Название оборудования.
        /// </summary>
        public string? Name { get; init; }

        /// <summary>
        ///     Количество оборудования в наличии.
        /// </summary>
        public int? Amount { get; init; }

        /// <summary>
        ///     Цена.
        /// </summary>
        public decimal? Price { get; init; }

        public int? Skip { get; init; }

        public int? Take { get; set; }
    }
}
