namespace Bdv.Domain.Abstractions
{
    public interface IEntity<TKey> where TKey : struct
    {
        /// <summary>
        /// Record identifier
        /// </summary>
        TKey Id { get; set; }
    }
}
