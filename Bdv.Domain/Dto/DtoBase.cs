using Bdv.Domain.Abstractions;

namespace Bdv.Domain.Dto
{
    public record DtoBase<TId> : IEntity<TId>
    {
        /// <summary>
        /// Record identifier
        /// </summary>
        public TId Id { get; set; }
    }
}
