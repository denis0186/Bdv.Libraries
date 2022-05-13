namespace Bdv.Domain.Abstractions
{
    public interface IEntity<TKey> : IEntity where TKey : struct
    {
        /// <summary>
        /// Record identifier
        /// </summary>
        TKey Id { get; set; }
    }

    public interface IEntity
    {
    }
}
