using MediatR;
using TestApp.Core.Application.Users.Commands;
using TestApp.Repository;

namespace TestApp.API.Pipeline.Users.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly AppDbContext _context;

        public DeleteUserHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var model = _context.Users.FirstOrDefault(x => x.Id == request.Id);
           
            if (model == null)
                return Unit.Value;

            _context.Remove(model);
            await _context.SaveChangesAsync();
            return Unit.Value;

        }
    }
}
