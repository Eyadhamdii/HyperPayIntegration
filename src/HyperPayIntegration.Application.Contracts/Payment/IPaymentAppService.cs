using HyperPayIntegration.DTOS;
using HyperPayIntegration.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HyperPayIntegration.Payment
{
    public interface IPaymentAppService : IApplicationService
    {
        Task<ApiResponse<CreateCheckoutResponseDto>> CompletePaymentAsync(CreateCheckoutInput input);
        Task<ApiResponse<PaymentStatusResponseDto>> CheckoutAsync(string id, HyperPayMethod method);
    }
}
