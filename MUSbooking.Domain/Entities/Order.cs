using MUSbooking.Domain.Entities;
using MUSbooking.Domain.Models.Requests.OrderRequests.AddOrderResponse;

namespace MUSbooking.Domain.Entity
{
    /// <summary>
    ///     Заказ.
    /// </summary>
    public class Order
    {
        public Order() { }

        public Order(string description) 
        {
            Description = description;
        }

        public int Id { get; private set; }

        /// <summary>
        ///     Дополнительное описание заказа.
        /// </summary>
        public string Description { get; private set; } = null!;

        /// <summary>
        ///     Время, когда заказ был создан.
        /// </summary>
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        /// <summary>
        ///      Время, когда заказ был обновлен в последний раз
        /// </summary>
        public DateTime? UpdatedAt { get; private set; }

        /// <summary>
        ///     Цена.
        /// </summary>
        public decimal Price { get; private set; }

        public IList<OrderedEquipment> Equipments { get; private set; } = new List<OrderedEquipment>();

        #region Modify
        public void AddEquipments(IList<OrderedEquipment> equipments)
        {
            Equipments = equipments;
            Price = equipments.Sum(e => e.TotalPrice);
        }

        public void UpdateDescription(string description)
        {
            Description = description;
            UpdatedAt = DateTime.UtcNow;
        }
        #endregion
    }
}
