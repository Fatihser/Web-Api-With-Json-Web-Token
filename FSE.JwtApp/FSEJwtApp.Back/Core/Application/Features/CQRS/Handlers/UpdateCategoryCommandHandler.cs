using FSEJwtApp.Back.Core.Application.Features.CQRS.Commands;
using FSEJwtApp.Back.Core.Application.Interfaces;
using FSEJwtApp.Back.Core.Domain;
using MediatR;

namespace FSEJwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IRepository<Category> repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedEntity=await this.repository.GetByIdAsync(request.Id);
            if (updatedEntity!=null)
            {
                updatedEntity.Definition = request.Definition;
                await this.repository.UpdateAsync(updatedEntity);
            }
            return Unit.Value;
        }
    }
}
