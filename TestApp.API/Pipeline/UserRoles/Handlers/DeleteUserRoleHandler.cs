using MediatR;
using TestApp.Core.Application;
using TestApp.Core.Application.UserRoles.Commands;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UserRoles.Handlers
{
    public class DeleteUserRoleHandler : IRequestHandler<DeleteUserRoleCommand, ServiceResult<Unit>>
    {
        private readonly AppDbContext _context;

        public DeleteUserRoleHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult<Unit>> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
        {
            var model = _context.UserRoles.FirstOrDefault(x => x.Id == request.Id);

            if (model == null)
                return ServiceResult<Unit>.WarningResult(Unit.Value,"Kullanıcı Rolü bulunamadı.","400");

            _context.Remove(model);
            await _context.SaveChangesAsync();
            return ServiceResult<Unit>.SuccessResult(Unit.Value); ;

        }
    }
}
