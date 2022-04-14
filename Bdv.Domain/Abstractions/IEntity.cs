namespace Bdv.Domain.Abstractions
{
    public interface IEntity<TKey>
    {
        /// <summary>
        /// Record identifier
        /// </summary>
        TKey Id { get; set; }
    }
}
