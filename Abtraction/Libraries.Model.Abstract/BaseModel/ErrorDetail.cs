
namespace Libraries.Abstract.Models
{
    /// <summary>    
    /// The ErrorDetail provides a comprehensive description
    /// of the encountered error.    
    /// </summary>
    public class ErrorDetail
    {
        /// <summary> 
        /// The ErrorCode provides the status code of the API.
        /// </summary>  
        public int? ErrorCode { get; set; }

        /// <summary>       
        /// ErrorMessage providing additional details about the error.  
        /// </summary>  
        public string? ErrorMessage { get; set; }

        /// <summary>       
        /// The variable "HasError" is a boolean value that 
        /// indicates whether an error has occurred..       
        /// </summary>     
        public bool HasError { get; set; }

        /// <summary>       
        /// StatusCode providing additional details about the status code.  
        /// </summary>  
        public HttpStatusCode StatusCode { get; set; }
    }
}
