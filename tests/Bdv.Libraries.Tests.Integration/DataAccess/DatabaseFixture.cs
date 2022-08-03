using FluentMigrator.Runner;
using System;

namespace Bdv.Libraries.Tests.Integration.DataAccess
{
    public class DatabaseFixture : IDisposable
    {
        private readonly IMigrationRunner _migrationRunner;

        public DatabaseFixture(IMigrationRunner migrationRunner)
        {
            _migrationRunner = migrationRunner;
            _migrationRunner.MigrateUp();
        }

        public void Dispose()
        {
            _migrationRunner.MigrateDown(0);
        }
    }
}
