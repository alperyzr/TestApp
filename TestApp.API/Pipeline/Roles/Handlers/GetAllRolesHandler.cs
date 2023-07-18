using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Core.Application;
using TestApp.Core.Application.Roles.Queries;
using TestApp.Core.Application.Roles.ViewModels;
using TestApp.Repository;

namespace TestApp.API.Pipeline.Roles.Handlers
{
    
    public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, ServiceResult<List<RoleDto>>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetAllRolesHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<RoleDto>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.Roles.OrderByDescending(x => x.Id).ToListAsync();
            return ServiceResult<List<RoleDto>>.SuccessResult(_mapper.Map<List<RoleDto>>(response));
        }
    }
}
