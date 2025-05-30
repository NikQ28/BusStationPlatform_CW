﻿using BusStationPlatform.Domain.Entities;

namespace BusStationPlatform.Domain.Services.Contracts.Repositories
{
    public interface IPaymentRepository
    {
        public Task<List<Payment>?> GetPaymentsByUserAsync(User user, CancellationToken token);

        public Task<Payment?> GetPaymentByInvoiceAsync(Invoice invoice, CancellationToken token);

        public Task<Payment?> CreatePaymentAsync(Payment newPayment, CancellationToken token);
    }
}
