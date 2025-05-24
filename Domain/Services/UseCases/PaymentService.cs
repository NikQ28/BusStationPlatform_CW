using BusStationPlatform.Domain.Entities;
using BusStationPlatform.Domain.Services.Contracts;
using BusStationPlatform.Domain.Services.Contracts.Repositories;

namespace BusStationPlatform.Domain.Services.UseCases
{
    public class PaymentService(IInvoiceRepository invoiceRepository, IPaymentRepository paymentRepository,
        ITicketRepository ticketRepository, IPassengerRepository passengerRepository) : IPaymentService
    {
        public async Task<(string? error, Payment? payment)> PayByCreditCardAsync(int invoiceId, CancellationToken token) =>
            await PayByMethodAsync(invoiceId, "CreditCard", token);

        public async Task<(string? error, Payment? payment)> PayBySystemFastPaymentsAsync(int invoiceId, CancellationToken token) =>
            await PayByMethodAsync(invoiceId, "SystemFastPayments", token);

        public async Task<(string? error, Payment? payment)> PayByElectronicWalletAsync(int invoiceId, CancellationToken token) =>
            await PayByMethodAsync(invoiceId, "ElectronicWallet", token);

        private async Task<(string? error, Payment? payment)> PayByMethodAsync(int invoiceId, string method, CancellationToken token)
        {
            var invoice = await invoiceRepository.GetInvoiceByIdAsync(invoiceId, token);
            if (invoice == null) return ("Счёт не найден", null);
            if (invoice.IsExpired) return ("Время на оплату счёта истекло", null);
            if (invoice.IsPaid) return ("Счёт уже олачен", null);

            invoice.IsPaid = true;
            await invoiceRepository.UpdateInvoiceAsync(invoice, token);

            var tickets = await ticketRepository.GetTicketsByInvoiceAsync(invoice, token);
            if (tickets == null || tickets.Count == 0) return ("Ошибка при создании счёта. Билеты не найдены", null);

            var passengerId = tickets.First().PassengerId;
            var passenger = await passengerRepository.GetPassengerByIdAsync(passengerId, token);
            if (passenger == null) return ("Ошибка при создании счёта. Пассажир, забронировавший билет не найден", null);

            var payment = new Payment
            {
                UserId = passenger.UserId,
                InvoiceId = invoiceId,
                Amount = invoice.Amount,
                Method = method,
                PaymentDatetime = DateTime.Now
            };

            return (null, await paymentRepository.CreatePaymentAsync(payment, token));
        }
    }
}
