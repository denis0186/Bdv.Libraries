using System.Data;

namespace Bdv.DataAccess
{
    public interface IConnectionFactory
    {
        /// <summary>
        /// Creates a connection string
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        /// <returns></returns>
        Task<IDbConnection> CreateAsync(string? connectionString = null);
    }
}
