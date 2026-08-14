using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        private readonly IMongoCollection<ProductType> _types;
        public TypeRepository(IConfiguration config) 
        {
            var client = new MongoClient(config["DatabaseSettings:ConnectionString"]);
            var db = client.GetDatabase(config["DatabaseSettings:DatabaseNames"]);
            _types = db.GetCollection<ProductType>(config["DatabaseSettings:TypeCollectionName"]);
        }
        async Task<IEnumerable<ProductType>> ITypeRepository.GetAllTypes()
        {
            return await _types.Find(_ => true).ToListAsync();
        }

        async Task<ProductType> ITypeRepository.GetByIdAsync(string id)
        {
            return await _types.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
