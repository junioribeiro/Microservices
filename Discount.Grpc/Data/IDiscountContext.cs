using System.Data.Common;

namespace Discount.Grpc.Data
{
    public interface IDiscountContext
    {
        DbConnection GetConnection();
    }
}
