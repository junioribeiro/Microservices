using MongoDB.Driver;

namespace Catalog.API.Entities
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetConfigureProducts());
            }
        }
        private static IEnumerable<Product> GetConfigureProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Name = "IPhone X",
                    Category = "Smart Phone",
                    Price = 950.00M,
                    Description = "IPhone X is the latest smart phone, released in 2017",
                    Image = "product-1.png"
                },
                new Product
                {
                    Name = "Samsung Galaxy S20",
                    Category = "Smart Phone",
                    Price = 800.00M,
                    Description = "Samsung Galaxy S20 is the latest smart phone, released in 2019",
                    Image = "product-2.png"
                },
                new Product
                {
                    Name = "Huawei P30 Pro",
                    Category = "Smart Phone",
                    Price = 900.00M,
                    Description = "Huawei P30 Pro is the latest smart phone, released in 2019",
                    Image = "product-3.png"
                }
            };
        }
    }
}
