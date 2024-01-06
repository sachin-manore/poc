

namespace Libraries.Common.Exceptions
{
    public class CustomException : Exception
    {
        public int? ErrorCode { get; private set; }
        public string ErrorMessage { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public Dictionary<string, string> ErrorDetailList { get; private set; }

        /// <summary>
        /// Creates a new customException.
        /// </summary>
        public CustomException()
            : base("custom Exception")
        {
        }

        /// <summary>
        /// Creates a new Exception.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorMessage">The error message.</param>
        public CustomException(int? errorCode, string errorMessage)
            : base(errorMessage ?? "Exception with errorCode" + errorCode.GetValueOrDefault().ToString())
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        
    }
}
