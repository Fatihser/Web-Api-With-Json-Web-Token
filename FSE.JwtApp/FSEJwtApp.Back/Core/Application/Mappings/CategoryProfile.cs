using AutoMapper;
using FSEJwtApp.Back.Core.Application.Dto;
using FSEJwtApp.Back.Core.Domain;

namespace FSEJwtApp.Back.Core.Application.Mappings
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            this.CreateMap<Category, CategoryListDto>().ReverseMap();
        }
    }
}
