using Bdv.Domain.Abstractions;

namespace Bdv.Domain.Dto
{
    public record DtoBase<TId> : IEntity<TId> where  TId : struct
    {
        /// <summary>
        /// Record identifier
        /// </summary>
        public TId Id { get; set; } = default!;
    }
}
