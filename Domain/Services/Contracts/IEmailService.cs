using BusStationPlatform.Domain.Entities;

namespace BusStationPlatform.Domain.Services.Contracts
{
    /// <summary>
    /// Интерфейс для отправки электронных писем.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Асинхронно отправляет электронное письмо о смене пароля.
        /// </summary>
        /// <param name="email">Адрес электронной почты получателя.</param>
        /// <param name="password">Новый пароль для отправки.</param>
        /// <param name="token">Токен отмены для управления асинхронной операцией.</param>
        /// <returns>Задача, представляющая асинхронную операцию.</returns>
        public Task SendEmailAboutPasswordChangeAsync(string email, string password, CancellationToken token);

        /// <summary>
        /// Асинхронно отправляет электронное письмо о регистрации.
        /// </summary>
        /// <param name="email">Адрес электронной почты получателя.</param>
        /// <param name="password">Пароль для отправки.</param>
        /// <param name="token">Токен отмены для управления асинхронной операцией.</param>
        /// <returns>Задача, представляющая асинхронную операцию.</returns>
        public Task SendEmailAboutRegistrationAsync(string email, string password, CancellationToken token);

        /// <summary>
        /// Асинхронно отправляет электронное письмо с квитанцией о платеже.
        /// </summary>
        /// <param name="email">Адрес электронной почты получателя.</param>
        /// <param name="payment">Объект платежа для отправки.</param>
        /// <param name="token">Токен отмены для управления асинхронной операцией.</param>
        /// <returns>Задача, представляющая асинхронную операцию.</returns>
        public Task SendEmailPaymemtReceiptAsync(string email, Payment payment, CancellationToken token);
    }
}
