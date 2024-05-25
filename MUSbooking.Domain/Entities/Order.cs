namespace MUSbooking.Domain.Entity
{
    /// <summary>
    ///     Заказ.
    /// </summary>
    public class Order
    {
        public int Id { get; private set; }

        /// <summary>
        ///     Дополнительное описание заказа.
        /// </summary>
        public string Description { get; private set; } = null!;

        /// <summary>
        ///     Время, когда заказ был создан.
        /// </summary>
        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        /// <summary>
        ///      Время, когда заказ был обновлен в последний раз
        /// </summary>
        public DateTime? UpdatedAt { get; private set; }

        /// <summary>
        ///     Цена.
        /// </summary>
        public decimal Price { get; private set; }

        public IList<Equipment> Equipments { get; private set; } = null!;
    }
}
