using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IMongoCollection<ProductBrand> _brands;
        public BrandRepository(IConfiguration config) 
        {
            var client = new MongoClient(config["DatabaseSettings:ConnectionString"]);
            var db = client.GetDatabase(config["DatabaseSettings:DatabaseName"]);
            _brands = db.GetCollection<ProductBrand>(config["DatabaseSettings:BrandCollection"]);

        }
        async Task<IEnumerable<ProductBrand>> IBrandRepository.GetAllBrands()
        {
            return await _brands.Find(_ => true).ToListAsync();
        }

        async Task<ProductBrand> IBrandRepository.GetBrandAsync(string id)
        {
            return await _brands.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
