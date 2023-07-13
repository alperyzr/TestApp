using AutoMapper;
using MediatR;
using TestApp.Core.Application.UserRoles.Commands;
using TestApp.Core.Application.Users.Commands;
using TestApp.Core.Entities;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UserRoles.Handlers
{
    public class AddUserRoleHandler : IRequestHandler<AddUserRoleCommand, int>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AddUserRoleHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {
            var checkDataUser = _context.Users.Find(request.UserId);
            var checkDataRole = _context.Roles.Find(request.RoleId);
            if (checkDataUser == null && checkDataRole == null)
                return 0;

            UserRole model = _mapper.Map<UserRole>(request);
            await _context.UserRoles.AddAsync(model);
            await _context.SaveChangesAsync();
            return model.Id;
        }
    }
}
