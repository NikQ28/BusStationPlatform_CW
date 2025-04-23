using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BusStationPlatform.Storage
{
    public class PaymentRepository(BusStationPlatformContext _context) : IPaymentRepository
    {
        public async Task<List<Payment>?> GetPaymentsByUserAsync(User user)
        {
            var paymentsID = await GetPaymentsIDByUserAsync(user);
            return await _context.Payment.Where(payment => paymentsID.Contains(payment.PaymentID)).ToListAsync();
        }

        public async Task<List<int>?> GetPaymentsIDByUserAsync(User user) =>
            await _context.Payment
                .Where(payment => payment.UserID == user.UserID)
                .Select(payment => payment.PaymentID)
                .ToListAsync();
        public async Task<Payment?> GetPaymentByInvoiceAsync(Invoice invoice) =>
            await _context.Payment.FirstOrDefaultAsync(payment => payment.InvoiceID == invoice.InvoiceID);

        public async Task<Payment?> CreatePaymentAsync(Payment newPayment)
        {
            _context.Payment.Add(newPayment);
            await _context.SaveChangesAsync();
            return newPayment;
        }
    }
}
