namespace WebApi.Requests
{
    public class Request
    {
        /// <summary>
        /// Number of items per page
        /// </summary>
        public int PerPage { get; set; } = 10;
        /// <summary>
        /// Current page
        /// </summary>
        public int CurrentPage { get; set; } = 1;
    }
}
