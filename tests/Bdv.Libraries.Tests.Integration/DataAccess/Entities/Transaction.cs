using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bdv.Libraries.Tests.Integration.DataAccess.Entities
{
    [Table("transactions")]
    public class Transaction : Domain.Entities.EntityBase<int>
    {
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("country_id")]
        public int CountryId { get; set; }

        [Column("amount")]
        public decimal Amount { get; set; }

        [Column("data")]
        public string? Data { get; set; }

        [Column("timestamp")]
        public DateTime TimeStamp { get; set; }

    }
}
