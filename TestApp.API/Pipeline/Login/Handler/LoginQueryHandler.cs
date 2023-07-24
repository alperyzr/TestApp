using AutoMapper;
using FirebaseAdmin.Auth.Multitenancy;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using TestApp.API.Services.Interfaces;
using TestApp.Core.Application;
using TestApp.Core.Application.Login.Queries;
using TestApp.Core.Application.Login.ViewModels;
using TestApp.Core.Application.Users.Commands;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.Core.Entities;
using TestApp.MVC.Services;
using TestApp.Repository;
using static MassTransit.ValidationResultExtensions;

namespace TestApp.API.Pipeline.Login.Handler
{	
	public class LoginQueryHandler : IRequestHandler<LoginQuery, ServiceResult<AccessToken>>
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;
		private readonly ITokenService _tokenService;

        public LoginQueryHandler(AppDbContext context,
			IMapper mapper,
			ITokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<ServiceResult<AccessToken>> Handle(LoginQuery request, CancellationToken cancellationToken)
		{
			var model = _context.Users.FirstOrDefault(x => x.Email == request.Email && x.Password == request.Password);
			if (model == null)
				return ServiceResult<AccessToken>.WarningResult(null,"Kullanıcı Bulunamadı");

			
            AccessToken accessToken = _tokenService.CreateAccessToken(_mapper.Map<User>(model));
            accessToken.UserName = model.FirstName + " " + model.LastName;
            accessToken.ImagePath = model.ImagePath;

            model.RefreshToken = accessToken.RefreshToken;
			model.RefreshTokenEndDate = accessToken.Expiration;
			

			_context.Users.Update(model);
            await _context.SaveChangesAsync();
            return ServiceResult<AccessToken>.SuccessResult(accessToken);
		}
	}
}
