using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.EntitiesDTO;

namespace BusStationPlatform.Domains.Services
{
    public interface IPaymentService
    {
        public Task<Payment> GetPaymentByIDAsync(int id);
        public Task<Payment> CreatePaymentAsync(PaymentDTO paymentDTO);
        public Task<Payment> UpdatePaymentAsync(Payment payment);
        public Task DeletePaymentAsync(int id);
    }
}
