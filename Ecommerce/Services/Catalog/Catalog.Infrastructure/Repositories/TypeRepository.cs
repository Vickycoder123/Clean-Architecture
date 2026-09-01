using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        private readonly IMongoCollection<ProductType> _types;
        public TypeRepository(IOptions<DatabaseSettings> options)
        {
            var settings = options.Value;
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);
            _types = db.GetCollection<ProductType>(settings.TypeCollectionName);
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
