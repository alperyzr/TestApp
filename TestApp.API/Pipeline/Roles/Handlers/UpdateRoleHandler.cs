using AutoMapper;
using MediatR;
using TestApp.Core.Application;
using TestApp.Core.Application.Roles.Commands;
using TestApp.Core.Application.Roles.ViewModels;
using TestApp.Core.Application.UrlShorts.ViewModels;
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
            Role model = _mapper.Map<Role>(request);
            model.Id = request.Id;

			var chechData = await _context.Roles.FindAsync(model.Id);
			if (chechData == null)
				return ServiceResult<RoleDto>.WarningResult(null, "Rol bulunamadı");

			_context.Roles.Update(model);
            await _context.SaveChangesAsync();

            return ServiceResult<RoleDto>.SuccessResult(_mapper.Map<RoleDto>(model));
        }
    }
}
