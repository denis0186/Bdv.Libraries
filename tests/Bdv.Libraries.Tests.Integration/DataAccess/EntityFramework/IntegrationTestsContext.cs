using Bdv.Libraries.Tests.Integration.DataAccess.Entities;
using Bdv.Libraries.Tests.Integration.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Bdv.Libraries.Tests.Integration.DataAccess.EntityFramework
{
    public class IntegrationTestsContext : DbContext
    {
        public IntegrationTestsContext(DbContextOptions<IntegrationTestsContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<Country>().HasKey(x => x.Id);
            modelBuilder.Entity<Transaction>().HasKey(x => x.Id);

            modelBuilder.Entity<User>().HasMany<Transaction>().WithOne().HasForeignKey(x => x.UserId);
            modelBuilder.Entity<Country>().HasMany<Transaction>().WithOne().HasForeignKey(x => x.CountryId);

            modelBuilder.Entity<InformationSchemaTables>().HasNoKey();
        }
    }
}
