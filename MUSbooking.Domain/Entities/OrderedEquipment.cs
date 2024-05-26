using MUSbooking.Domain.Entity;

namespace MUSbooking.Domain.Entities
{
    public class OrderedEquipment
    {
        public OrderedEquipment() { }
        public OrderedEquipment(int equipmentId, int orderId, int count, decimal price) 
        {
            EquipmentId = equipmentId;
            OrderId = orderId;
            Count = count;  
            TotalPrice = price * count;  
        }

        public int Id { get; private set; }
        public int EquipmentId { get; private set; }
        public Equipment Equipment { get; private set; }
        public int OrderId { get; private set; }
        public Order Order { get; private set; }
        public int Count { get; private set; }
        public decimal TotalPrice { get; private set; }
    }
}
