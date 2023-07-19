using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Core.Application;
using TestApp.Core.Application.Users.Queries;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.Repository;

namespace TestApp.API.Pipeline.Users.Handlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, ServiceResult<List<UserDto>>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetAllUsersHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.Users.OrderByDescending(x=>x.Id).ToListAsync();
            return ServiceResult<List<UserDto>>.SuccessResult(_mapper.Map<List<UserDto>>(response));
        }
    }
}
