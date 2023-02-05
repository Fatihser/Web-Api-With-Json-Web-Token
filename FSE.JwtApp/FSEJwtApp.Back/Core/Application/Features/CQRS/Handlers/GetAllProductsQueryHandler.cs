using AutoMapper;
using FSEJwtApp.Back.Core.Application.Dto;
using FSEJwtApp.Back.Core.Application.Features.CQRS.Queries;
using FSEJwtApp.Back.Core.Application.Interfaces;
using FSEJwtApp.Back.Core.Domain;
using MediatR;

namespace FSEJwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<ProductListDto>>
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetAllAsync();
            return this.mapper.Map<List<ProductListDto>>(data);
        }
    }
}
