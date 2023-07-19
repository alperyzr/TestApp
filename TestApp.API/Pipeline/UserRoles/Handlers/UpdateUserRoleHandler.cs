using AutoMapper;
using MediatR;
using TestApp.Core.Application;
using TestApp.Core.Application.UserRoles.Commands;
using TestApp.Core.Application.UserRoles.ViewModels;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.Core.Entities;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UserRoles.Handlers
{
    public class UpdateUserRoleHandler : IRequestHandler<UpdateUserRoleCommand, ServiceResult<UserRoleDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateUserRoleHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<UserRoleDto>> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var chechUser = await _context.Users.FindAsync(request.UserId);
            var chechRole = await _context.Roles.FindAsync(request.RoleId);
           
            if (chechUser == null || chechRole == null)          
                return ServiceResult<UserRoleDto>.WarningResult(null,"Kullanıcı ve ya Rol Bulunamadı");


            request.UpdatedDate = DateTime.Now;
            _context.UserRoles.Update(_mapper.Map<UserRole>(request));
            await _context.SaveChangesAsync();
            return ServiceResult<UserRoleDto>.SuccessResult(_mapper.Map<UserRoleDto>(request));
        }
    }
}
