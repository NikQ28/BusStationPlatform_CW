using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

using BusStationPlatform.Domain.Entities;
using BusStationPlatform.Domain.Services.Contracts;

namespace BusStationPlatform.Domain.Services.UseCases
{
    public class EmailService(IConfiguration configuration) : IEmailService
    {
        private readonly string smtpEmail = configuration.GetValue<string>("smtpEmail");
        private readonly string smtpPassword = configuration.GetValue<string>("smtpPassword");

        public async Task SendEmailAboutPasswordChangeAsync(string email, string password, CancellationToken token)
        {
            string message = 
                $"Ваш пароль был изменён\nНовый пароль: {password}.\n\n" +
                $"С уважением,\nАдминистрация сайта по продаже билетов автовокзала.\n\n" +
                $"Bus Station Platform, {DateTime.Now.Year}";

            var emailMessage = new MimeMessage();
            emailMessage.To.Add(new MailboxAddress("Пользователь сайта Bus Station Platform", email));
            emailMessage.Subject = "Изменение сведений учётной записи";

            await SendEmailAsync(emailMessage, message, token);
        }

        public async Task SendEmailAboutRegistrationAsync(string email, string password, CancellationToken token)
        {
            string message =
                $"Здравствуйте, пользователь. Спасибо за регистрацию на сайте Bus Station Platform\n\n" +
                $"Ваши данные для входа:\nАдрес электронной почты: {email}\nПароль: {password}\n\n" +
                $"Bus Station Platform, {DateTime.Now.Year}";

            var emailMessage = new MimeMessage();
            emailMessage.To.Add(new MailboxAddress("Пользователь сайта Bus Station Platform", email));
            emailMessage.Subject = "Регистрация нового пользователя";

            await SendEmailAsync(emailMessage, message, token);
        }

        public async Task SendEmailPaymemtReceiptAsync(string email, Payment payment, CancellationToken token)
        {
            string message =
                $"Ваша покупка на онлайн-платформе Bus Station Platform завершена.\n\n" +
                $"Это письмо является квитанцией об оплате.\n\nНомер платежа: {payment.PaymentId}\n" +
                $"Итоговая сумма платежа: {payment.Amount}\nСпособ оплаты: {payment.Method}\n" +
                $"Дата проведения оплаты: {payment.PaymentDatetime}\n\n" +
                $"С уважением,\nАдминистрация сайта по продаже билетов автовокзала.\n\n" +
                $"Bus Station Platform, {DateTime.Now.Year}"; ;

            var emailMessage = new MimeMessage();
            emailMessage.To.Add(new MailboxAddress("Пользователь сайта Bus Station Platform", email));
            emailMessage.Subject = "Благодарим за покупку на сайте Bus Station Platform";

            await SendEmailAsync(emailMessage, message, token);
        }

        private async Task SendEmailAsync(MimeMessage emailMessage, string message, CancellationToken token)
        {
            emailMessage.From.Add(new MailboxAddress("Администрация сайта Bus Station Platform", smtpEmail));
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text = message };

            var client = new SmtpClient();
            await client.ConnectAsync("smtp.yandex.ru", 587, SecureSocketOptions.StartTls, token);
            await client.AuthenticateAsync(smtpEmail, smtpPassword, token);
            await client.SendAsync(emailMessage, token);
            await client.DisconnectAsync(true, token);
        }
    }
}
