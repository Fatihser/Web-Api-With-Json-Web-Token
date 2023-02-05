using FSEJwtApp.Back.Core.Application.Dto;
using MediatR;

namespace FSEJwtApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetAllProductsQueryRequest:IRequest<List<ProductListDto>>
    {
    }
}
