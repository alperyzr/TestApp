using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Core.Application.UserRoles.Queries;
using TestApp.Core.Application.UserRoles.ViewModels;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UserRoles.Handlers
{
    public class GetUserRoleByIdHandler : IRequestHandler<GetUserRoleByIdQuery, UserRoleDto>
    {
        private readonly AppDbContext _comtext;
        private readonly IMapper _mapper;

        public GetUserRoleByIdHandler(AppDbContext comtext, IMapper mapper)
        {
            _comtext = comtext;
            _mapper = mapper;
        }
        public async Task<UserRoleDto> Handle(GetUserRoleByIdQuery request, CancellationToken cancellationToken)
        {

            var model =  _comtext.UserRoles.Include(x=>x.User).Include(x=>x.Role).FirstOrDefault(x => x.Id == request.Id);
            var response = _mapper.Map<UserRoleDto>(model);
            return response;
        }
    }
}
