using AutoMapper;
using MediatR;
using TestApp.Core.Application;
using TestApp.Core.Application.UserRoles.Commands;
using TestApp.Core.Application.UserRoles.ViewModels;
using TestApp.Core.Application.Users.Commands;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.Core.Entities;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UserRoles.Handlers
{
    public class AddUserRoleHandler : IRequestHandler<AddUserRoleCommand, ServiceResult<UserRoleDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AddUserRoleHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<UserRoleDto>> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {
            var checkDataUser = _context.Users.Find(request.UserId);
            var checkDataRole = _context.Roles.Find(request.RoleId);
            if (checkDataUser == null && checkDataRole == null)
                ServiceResult<UserDto>.WarningResult(null, "Kullanıcı ve ya Rol bulunamadı.", "400");

            UserRole model = _mapper.Map<UserRole>(request);
            await _context.UserRoles.AddAsync(model);
            await _context.SaveChangesAsync();
            return ServiceResult<UserRoleDto>.SuccessResult(_mapper.Map<UserRoleDto>(model));
        }
    }
}
