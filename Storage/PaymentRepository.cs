using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.Services.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusStationPlatform.Storage
{
    public class PaymentRepository(BusStationPlatformContext context) : IPaymentRepository
    {
        public async Task<List<Payment>?> GetPaymentsByUserAsync(User user, CancellationToken token)
        {
            var paymentsIds = await GetPaymentsIdsByUserAsync(user, token);
            if (paymentsIds == null) return null;
            return await context.Payment.Where(payment => paymentsIds.Contains(payment.PaymentId)).ToListAsync(token);
        }

        public async Task<List<int>?> GetPaymentsIdsByUserAsync(User user, CancellationToken token) =>
            await context.Payment
                .Where(payment => payment.UserId == user.UserId)
                .Select(payment => payment.PaymentId)
                .ToListAsync(token);

        public async Task<Payment?> GetPaymentByInvoiceAsync(Invoice invoice, CancellationToken token) =>
            await context.Payment.FirstOrDefaultAsync(payment => payment.InvoiceId == invoice.InvoiceId, token);

        public async Task<Payment?> CreatePaymentAsync(Payment newPayment, CancellationToken token)
        {
            context.Payment.Add(newPayment);
            await context.SaveChangesAsync(token);
            return newPayment;
        }
    }
}
