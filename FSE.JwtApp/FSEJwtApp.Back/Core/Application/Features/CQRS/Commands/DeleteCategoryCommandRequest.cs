using MediatR;

namespace FSEJwtApp.Back.Core.Application.Features.CQRS.Commands
{
    public class DeleteCategoryCommandRequest:IRequest
    {
        public int Id { get; set; }

        public DeleteCategoryCommandRequest(int ıd)
        {
            Id = ıd;
        }
    }
}
