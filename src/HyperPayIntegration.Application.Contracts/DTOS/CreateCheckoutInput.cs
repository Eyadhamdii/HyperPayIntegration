using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperPayIntegration.DTOS
{
    public class CreateCheckoutInput
    {
        public decimal Amount { get; set; }

        [Required]
        public string Currency { get; set; } = "SAR";

        [Required]
        public HyperPayMethod Method { get; set; }

        public string Email { get; set; }
        public string BillingStreet1 { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; } = "SA";
        public string BillingPostcode { get; set; }
        public string MerchantTransactionId { get; set; }
    }
    public class HyperPayResultDto
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class CreateCheckoutResponseDto
    {
        public string Id { get; set; }
        public string EntityId { get; set; }
        public HyperPayResultDto Result { get; set; }
        public string BuildNumber { get; set; }
        public string Timestamp { get; set; }
        public string Ndc { get; set; }
    }

    public class PaymentStatusResponseDto
    {
        public string Id { get; set; }
        public string PaymentType { get; set; }
        public string PaymentBrand { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string Descriptor { get; set; }
        public HyperPayResultDto Result { get; set; }
        public CardDto Card { get; set; }
        public CustomerDto Customer { get; set; }
        public ThreeDSecureDto ThreeDSecure { get; set; }
        public RiskDto Risk { get; set; }
        public string BuildNumber { get; set; }
        public string Timestamp { get; set; }
        public string Ndc { get; set; }
    }

    public class CardDto
    {
        public string Bin { get; set; }
        public string Last4Digits { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
    }

    public class CustomerDto
    {
        public string Ip { get; set; }
    }

    public class ThreeDSecureDto
    {
        public string Eci { get; set; }
    }

    public class RiskDto
    {
        public string Score { get; set; }
    }
}
