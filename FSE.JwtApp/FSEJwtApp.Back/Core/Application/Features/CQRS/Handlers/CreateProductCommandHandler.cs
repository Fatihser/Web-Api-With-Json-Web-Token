using FSEJwtApp.Back.Core.Application.Features.CQRS.Commands;
using FSEJwtApp.Back.Core.Application.Interfaces;
using FSEJwtApp.Back.Core.Domain;
using MediatR;

namespace FSEJwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IRepository<Product> repository;

        public CreateProductCommandHandler(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await this.repository.CreateAsync(new Product { 
                CategoryId=request.CategoryId,
                Name=request.Name,
                Price=request.Price,
                Stock=request.Stock,
            });

            return Unit.Value;
        }
    }
}
