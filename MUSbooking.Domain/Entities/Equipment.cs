using MUSbooking.Domain.Entities;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.AddEquipmentRespons;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.UpdateEquipmentResponse;

namespace MUSbooking.Domain.Entity
{
    /// <summary>
    ///     Оборудование.
    /// </summary>
    public class Equipment
    {
        public Equipment() { }

        /// <summary>
        ///     Создание оборудования
        /// </summary>
        public Equipment(AddEquipmentRequest request) 
        {
            Name = request.Name;
            Amount = request.Amount;
            Price = request.Price;
        }

        public int Id { get; private set; }

        /// <summary>
        ///     Название оборудования.
        /// </summary>
        public string Name { get; private set; } = null!;

        /// <summary>
        ///     Оставшееся оборудование в наличии.
        /// </summary>
        public int Amount { get; private set; }

        /// <summary>
        ///     Цена.
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        ///     Заказ.
        /// </summary>
        public IList<OrderedEquipment> Orders { get; private set; } = new List<OrderedEquipment>();

        #region Modify
        public void UpdateEquipment(UpdateEquipmentRequest request)
        {
            Name = request.Name;
            Amount = request.Amount;
            Price = request.Price;
        }

        public void BuyEquipment(int count)
        {
            Amount -= count;
        }

        public void CancelBuyEquipment(int count)
        {
            Amount += count;
        }
        #endregion
    }
}
