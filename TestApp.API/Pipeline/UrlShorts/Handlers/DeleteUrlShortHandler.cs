using MediatR;
using TestApp.Core.Application.UrlShorts.Commands;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UrlShorts.Handlers
{
    public class DeleteUrlShortHandler : IRequestHandler<DeleteUrlShortCommand, Unit>
    {
        private readonly AppDbContext _context;

        public DeleteUrlShortHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteUrlShortCommand request, CancellationToken cancellationToken)
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
