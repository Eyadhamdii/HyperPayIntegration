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
    
}
