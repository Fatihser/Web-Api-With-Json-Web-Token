using AutoMapper;
using FSEJwtApp.Back.Core.Application.Dto;
using FSEJwtApp.Back.Core.Application.Features.CQRS.Queries;
using FSEJwtApp.Back.Core.Application.Interfaces;
using FSEJwtApp.Back.Core.Domain;
using MediatR;

namespace FSEJwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, List<CategoryListDto>>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;

        public GetCategoriesQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<CategoryListDto>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var data=await this.repository.GetAllAsync();
            return this.mapper.Map<List<CategoryListDto>>(data);
        }
    }
}
