using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Application.Commands;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductByIdCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.DeleteProduct(request.Id);
        }
    }
}