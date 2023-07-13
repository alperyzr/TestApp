using Bentas.O2.DynamicLinq;
using MediatR;
using TestApp.Core.Application.Roles.Queries;
using TestApp.Core.Application.Roles.ViewModels;
using TestApp.Repository;

namespace TestApp.API.Pipeline.Roles.Handlers
{
    public class ListDsRoleHandler : IRequestHandler<ListDsRoleQuery, BDataSourceResult<ListDsRoleView>>
    {
        private readonly AppDbContext _context;

        public ListDsRoleHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BDataSourceResult<ListDsRoleView>> Handle(ListDsRoleQuery request, CancellationToken cancellationToken)
        {
            var retVal = _context.Roles.Select(x => new ListDsRoleView
            {
                Id = x.Id,
                Name = x.Name,
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
