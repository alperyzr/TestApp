using Bentas.O2.DynamicLinq;
using MediatR;
using TestApp.Core.Application.UserRoles.Queries;
using TestApp.Core.Application.UserRoles.ViewModels;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UserRoles.Handlers
{
    public class ListDsUserRoleHandler : IRequestHandler<ListDsUserRoleQuery, BDataSourceResult<ListDsUserRoleView>>
    {
        private readonly AppDbContext _context;

        public ListDsUserRoleHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BDataSourceResult<ListDsUserRoleView>> Handle(ListDsUserRoleQuery request, CancellationToken cancellationToken)
        {
            var retVal = _context.UserRoles.Select(x => new ListDsUserRoleView
            {
                Id = x.Id,
               RoleId = x.RoleId,
               UserId = x.UserId,
               CreatedDate = x.CreatedDate,
               IsActive = x.IsActive,
               IsDeleted = x.IsDeleted,
               UpdatedDate = x.UpdatedDate
            });

            var result = await retVal.BToDataSourceResultAsync(request);
            return result;
        }
    }
}
