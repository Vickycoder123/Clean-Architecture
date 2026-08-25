using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetProductByNameQuery(string Name) : IRequest<IList<ProductResponse>>;
}