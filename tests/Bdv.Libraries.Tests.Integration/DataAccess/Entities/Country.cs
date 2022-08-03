using System.ComponentModel.DataAnnotations.Schema;

namespace Bdv.Libraries.Tests.Integration.DataAccess.Entities
{
    [Table("countries")]
    public class Country : Domain.Entities.EntityBase<int>
    {
        [Column("name")]
        public string Name { get; set; } = string.Empty;
    }
}
