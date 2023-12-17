

namespace HerkesYazarOlsun.Model.Utils
{
    public class ServiceResult : IResult
    {
        public FaultCodes FaultCode { get; set; }

        public MessageResultState State { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }

        public ServiceResult()
        {

        }

        public ServiceResult(string message = "", MessageResultState state = MessageResultState.SUCCESS, FaultCodes faultCode = FaultCodes.Unset)
            : base()
        {
            this.Message = message;
            this.State = state;
            this.FaultCode = faultCode;
        }
    }

    public class ServiceResult<T> : IDataResult<T>
    {
        public FaultCodes FaultCode { get; set; }

        public MessageResultState State { get; set; }

        public string Message { get; set; }

        public T Result { get; set; }

        public int ResultCount { get; set; }

        public ServiceResult()
        {

        }

        public ServiceResult(string message = "", MessageResultState state = MessageResultState.SUCCESS, FaultCodes faultCode = FaultCodes.Unset)
            : base()
        {
            this.Message = message;
            this.State = state;
            this.FaultCode = faultCode;
        }
    }

    public enum FaultCodes
    {
        Unset = 0
    }

    public enum MessageResultState
    {
        ERROR = 0,
        SUCCESS = 1,
        FAIL = 2,
        WARNING = 3,
        INFO = 4
    }
}
