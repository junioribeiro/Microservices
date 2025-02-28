using Npgsql;
using System.Data.Common;

namespace Discount.Grpc.Data
{
    public class DiscountContext : IDiscountContext
    {
        private readonly IConfiguration _configuration;
        private DbConnection? Connection;

        public DiscountContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public DbConnection GetConnection()
        {
            if (Connection == null)
            {
                string connectionString = _configuration.GetValue<string>("DatabaseSettings:ConnectionString") ?? "";
                Connection = new NpgsqlConnection(connectionString);
            }
            return Connection;
        }
    }
}
