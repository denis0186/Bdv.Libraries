using Bdv.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bdv.Domain.Entities
{
    public abstract class EntityBase<TKey> : IEntity<TKey> where TKey : struct
    {
        [Column("id")]
        public TKey Id { get; set; }
    }
}
