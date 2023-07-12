using MediatR;
using TestApp.Core.Application.Roles.Commands;
using TestApp.Repository;

namespace TestApp.API.Pipeline.Roles.Handlers
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, Unit>
    {
        private readonly AppDbContext _context;

        public DeleteRoleHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var model = _context.Roles.FirstOrDefault(x => x.Id == request.Id);

            if (model == null)
                return Unit.Value;

            _context.Remove(model);
            await _context.SaveChangesAsync();
            return Unit.Value;

        }
    }
}
