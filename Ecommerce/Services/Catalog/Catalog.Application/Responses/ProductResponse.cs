using Catalog.Core.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Responses
{
    public record ProductResponse
    {
        public string Name { get; init; }
        public string Summary { get; init; }

        public string Description { get; init; }

        public string ImageFile { get; init; }
        public ProductBrand Brand { get; init; }
        public ProductType Type { get; init; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}
