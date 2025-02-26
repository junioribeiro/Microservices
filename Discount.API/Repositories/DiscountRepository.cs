using Dapper;
using Discount.API.Entities;
using Npgsql;
using System.Data.Common;

namespace Discount.API.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public async Task<bool> CreateDiscount(Coupon coupon)
        {
          var connection = GetDbConnection();
          var affected = await connection.ExecuteAsync("INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)", coupon);
            return affected > 0;

        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            var connection =  GetDbConnection();
            var affected = await connection.ExecuteAsync("DELETE FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });
            return affected > 0;
        }

        public async Task<Coupon?> GetDiscount(string productName)
        {
            var connection = GetDbConnection();
            return await connection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            var connection = GetDbConnection();
            var affected = await connection.ExecuteAsync("UPDATE Coupon SET ProductName = @ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id", coupon);
            return affected > 0;
        }

        private NpgsqlConnection GetDbConnection()
        {
            return new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        }
    }
}
