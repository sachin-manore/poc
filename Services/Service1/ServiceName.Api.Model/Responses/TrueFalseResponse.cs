using Libraries.Abstract.Models;

namespace ServiceName.Api.Model.Responses
{
    /// <summary>
    /// True False Response
    /// </summary>
    public class TrueFalseResponse
    {
        /// <summary>
        /// Error Detail
        /// </summary>
        public ErrorDetail ErrorDetail { get; set; } = new ErrorDetail();
        /// <summary>
        /// IsSuccess
        /// </summary>
        public bool IsSuccess { get; set; }
    }
}
