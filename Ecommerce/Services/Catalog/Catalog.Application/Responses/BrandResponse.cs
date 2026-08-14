using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Responses
{
    public record BrandResponse
    {
        public string Id { get; init; }
        public string Name { get; init; }
    }
}
