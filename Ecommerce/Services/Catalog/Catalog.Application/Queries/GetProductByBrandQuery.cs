using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetProductByBrandQuery(string BrandName) : IRequest<IList<ProductResponse>>;
    
}