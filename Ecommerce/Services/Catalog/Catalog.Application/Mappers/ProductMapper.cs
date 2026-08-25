using Catalog.Application.Commands;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Specifications;

namespace Catalog.Application.Mappers
{
    public static class ProductMapper
    {
        public static ProductResponse ToResponse(this Product product)
        {
            if(product == null)
            {
                return null;
            }

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Summary = product.Summary,
                ImageFile = product.ImageFile,
                Description = product.Description,
                Price = product.Price,
                Brand = product.Brand,
                Type = product.Type,
                CreatedDate = product.CreatedDate
                
            };
        }

        public static Pagination<ProductResponse> ToResponse(this Pagination<Product> pagination)
        => new Pagination<ProductResponse>
        (
            pagination.PageIndex,
            pagination.PageSize,
            pagination.Count,
            pagination.Data.Select(p => p.ToResponse()).ToList()
        );
            
        public static IList<ProductResponse> ToResponseList(this IEnumerable<Product> products) =>
            products.Select(p => p.ToResponse()).ToList();

        public static Product ToEntity(this CreateProductCommand command, ProductBrand brand, ProductType type) =>
            new Product
            {
                Name = command.Name,
                Summary = command.Summary,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
                CreatedDate = DateTime.UtcNow
            };
        
        public static Product ToUpdateEntity(this UpdateProductCommand command, Product existing, ProductBrand brand, ProductType type) =>
            new Product
            {
                Id = existing.Id,
                Name = command.Name,
                Summary = command.Summary,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Type = type,
                Brand = brand,
                Price = command.Price,
                CreatedDate = existing.CreatedDate
            };
    }
}