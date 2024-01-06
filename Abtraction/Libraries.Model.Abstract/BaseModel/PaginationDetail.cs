namespace Libraries.Abstract.Models
{
    /// <summary>
    /// Pagination Detail
    /// </summary>
    public class PaginationDetail
    {
        /// <summary>
        /// Page Index
        /// </summary>
        public int? PageIndex { get; set; }
        /// <summary>
        /// Maximum Page Size
        /// </summary>
        public int? PageSize { get; set; }
        /// <summary>
        /// List of Total Pages
        /// </summary>
        public int? TotalPages { get; set; }
        /// <summary>
        /// Total Results count
        /// </summary>
        public int? TotalResults { get; set; }
    }
}