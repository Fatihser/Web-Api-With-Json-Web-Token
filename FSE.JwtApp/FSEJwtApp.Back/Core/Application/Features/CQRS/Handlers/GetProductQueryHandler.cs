using AutoMapper;
using FSEJwtApp.Back.Core.Application.Dto;
using FSEJwtApp.Back.Core.Application.Features.CQRS.Queries;
using FSEJwtApp.Back.Core.Application.Interfaces;
using FSEJwtApp.Back.Core.Domain;
using MediatR;

namespace FSEJwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest,ProductListDto>
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;

        public GetProductQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ProductListDto> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetByFilerAsync(x => x.Id == request.Id);
            return this.mapper.Map<ProductListDto>(data);
        }
    }
}
