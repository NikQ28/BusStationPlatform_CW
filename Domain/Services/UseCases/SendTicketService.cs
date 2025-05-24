using MailKit.Security;
using MailKit.Net.Smtp;
using MimeKit;

using BusStationPlatform.Domain.Entities;
using BusStationPlatform.Domain.Services.Contracts.Repositories;
using BusStationPlatform.Domain.Services.Contracts;

namespace BusStationPlatform.Domain.Services.UseCases
{
    public class SendTicketService(IConfiguration configuration ,IInvoiceRepository invoiceRepository, ITicketRepository ticketRepository,
        IPassengerRepository passengerRepository, IRouteRepository routeRepository, ISeatRepository seatRepository)
        : ISendTicketService
    {
        private readonly string smtpEmail = configuration.GetValue<string>("smtpEmail");
        private readonly string smtpPassword = configuration.GetValue<string>("smtpPassword");

        public async Task SendTicketsAsync(string email, Payment payment, CancellationToken token)
        {
            var invoice = await invoiceRepository.GetInvoiceByIdAsync(payment.InvoiceId, token);
            if (invoice == null) return;

            var tickets = await ticketRepository.GetTicketsByInvoiceAsync(invoice, token);
            if (tickets == null) return;

            var emailMessage = new MimeMessage();
            emailMessage.To.Add(new MailboxAddress("Пользователь сайта Bus Station Platform", email));
            emailMessage.Subject = "Вы успешно оплатили билет на автобус";

            foreach (var ticket in tickets)
            {
                var message = await CreateTicketAsync(ticket, token);
                await SendEmailAsync(emailMessage, message, token);
            }
        }

        private async Task<string> CreateTicketAsync(Ticket ticket, CancellationToken token)
        {
            var invoice = await invoiceRepository.GetInvoiceByIdAsync(ticket.InvoiceId, token);
            var passenger = await passengerRepository.GetPassengerByIdAsync(ticket.PassengerId, token);
            var route = await routeRepository.GetRouteByIdAsync(ticket.RouteId, token);
            var occupiedSeat = await seatRepository.GetOccupiedSeatByTicketAsync(ticket, token);
            var seat = await seatRepository.GetSeatByIdAsync(occupiedSeat.SeatId, token);

            TimeSpan timeInTraver = route.ArrivalDatetime - route.DepartureDatetime;

            return
                $"Bus Station Platform\n\nМаршрутная квитанция №{ticket.TicketId}\n\n" +
                $"Дата покупки: {invoice.CreationDatetime:g}\nНомер маршрута: {route.RouteId}\n" +
                $"Маршрут: {route.DeparturePoint} - {route.ArrivalPoint}\n\n" +
                $"Прямой беспересадочный рейс\nОтправление: {route.DeparturePoint}, {route.DepartureDatetime}\n" +
                $"Прибытие: {route.ArrivalPoint}, {route.ArrivalDatetime}\n" +
                $"Время в пути: {timeInTraver.Hours} часов {timeInTraver.Minutes} минут\n\n" +
                $"Данные пассажира\nФамилия: {passenger.Surname}\nИмя: {passenger.Name}\n" +
                $"Дата рождения: {passenger.BirthDate:d}\nПаспортные данные: {passenger.Passport}\n" +
                $"Место: {seat.SeatNumber}\nЦена: {route.Price}\n\n" +
                $"Счасливого пути!\n\nС уважением,\nАдминистрация сайта по продаже билетов автовокзала.\n\n" +
                $"Bus Station Platform, {DateTime.Now.Year}";
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
