using System.Data.Common;

namespace Discount.API.Data
{
    public interface IDiscountContext
    {
        DbConnection GetConnection();
    }
}
