namespace HerkesYazarOlsun.Model
{
    public class ServiceResponse<T>(T result)
    {
        public T Result { get; set; } = result;

        public string? Message { get; set; }

        public bool IsSuccess { get; set; } = true;

        public int StatusCode { get; set; } = 200;
         

        public static ServiceResponse<T> SuccessResponse(T data, string message = "Success")
        {
            return new ServiceResponse<T>(data)
            {
                IsSuccess = true,
                Message = message,
            };
        }

        public static ServiceResponse<T> ErrorResponse(string message)
        {
            return new ServiceResponse<T>((dynamic)null)
            {
                IsSuccess = false,
                Message = message
            };
        }
    }

}
