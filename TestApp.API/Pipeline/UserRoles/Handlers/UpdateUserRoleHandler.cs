using AutoMapper;
using MediatR;
using TestApp.Core.Application.UserRoles.Commands;
using TestApp.Core.Entities;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UserRoles.Handlers
{
    public class UpdateUserRoleHandler : IRequestHandler<UpdateUserRoleCommand, Unit>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateUserRoleHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var chechUser = await _context.Users.FindAsync(request.UserId);
            var chechRole = await _context.Roles.FindAsync(request.RoleId);
           
            if (chechUser == null || chechRole == null)          
                return Unit.Value;
            

            UserRole model = _mapper.Map<UserRole>(request);
            model.Id = request.Id;

            _context.UserRoles.Update(model);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
