using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Catalog.Application.Commands
{
    public record DeleteProductByIdCommand(string Id) : IRequest<bool>;
    
}