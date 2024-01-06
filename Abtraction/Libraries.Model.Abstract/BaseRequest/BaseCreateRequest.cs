namespace Libraries.Abstract.Models.Request
{
    /// <summary>
    /// Create Request Base model.
    /// </summary>
    public abstract class BaseCreateRequest
    {
        /// <summary>
        /// Created by user Id.
        /// </summary>
        [XmlIgnore]
        public int CreatedBy { get; set; }
    }
}
