using FSEJwtApp.Back.Core.Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace FSEJwtApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetCategoryQueryRequest:IRequest<CategoryListDto?>
    {
        public int Id { get; set; }
        public GetCategoryQueryRequest(int id)
        {
            Id= id;
        }
    }
}
