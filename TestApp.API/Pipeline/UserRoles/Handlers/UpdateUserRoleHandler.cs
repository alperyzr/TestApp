using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

            if (chechUser == null)
            {
                return ServiceResult<UserRoleDto>.WarningResult(null, "Kullanıcı Bulunamadı");
            }

            var roleIds = request.SelectedRoles.Select(x => int.Parse(x)).ToArray();

            var roles = await _context.Roles.Where(role => roleIds.Any(x => role.Id == x)).ToListAsync();

            if (!roles.Any() || roles.Count() != roleIds.Length)
                return ServiceResult<UserRoleDto>.WarningResult(null, "Rol Bulunamadı");


           var userRoles = await _context.UserRoles.Where(userRole => userRole.UserId == request.UserId).ToListAsync(); // kişinin güncel rolleri





            request.UpdatedDate = DateTime.Now;
            _context.UserRoles.Update(_mapper.Map<UserRole>(request));
            await _context.SaveChangesAsync();
            return ServiceResult<UserRoleDto>.SuccessResult(_mapper.Map<UserRoleDto>(request));
        }

       
    }
}
