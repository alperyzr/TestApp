using MediatR;
using TestApp.Core.Application;
using TestApp.Core.Application.Roles.Commands;
using TestApp.Repository;

namespace TestApp.API.Pipeline.Roles.Handlers
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, ServiceResult<Unit>>
    {
        private readonly AppDbContext _context;

        public DeleteRoleHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult<Unit>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var model = _context.Roles.FirstOrDefault(x => x.Id == request.Id);

            if (model == null)
                return ServiceResult<Unit>.WarningResult(Unit.Value,"Böyle bir rol mevcut değil.","400");

            _context.Remove(model);
            await _context.SaveChangesAsync();
			return ServiceResult<Unit>.SuccessResult(Unit.Value);

        }
    }
}
