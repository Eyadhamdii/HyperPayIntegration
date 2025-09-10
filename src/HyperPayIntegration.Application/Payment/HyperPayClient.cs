using HyperPayIntegration.DTOS;
using HyperPayIntegration.Shared;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HyperPayIntegration.Payment
{
    public class HyperPayClient
    {
        private readonly HttpClient _http;
        private readonly HyperPayOptions _opt;
        private readonly JsonSerializerOptions _json;

        public HyperPayClient(HttpClient http, IOptions<HyperPayOptions> opt)
        {
            _http = http;
            _opt = opt.Value;
            _json = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<ApiResponse<CreateCheckoutResponseDto>> CompletePaymentAsync(CreateCheckoutInput input)
        {
            if (input.Method != HyperPayMethod.Mada && input.Method != HyperPayMethod.VisaMaster)
            {
                return ApiResponse<CreateCheckoutResponseDto>.Fail(
                    HyperPayErrorCode.InvalidMethod,
                    HyperPayMessages.MethodRequired);
            }

            var entityId = input.Method == HyperPayMethod.Mada
                ? _opt.MadaEntityId
                : _opt.VisaMasterEntityId;

            var form = BuildCheckoutForm(input, entityId);

            var content = new FormUrlEncodedContent(form);
            var resp = await _http.PostAsync(HyperPayEndpoints.Checkouts, content);
            var json = await resp.Content.ReadAsStringAsync();

            if (!resp.IsSuccessStatusCode)
            {
                return ApiResponse<CreateCheckoutResponseDto>.Fail(
                    MapHttpError(resp.StatusCode),
                    HyperPayMessages.CheckoutFailed,
                    json);
            }

            var dto = JsonSerializer.Deserialize<CreateCheckoutResponseDto>(json, _json);
            return ApiResponse<CreateCheckoutResponseDto>.Ok(dto!, HyperPayMessages.CheckoutCreated);
        }
        public async Task<ApiResponse<PaymentStatusResponseDto>> CheckoutAsync(string id, HyperPayMethod method)
        {
            if (string.IsNullOrWhiteSpace(id))
                return ApiResponse<PaymentStatusResponseDto>.Fail(
                    HyperPayErrorCode.InvalidRequest,
                    HyperPayMessages.InvalidCheckoutId);

            var entityId = method == HyperPayMethod.Mada ? _opt.MadaEntityId : _opt.VisaMasterEntityId;

            var url = string.Format(HyperPayEndpoints.CheckoutPayment,
                        Uri.EscapeDataString(id),
                        Uri.EscapeDataString(entityId));

            using var resp = await _http.GetAsync(url);
            var json = await resp.Content.ReadAsStringAsync();

            if (!resp.IsSuccessStatusCode)
                return ApiResponse<PaymentStatusResponseDto>.Fail(
                    MapHttpError(resp.StatusCode),
                    HyperPayMessages.StatusFailed,
                    json);

            var dto = JsonSerializer.Deserialize<PaymentStatusResponseDto>(json, _json);
            return ApiResponse<PaymentStatusResponseDto>.Ok(dto!, HyperPayMessages.PaymentStatusRetrieved);
        }
        private static void AddIf(Dictionary<string, string> dict, string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(value)) dict[key] = value;
        }
        private Dictionary<string, string> BuildCheckoutForm(CreateCheckoutInput input, string entityId)
        {
            var form = new Dictionary<string, string>
            {
                ["entityId"] = entityId,
                ["amount"] = input.Amount.ToString(CultureInfo.InvariantCulture),
                ["currency"] = input.Currency,
                ["paymentType"] = "DB"
            };

            AddIf(form, "merchantTransactionId", input.MerchantTransactionId);
            AddIf(form, "customer.email", input.Email);
            AddIf(form, "billing.street1", input.BillingStreet1);
            AddIf(form, "billing.city", input.BillingCity);
            AddIf(form, "billing.state", input.BillingState);
            AddIf(form, "billing.country", input.BillingCountry);
            AddIf(form, "billing.postcode", input.BillingPostcode);

            if (_opt.UseTestMode && input.Method != HyperPayMethod.Mada)
                form["testMode"] = "EXTERNAL";

            return form;
        }
        private static HyperPayErrorCode MapHttpError(System.Net.HttpStatusCode status)
        {
            return status switch
            {
                System.Net.HttpStatusCode.Unauthorized => HyperPayErrorCode.Unauthorized,
                System.Net.HttpStatusCode.Forbidden => HyperPayErrorCode.Forbidden,
                System.Net.HttpStatusCode.BadRequest => HyperPayErrorCode.InvalidRequest,
                _ => HyperPayErrorCode.Unknown
            };
        }
    }
}
