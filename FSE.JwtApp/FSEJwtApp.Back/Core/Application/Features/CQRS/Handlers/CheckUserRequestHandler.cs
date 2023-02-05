using FSEJwtApp.Back.Core.Application.Dto;
using FSEJwtApp.Back.Core.Application.Features.CQRS.Queries;
using FSEJwtApp.Back.Core.Application.Interfaces;
using FSEJwtApp.Back.Core.Domain;
using MediatR;

namespace FSEJwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserRequestHandler : IRequestHandler<CheckUserQueryRequest,
        CheckUserResponseDto>
    {
        private readonly IRepository<AppUser> userRepository;
        private readonly IRepository<AppRole> roleRepository;

        public CheckUserRequestHandler(IRepository<AppUser> userRepository, IRepository<AppRole> roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();
            var user = await this.userRepository.GetByFilerAsync(x =>
            x.Username == request.Username && x.Password == request.Password);

            if (user==null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.Username = user.Username;
                dto.Id=user.Id;
                dto.IsExist = true;
                var role = await this.roleRepository.GetByFilerAsync(x =>
                x.Id == user.AppRoleId);
                dto.Role = role?.Definition;
            }
            return dto;
        }
    }
}
