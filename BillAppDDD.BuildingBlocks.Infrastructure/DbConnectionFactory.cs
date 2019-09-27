using System.Data;
using System.Data.SqlClient;

namespace BillAppDDD.BuildingBlocks.Infrastructure
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private string connectionString;
        private IDbConnection connection;

        public DbConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbConnection GetDbConnection()
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
            }

            return connection;
        }
    }
}
