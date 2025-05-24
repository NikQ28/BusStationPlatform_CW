namespace BusStationPlatform.Domain.Entities
{
    /// <summary>
    /// Представляет счет для пользователя.
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Уникальный идентификатор счета.
        /// </summary>
        public int InvoiceId { get; set; }

        /// <summary>
        /// Сумма счета.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Дата и время создания счета.
        /// </summary>
        public DateTime CreationDatetime { get; set; }

        /// <summary>
        /// Статус оплаты счета.
        /// </summary>
        public bool IsPaid { get; set; }
        
        /// <summary>
        /// Указывает, истек ли срок оплаты счета.
        /// </summary>
        public bool IsExpired { get; set; }
    }
}
