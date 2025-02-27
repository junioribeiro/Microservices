using Dapper;
using Discount.API.Data;
using Discount.API.Entities;
using System.Data.Common;

namespace Discount.API.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IDiscountContext _discountContext;
        private readonly DbConnection _dbConnection;

        public DiscountRepository(IDiscountContext discountContext)
        {
            _discountContext = discountContext ?? throw new ArgumentNullException(nameof(discountContext));
            _dbConnection = _discountContext.GetConnection();
        }
        public async Task<bool> CreateDiscount(Coupon coupon)
        {          
          var affected = await _dbConnection.ExecuteAsync("INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)", coupon);
            return affected > 0;

        }

        public async Task<bool> DeleteDiscount(string productName)
        {            
            var affected = await _dbConnection.ExecuteAsync("DELETE FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });
            return affected > 0;
        }

        public async Task<Coupon?> GetDiscount(string productName)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {            
            var affected = await _dbConnection.ExecuteAsync("UPDATE Coupon SET ProductName = @ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id", coupon);
            return affected > 0;
        }        
    }
}
