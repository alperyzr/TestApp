using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Core.Application;
using TestApp.Core.Application.Roles.Queries;
using TestApp.Core.Application.Roles.ViewModels;
using TestApp.Core.Application.UserRoles.Queries;
using TestApp.Core.Application.UserRoles.ViewModels;
using TestApp.Core.Entities;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UserRoles.Handlers
{
    
    public class GetAllUserRoleHandler : IRequestHandler<GetAllUserRolesQuery, ServiceResult<List<UserRoleDto>>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetAllUserRoleHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<UserRoleDto>>> Handle(GetAllUserRolesQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.UserRoles.Include(x=>x.Role).Include(x=>x.User).OrderByDescending(x => x.Id).Select(x=> new UserRoleDto
            {
             Id = x.Id,
             CreatedDate = x.CreatedDate,
             IsActive = x.IsActive,
             IsDeleted = x.IsDeleted,
             RoleId = x.RoleId,
             RoleName = x.Role.Name,
             UpdatedDate = x.UpdatedDate,
             UserId = x.UserId,
             UserName = x.User.FirstName + " " + x.User.LastName,
            }).ToListAsync();
            return ServiceResult<List<UserRoleDto>>.SuccessResult(_mapper.Map<List<UserRoleDto>>(response));
        }
    }
}
