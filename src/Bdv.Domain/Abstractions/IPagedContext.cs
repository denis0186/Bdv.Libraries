namespace Bdv.Domain.Abstractions
{
    public interface IPagedContext
    {
        /// <summary>
        /// Page number from 1
        /// </summary>
        int Page { get; set; }

        /// <summary>
        /// Size of page
        /// </summary>
        int PageSize { get; set; }
    }
}
