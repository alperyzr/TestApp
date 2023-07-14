using AutoMapper;
using MediatR;
using TestApp.Core.Application.Login.Queries;
using TestApp.Core.Application.Users.Commands;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.Core.Entities;
using TestApp.Repository;

namespace TestApp.API.Pipeline.Login.Handler
{	
	public class LoginQueryHandler : IRequestHandler<LoginQuery, UserDto>
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;

		public LoginQueryHandler(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<UserDto> Handle(LoginQuery request, CancellationToken cancellationToken)
		{
			var checkData = _context.Users.FirstOrDefault(x => x.Email == request.Email && x.Password == request.Password);
			if (checkData != null)
				return null;

			UserDto model = _mapper.Map<UserDto>(checkData);
			return model;
		}
	}
}
