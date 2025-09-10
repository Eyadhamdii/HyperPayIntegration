namespace HyperPayIntegration.Shared
{
    public class ApiResponse<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; } = string.Empty;
        public HyperPayErrorCode ErrorCode { get; private set; }
        public T? Data { get; private set; }
        public string? RawResponse { get; private set; }

        private ApiResponse(bool success, string message, HyperPayErrorCode errorCode, T? data, string? raw = null)
        {
            Success = success;
            Message = message;
            ErrorCode = errorCode;
            Data = data;
            RawResponse = raw;
        }

        public static ApiResponse<T> Ok(T data, string message = "Success") =>
            new ApiResponse<T>(true, message, HyperPayErrorCode.None, data);

        public static ApiResponse<T> Fail(HyperPayErrorCode code, string message, string? raw = null) =>
            new ApiResponse<T>(false, message, code, default, raw);
    }
    public enum HyperPayErrorCode
    {
        None = 0,
        InvalidMethod,
        InvalidRequest,
        CheckoutFailed,
        StatusFailed,
        Unauthorized,
        Forbidden,
        Unknown
    }
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
    public static class HyperPayEndpoints
    {
        public const string Checkouts = "checkouts";
        public const string CheckoutPayment = "checkouts/{0}/payment?entityId={1}";
    }
}
