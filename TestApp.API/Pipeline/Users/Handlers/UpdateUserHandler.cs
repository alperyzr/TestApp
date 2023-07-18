using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

            var chechData = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);

            if (chechData == null)
                return ServiceResult<UserDto>.WarningResult(null, "Kullanıcı Bulunamadı");

            request.UpdatedDate = DateTime.Now;
            _context.Users.Update(_mapper.Map<User>(request));
            await _context.SaveChangesAsync();
            return ServiceResult<UserDto>.SuccessResult(_mapper.Map<UserDto>(request));

        }
    }
}
