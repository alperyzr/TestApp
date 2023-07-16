using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Core.Application;
using TestApp.Core.Application.Roles.Queries;
using TestApp.Core.Application.Roles.ViewModels;

using TestApp.Repository;

namespace TestApp.API.Pipeline.Roles.Handlers
{
    public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQuery, ServiceResult<RoleDto>>
    {
        private readonly AppDbContext _comtext;
        private readonly IMapper _mapper;

        public GetRoleByIdHandler(AppDbContext comtext, IMapper mapper)
        {
            _comtext = comtext;
            _mapper = mapper;
        }
        public async Task<ServiceResult<RoleDto>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {

            var model = await _comtext.Roles.FirstOrDefaultAsync(x => x.Id == request.Id);
           
            if (model == null)
                return ServiceResult<RoleDto>.WarningResult(null, "Böyle bir rol mevcut değil.", "400");
			
            var response = _mapper.Map<RoleDto>(model);
            return ServiceResult<RoleDto>.SuccessResult(response); ;
        }
    }
}
