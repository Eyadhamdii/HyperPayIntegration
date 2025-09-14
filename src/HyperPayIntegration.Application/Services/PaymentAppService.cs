using HyperPayIntegration.DTOS;
using HyperPayIntegration.Payment;
using HyperPayIntegration.Repository;
using HyperPayIntegration.Shared;
using Microsoft.Extensions.Options;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HyperPayIntegration.Services
{
    public class PaymentAppService : ApplicationService, IPaymentAppService
    {
        private readonly HyperPayClient _client;
        private readonly IPaymentTransactionRepository _transactionRepository;
        private readonly HyperPayOptions _opt;
        public PaymentAppService(HyperPayClient client,IPaymentTransactionRepository transactionRepository,IOptions<HyperPayOptions> opt)
        {
            _client = client;
            _transactionRepository = transactionRepository;
            _opt = opt.Value;
        }
        public async Task<ApiResponse<CreateCheckoutResponseDto>> CompletePaymentAsync(CreateCheckoutInput input)
        {
            var response = await _client.CompletePaymentAsync(input);

            if (!response.Success)
                return response;

            var entityId = input.Method == HyperPayMethod.Mada
                ? _opt.MadaEntityId
                : _opt.VisaMasterEntityId;

            var transaction = new PaymentTransaction
            {
                CheckoutId = response.Data.Id,
                EntityId = entityId,
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
            var transaction = await _transactionRepository.FindByCheckoutIdAsync(id);
            if (transaction == null)
                return ApiResponse<PaymentStatusResponseDto>.Fail(
                    HyperPayErrorCode.InvalidMethod,
                    HyperPayMessages.StatusFailed);

            var response = await _client.CheckoutAsync(id, transaction.EntityId);

            if (!response.Success)
                return response;

            var result = response.Data;
            transaction.Status = MapHyperPayStatus(result.Result.Code);
            transaction.ResultCode = result.Result.Code;
            transaction.ResultDescription = result.Result.Description;
            transaction.TransactionDate = DateTime.UtcNow;
            transaction.PaymentBrand = result.PaymentBrand;
            transaction.Descriptor = result.Descriptor;
            transaction.CustomerIp = result.Customer?.Ip;
            transaction.CardBin = result.Card?.Bin;
            transaction.CardLast4 = result.Card?.Last4Digits;
            transaction.CardExpiryMonth = result.Card?.ExpiryMonth;
            transaction.CardExpiryYear = result.Card?.ExpiryYear;
            transaction.Ndc = result.Ndc;
            transaction.BuildNumber = result.BuildNumber;

            await _transactionRepository.UpdateAsync(transaction);

            return response;
            
        }


        private PaymentStatus MapHyperPayStatus(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return PaymentStatus.Pending;

            if (Regex.IsMatch(code, HyperPayRegex.Success1) ||
                Regex.IsMatch(code, HyperPayRegex.Success2))
                return PaymentStatus.Success;

            if (Regex.IsMatch(code, HyperPayRegex.Pending1) ||
                Regex.IsMatch(code, HyperPayRegex.Pending2))
                return PaymentStatus.Pending;

            return PaymentStatus.Failed;
        }

    }
}
