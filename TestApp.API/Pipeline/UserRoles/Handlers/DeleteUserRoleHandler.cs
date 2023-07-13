using MediatR;
using TestApp.Core.Application.UserRoles.Commands;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UserRoles.Handlers
{
    public class DeleteUserRoleHandler : IRequestHandler<DeleteUserRoleCommand, Unit>
    {
        private readonly AppDbContext _context;

        public DeleteUserRoleHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
        {
            var model = _context.UserRoles.FirstOrDefault(x => x.Id == request.Id);

            if (model == null)
                return Unit.Value;

            _context.Remove(model);
            await _context.SaveChangesAsync();
            return Unit.Value;

        }
    }
}
