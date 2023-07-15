using AutoMapper;
using MediatR;
using TestApp.Core.Application;
using TestApp.Core.Application.Login.Queries;
using TestApp.Core.Application.Users.Commands;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.Core.Entities;
using TestApp.Repository;
using static MassTransit.ValidationResultExtensions;

namespace TestApp.API.Pipeline.Login.Handler
{	
	public class LoginQueryHandler : IRequestHandler<LoginQuery, ServiceResult<UserDto>>
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;

		public LoginQueryHandler(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<ServiceResult<UserDto>> Handle(LoginQuery request, CancellationToken cancellationToken)
		{
			var checkData = _context.Users.FirstOrDefault(x => x.Email == request.Email && x.Password == request.Password);
			if (checkData == null)
				return ServiceResult<UserDto>.WarningResult(null,"Kullanıcı Bulunamadı","400");

			UserDto model = _mapper.Map<UserDto>(checkData);
			return ServiceResult<UserDto>.SuccessResult(model, "Ok", "200");
		}
	}
}
