using BusStationPlatform.Domain.Entities;
using BusStationPlatform.Domain.Services.Contracts.Repositories;

namespace BusStationPlatform.Domain.Services.UseCases
{
    public class InvoiceExpirationCheckService(IServiceScopeFactory serviceScopeFactory) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var scope = serviceScopeFactory.CreateScope();
                var invoiceRepository = scope.ServiceProvider.GetRequiredService<IInvoiceRepository>();
                var expiredInvoices = await invoiceRepository.GetExpiredInvoicesAsync(token);

                if (expiredInvoices == null || expiredInvoices.Count == 0)
                {
                    await Task.Delay(TimeSpan.FromMinutes(1), token);
                    continue;
                }
                await ProcessExpiredInvoices(expiredInvoices, serviceScopeFactory, token);
                await Task.Delay(TimeSpan.FromMinutes(1), token);
            }
        }

        private static async Task ProcessExpiredInvoices(List<Invoice> expiredInvoices, IServiceScopeFactory serviceScopeFactory, CancellationToken token)
        {
            var scope = serviceScopeFactory.CreateScope();
            var ticketRepository = scope.ServiceProvider.GetRequiredService<ITicketRepository>();
            var invoiceRepository = scope.ServiceProvider.GetRequiredService<IInvoiceRepository>();

            foreach (var invoice in expiredInvoices)
            {
                var tickets = await ticketRepository.GetTicketsByInvoiceAsync(invoice, token);
                if (tickets == null) continue;
                await ReturnNotPaidSeats(tickets, serviceScopeFactory, token);
                invoice.IsExpired = true;
                await invoiceRepository.UpdateInvoiceAsync(invoice, token);
            }
        }

        private static async Task ReturnNotPaidSeats(List<Ticket> tickets, IServiceScopeFactory serviceScopeFactory, CancellationToken token)
        {
            var scope = serviceScopeFactory.CreateScope();
            var seatRepository = scope.ServiceProvider.GetRequiredService<ISeatRepository>();

            foreach (var ticket in tickets)
            {
                var occupiedSeat = await seatRepository.GetOccupiedSeatByTicketAsync(ticket, token);
                if (occupiedSeat == null) continue;
                await seatRepository.DeleteOccupiedSeatAsync(occupiedSeat.OccupiedSeatId, token);
            }
        }
    }
}
