using FluentMigrator;

namespace Bdv.Libraries.Tests.Integration.DataAccess.Migrations
{
    [Migration(202207312138)]
    public class Migration_202207312138 : Migration
    {
        public override void Down()
        {
            Delete.Table("transactions");
            Delete.Table("users");
            Delete.Table("countries");
        }

        public override void Up()
        {
            Create.Table("users")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("name").AsString(255);

            Create.Table("countries")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("name").AsString(255);

            Create.Table("transactions")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("user_id").AsInt32().NotNullable().ForeignKey("users", "id").OnDelete(System.Data.Rule.Cascade)
                .WithColumn("country_id").AsInt32().NotNullable().ForeignKey("countries", "id").OnDelete(System.Data.Rule.Cascade)
                .WithColumn("amount").AsDecimal().NotNullable()
                .WithColumn("data").AsString().Nullable()
                .WithColumn("timestamp").AsDateTime().NotNullable();
        }
    }
}
