using Catalog.API.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IOptions<DatabaseSettings> dataBaseSettings)
        {
            var mongoClient = new MongoClient(
            dataBaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                dataBaseSettings.Value.DatabaseName);

            Products = mongoDatabase.GetCollection<Product>(dataBaseSettings.Value.CollectionName);

            CatalogContextSeed.SeedData(Products);

        }
        public IMongoCollection<Product> Products { get; }
    }
}
