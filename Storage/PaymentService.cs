using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.EntitiesDTO;
using BusStationPlatform.Storage;
using Microsoft.EntityFrameworkCore;

namespace BusStationPlatform.Domains.Services
{
    public class PaymentService(ApplicationContext _context) : IPaymentService
    {
        public async Task<Payment> GetPaymentByIDAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
                return null;
            return payment;
        }

        public async Task<Payment> CreatePaymentAsync(PaymentDTO paymentDTO)
        {
            var payment = paymentDTO.ToPayment();
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> UpdatePaymentAsync(Payment updatedPayment)
        {
            var payment = await _context.Payments.FindAsync(updatedPayment.PaymentID);
            if (payment == null)    
                return null;
            _context.Update(updatedPayment);
            await _context.SaveChangesAsync();
            return updatedPayment;
        }

        public async Task DeletePaymentAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
