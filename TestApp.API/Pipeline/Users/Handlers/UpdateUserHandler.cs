using AutoMapper;
using MediatR;
using TestApp.Core.Application;
using TestApp.Core.Application.UserRoles.ViewModels;
using TestApp.Core.Application.Users.Commands;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.Core.Entities;
using TestApp.Repository;

namespace TestApp.API.Pipeline.Users.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ServiceResult<UserDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateUserHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<UserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User model = _mapper.Map<User>(request);
            model.Id = request.Id;

			var chechData = await _context.Users.FindAsync(request.Id);
			
			if (chechData == null)
				return ServiceResult<UserDto>.WarningResult(null, "Kullanıcı Bulunamadı");

			_context.Users.Update(model);
            await _context.SaveChangesAsync();
            return ServiceResult<UserDto>.SuccessResult(_mapper.Map<UserDto>(model));
        }
    }
}
