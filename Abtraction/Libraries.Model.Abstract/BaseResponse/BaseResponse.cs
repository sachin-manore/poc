namespace Libraries.Abstract.Models.Responses
{
   public class BaseResponse : BaseModel
    {
        public int? ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool HasError { get; set; }
   
       
    }
}
