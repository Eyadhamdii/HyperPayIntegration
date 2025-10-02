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
        private readonly HyperPayOptions _options;
        public PaymentAppService(HyperPayClient client,IPaymentTransactionRepository transactionRepository,IOptions<HyperPayOptions> opt)
        {
            _client = client;
            _transactionRepository = transactionRepository;
            _options = opt.Value;
        }
        public async Task<ApiResponse<CreateCheckoutResponseDto>> CompletePaymentAsync(CreateCheckoutInput input)
        {
            var response = await _client.CompletePaymentAsync(input);

            if (!response.Success)
                return response;

            if (_options.EnableDatabasePersistence)
            {
                var transaction = new PaymentTransaction
                {
                    CheckoutId = response.Data.Id,
                    EntityId = _options.EntityId,
                    MerchantTransactionId = input.MerchantTransactionId,
                    Method = input.Method,
                    Amount = input.Amount,
                    Currency = input.Currency,
                    Status = PaymentStatus.Pending,
                    TransactionDate = DateTime.UtcNow
                };

                await _transactionRepository.InsertAsync(transaction);
            }

            return response;
        }

        public async Task<ApiResponse<PaymentStatusResponseDto>> CheckoutAsync(string id)
        {
            if (!_options.EnableDatabasePersistence)
            {
                return await _client.CheckoutAsync(id, _options.EntityId);
            }

            var transaction = await _transactionRepository.FindByCheckoutIdAsync(id);
            if (transaction == null)
                return ApiResponse<PaymentStatusResponseDto>.Fail(
                    HyperPayErrorCode.InvalidMethod,
                    HyperPayMessages.StatusFailed);

            var response = await _client.CheckoutAsync(id, _options.EntityId);
            var result = response.Data;

            if (!response.Success)
            {
                transaction.Status = PaymentStatus.Failed;
                transaction.ResultDescription = response.Message;
                await _transactionRepository.UpdateAsync(transaction);
                return response;
            }

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
