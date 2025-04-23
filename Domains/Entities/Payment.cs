namespace BusStationPlatform.Domains.Entities
{
    /// <summary>
    /// Представляет платеж, связанный с пользователем.
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Уникальный идентификатор платежа.
        /// </summary>
        public int PaymentID { get; set; }

        /// <summary>
        /// Идентификатор пользователя, связанного с платежом.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Идентификатор счета, связанного с платежом.
        /// </summary>
        public int InvoiceID { get; set; }

        /// <summary>
        /// Сумма платежа.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Метод платежа (например, кредитная карта, наличные и т.д.).
        /// </summary>
        public string? Method { get; set; }

        /// <summary>
        /// Дата и время выполнения платежа.
        /// </summary>
        public DateTime PaymentDatetime { get; set; }
    }
}
