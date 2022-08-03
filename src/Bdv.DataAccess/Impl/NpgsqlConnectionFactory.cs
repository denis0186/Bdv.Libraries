using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;

namespace Bdv.DataAccess.Impl
{
    internal class NpgsqlConnectionFactory : IConnectionFactory
    {
        private readonly IOptions<ConnectionFactoryOptions> _options;

        public NpgsqlConnectionFactory(IOptions<ConnectionFactoryOptions> options)
        {
            _options = options;
        }

        public async Task<IDbConnection> CreateAsync(string? connectionString = null)
        {
            var connection = new NpgsqlConnection(connectionString ?? _options.Value.ConnectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
