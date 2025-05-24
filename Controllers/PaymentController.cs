using Microsoft.AspNetCore.Mvc;

using BusStationPlatform.Domain.Entities;
using BusStationPlatform.Domain.Services.Contracts;
using BusStationPlatform.Domain.Services.Contracts.Repositories;

namespace BusStationPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController(IUserRepository userRepository, IPaymentService paymentService, IEmailService emailService,
        ISendTicketService sendTicketService) : ControllerBase
    {
        [HttpPost("pay-by-credit-card")]
        public async Task<IActionResult> PayByCreditCardAsync(int invoiceId, CancellationToken token)
        {
            if (invoiceId <= 0) return BadRequest("Неверный идентификатор оплаты");
            var (error, payment) = await paymentService.PayByCreditCardAsync(invoiceId, token);
            if (!string.IsNullOrWhiteSpace(error) || payment == null)
                return error == "Билет не найден" ? NotFound(error) : BadRequest(error);
            
            var user = await userRepository.GetUserByIdAsync(payment.UserId, token);
            await emailService.SendEmailPaymemtReceiptAsync(user.Email, payment, token);
            await sendTicketService.SendTicketsAsync(user.Email, payment, token);
            
            return Ok(payment);

        }

        [HttpPost("pay-by-system-fast-payment")]
        public async Task<IActionResult> PayBySystemFastPaymentsAsync(int invoiceId, CancellationToken token)
        {
            if (invoiceId <= 0) return BadRequest("Неверный идентификатор оплаты");
            var (error, payment) = await paymentService.PayBySystemFastPaymentsAsync(invoiceId, token);
            if (!string.IsNullOrWhiteSpace(error) || payment == null)
                return error == "Билет не найден" ? NotFound(error) : BadRequest(error);
            
            var user = await userRepository.GetUserByIdAsync(payment.UserId, token);
            await emailService.SendEmailPaymemtReceiptAsync(user.Email, payment, token);
            await sendTicketService.SendTicketsAsync(user.Email, payment, token);

            return Ok(payment);

        }

        [HttpPost("pay-by-electronic-wallet")]
        public async Task<IActionResult> PayByElectronicWalletAsync(int invoiceId, CancellationToken token)
        {
            if (invoiceId <= 0) return BadRequest("Неверный идентификатор оплаты");
            var (error, payment) = await paymentService.PayByElectronicWalletAsync(invoiceId, token);
            if (!string.IsNullOrWhiteSpace(error) || payment == null)
                return error == "Билет не найден" ? NotFound(error) : BadRequest(error);

            var user = await userRepository.GetUserByIdAsync(payment.UserId, token);
            await emailService.SendEmailPaymemtReceiptAsync(user.Email, payment, token);
            await sendTicketService.SendTicketsAsync(user.Email, payment, token);

            return Ok(payment);
        }
    }
}
