using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Core.Application;
using TestApp.Core.Application.Roles.Commands;
using TestApp.Core.Application.Roles.ViewModels;
using TestApp.Core.Entities;
using TestApp.Repository;

namespace TestApp.API.Pipeline.Roles.Handlers
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, ServiceResult<RoleDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateRoleHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<RoleDto>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var chechData = await _context.Roles.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);

            if (chechData == null)
                return ServiceResult<RoleDto>.WarningResult(null, "Rol Bulunamadı");

            request.UpdatedDate = DateTime.Now;
            _context.Roles.Update(_mapper.Map<Role>(request));
            await _context.SaveChangesAsync();
            return ServiceResult<RoleDto>.SuccessResult(_mapper.Map<RoleDto>(request));
        }
    }
}
