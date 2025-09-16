using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperPayIntegration.Shared
{
    public static class HyperPayMessages
    {
        public const string CheckoutCreated = "Checkout created successfully";
        public const string PaymentStatusRetrieved = "Payment status retrieved successfully";
        public const string InvalidMethod = "Payment method must be Mada or VisaMaster";
        public const string InvalidCheckoutId = "Checkout ID is required";
        public const string CheckoutFailed = "Checkout request failed";
        public const string StatusFailed = "Failed to fetch payment status";
        public const string MethodRequired = "Payment method must be Mada or VisaMaster";
        public const string PaymentStatusFailed = "Failed to get payment status";
    }
}
