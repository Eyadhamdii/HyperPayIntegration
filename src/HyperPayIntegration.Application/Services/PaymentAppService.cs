using HyperPayIntegration.DTOS;
using HyperPayIntegration.Payment;
using HyperPayIntegration.Repository;
using HyperPayIntegration.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HyperPayIntegration.Services
{
    public class PaymentAppService : ApplicationService, IPaymentAppService
    {
        private readonly HyperPayClient _client;
        private readonly IPaymentTransactionRepository _transactionRepository;

        public PaymentAppService(HyperPayClient client, IPaymentTransactionRepository transactionRepository)
        {
            _client = client;
            _transactionRepository = transactionRepository;
        }

        public async Task<ApiResponse<CreateCheckoutResponseDto>> CompletePaymentAsync(CreateCheckoutInput input)
        {
            var response = await _client.CompletePaymentAsync(input);

            if (!response.Success)
                return response;

            var transaction = new PaymentTransaction
            {
                CheckoutId = response.Data.Id,
                MerchantTransactionId = input.MerchantTransactionId,
                Method = input.Method,
                Amount = input.Amount,
                Currency = input.Currency,
                Status = PaymentStatus.Pending,
                TransactionDate = DateTime.UtcNow
            };

            await _transactionRepository.InsertAsync(transaction);

            return response;
        }

        public async Task<ApiResponse<PaymentStatusResponseDto>> CheckoutAsync(string id, HyperPayMethod method)
        {
            var response = await _client.CheckoutAsync(id, method);

            if (!response.Success)
                return response;

            var transaction = await _transactionRepository.FindByCheckoutIdAsync(id);
            if (transaction != null)
            {
                transaction.Status = MapHyperPayStatus(response.Data.Result.Code);
                transaction.ResultCode = response.Data.Result.Code;
                transaction.ResultDescription = response.Data.Result.Description;
                transaction.TransactionDate = DateTime.UtcNow;

                await _transactionRepository.UpdateAsync(transaction);
            }

            return response;
        }

        private PaymentStatus MapHyperPayStatus(string code)
        {
            // Simplified mapping
            if (string.IsNullOrEmpty(code))
                return PaymentStatus.Pending;

            if (code.StartsWith("000.000") || code.StartsWith("000.100.1") || code.StartsWith("000.3"))
                return PaymentStatus.Success;

            if (code.StartsWith("000.200"))
                return PaymentStatus.Pending;

            return PaymentStatus.Failed;
        }

    }
}
