namespace MUSbooking.Domain.Entity
{
    /// <summary>
    ///     Оборудование.
    /// </summary>
    public class Equipment
    {
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
        public IList<Order>? Orders { get; private set; }
    }
}
