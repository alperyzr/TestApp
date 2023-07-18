using AutoMapper;
using MediatR;
using TestApp.Core.Application;
using TestApp.Core.Application.Users.Commands;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.Core.Entities;
using TestApp.Repository;

namespace TestApp.API.Pipeline.Users.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, ServiceResult<UserDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AddUserHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<UserDto>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var checkData = _context.Users.Where(x => x.Email == request.Email).FirstOrDefault();
            if (checkData != null)
                return ServiceResult<UserDto>.WarningResult(null,"Böyle Bir Kullanıcı Mevcut");
            
            User model = _mapper.Map<User>(request);
            model.CreatedDate = DateTime.Now;
            await _context.Users.AddAsync(model);
            await _context.SaveChangesAsync();
            return ServiceResult<UserDto>.SuccessResult(_mapper.Map<UserDto>(model));
        }
    }
}
