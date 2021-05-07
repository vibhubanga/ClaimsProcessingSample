﻿using ClaimsProcessingSample.Application.Interfaces.Repositories;
using ClaimsProcessingSample.Domain.Entities.Catalog;
using ClaimsProcessingSample.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ClaimsProcessingSample.Application.Features.Products.Commands.Delete
{
    public class DeleteProductCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
            {
                var product = await _unitOfWork.Repository<Product>().GetByIdAsync(command.Id);
                await _unitOfWork.Repository<Product>().DeleteAsync(product);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(product.Id, "Product Deleted");
            }
        }
    }
}