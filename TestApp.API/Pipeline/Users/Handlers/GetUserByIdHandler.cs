using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Core.Application.Users.Queries;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.Core.Entities;
using TestApp.Repository;

namespace TestApp.API.Pipeline.Users.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly AppDbContext _comtext;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(AppDbContext comtext, IMapper mapper)
        {
            _comtext = comtext;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
           
            var model = await _comtext.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            var response = _mapper.Map<UserDto>(model);
            return response;
        }
    }
}
