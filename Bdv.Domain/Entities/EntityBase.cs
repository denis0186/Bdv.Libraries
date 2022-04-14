using Bdv.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bdv.Domain.Entities
{
    public abstract class EntityBase<TKey> : IEntity<TKey>
    {
        [Column("id")]
        public TKey Id { get; set; }
    }
}
