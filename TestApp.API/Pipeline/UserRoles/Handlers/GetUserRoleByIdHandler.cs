using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Core.Application.UserRoles.Queries;
using TestApp.Core.Application.UserRoles.ViewModels;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UserRoles.Handlers
{
    public class GetUserRoleByIdHandler : IRequestHandler<GetUserRoleByIdQuery, GetUserRoleByIdDto>
    {
        private readonly AppDbContext _comtext;
        private readonly IMapper _mapper;

        public GetUserRoleByIdHandler(AppDbContext comtext, IMapper mapper)
        {
            _comtext = comtext;
            _mapper = mapper;
        }
        public async Task<GetUserRoleByIdDto> Handle(GetUserRoleByIdQuery request, CancellationToken cancellationToken)
        {

            var model =  _comtext.UserRoles.Include(x=>x.User).Include(x=>x.Role).Select(x=> new GetUserRoleByIdDto
            {
                Id = x.Id,
                UpdatedDate = x.UpdatedDate,
                CreatedDate = x.CreatedDate,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted,
                RoleName = x.Role.Name,
                UserName = x.User.FirstName + " " + x.User.LastName,
                RoleId = x.Role.Id,
                UserId = x.User.Id,
                
            }).FirstOrDefault(x => x.Id == request.Id);

            var response = _mapper.Map<GetUserRoleByIdDto>(model);
            return response;
        }
    }
}
