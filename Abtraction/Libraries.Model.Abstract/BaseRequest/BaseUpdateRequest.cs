namespace Libraries.Abstract.Models.Request
{
    /// <summary>
    ///  Update Request Base model.
    /// </summary>
    public abstract class BaseUpdateRequest
    {
        /// <summary>
        /// Updated by user Id.
        /// </summary>
        [XmlIgnore]
        public int ModifiedBy { get; set; }
    }
}
