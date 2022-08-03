using System.ComponentModel.DataAnnotations.Schema;

namespace Bdv.Libraries.Tests.Integration.DataAccess.Entities
{
    [Table("users")]
    public class User : Domain.Entities.EntityBase<int>
    {
        [Column("name")]
        public string Name { get; set; } = string.Empty;
    }
}
