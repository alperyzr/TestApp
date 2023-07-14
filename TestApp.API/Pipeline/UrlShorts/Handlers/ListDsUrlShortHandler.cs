using Bentas.O2.DynamicLinq;
using MediatR;
using TestApp.Core.Application.UrlShorts.Queries;
using TestApp.Core.Application.UrlShorts.ViewModels;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UrlShorts.Handlers
{
    public class ListDsUrlShortHandler : IRequestHandler<ListDsUrlShortQuery, BDataSourceResult<ListDsUrlShortView>>
    {
        private readonly AppDbContext _context;

        public ListDsUrlShortHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BDataSourceResult<ListDsUrlShortView>> Handle(ListDsUrlShortQuery request, CancellationToken cancellationToken)
        {
            var retVal = _context.UrlShorts.Select(x => new ListDsUrlShortView
            {
                Id = x.Id,
               CreatedDate = x.CreatedDate,
               Description = x.Description,
               IsActive = x.IsActive,
               IsDeleted = x.IsDeleted,
               RedirectUrlDate = x.RedirectUrlDate,
               ToRedirectUrl = x.ToRedirectUrl,
               UpdatedDate = x.UpdatedDate,
               Url = x.Url,
               UrlKey = x.UrlKey,
               UserId = x.UserId,
               UserName = x.User.FirstName + " " + x.User.LastName
            });

            var result = await retVal.BToDataSourceResultAsync(request);
            return result;
        }
    }
}
