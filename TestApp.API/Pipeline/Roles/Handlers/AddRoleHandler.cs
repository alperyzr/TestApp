using AutoMapper;
using MediatR;
using TestApp.Core.Application;
using TestApp.Core.Application.Roles.Commands;
using TestApp.Core.Application.Roles.ViewModels;
using TestApp.Core.Entities;
using TestApp.Repository;

namespace TestApp.API.Pipeline.Roles.Handlers
{
    public class AddRoleHandler : IRequestHandler<AddRoleCommand, ServiceResult<RoleDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AddRoleHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<RoleDto>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var checkData = _context.Roles.FirstOrDefault(x => x.Name == request.Name);
            if (checkData != null)
                return ServiceResult<RoleDto>.WarningResult(null,"Böyle bir rol mevcut.","400");

            Role model = _mapper.Map<Role>(request);
            await _context.Roles.AddAsync(model);
            await _context.SaveChangesAsync();
            return ServiceResult<RoleDto>.SuccessResult(_mapper.Map<RoleDto>(model),"Ok","200");
        }
    }
}
