using AutoMapper.QueryableExtensions;
using AutoMapper;
using Bentas.O2.DynamicLinq;
using MediatR;
using TestApp.Core.Application.UrlShorts.Queries;
using TestApp.Core.Application.UrlShorts.ViewModels;
using TestApp.Core.Application.Users.Queries;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UrlShorts.Handlers
{
    public class ListDsUrlShortHandler : IRequestHandler<ListDsUrlShortQuery, BDataSourceResult<ListDsUrlShortView>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ListDsUrlShortHandler(AppDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<BDataSourceResult<ListDsUrlShortView>> Handle(ListDsUrlShortQuery request, CancellationToken cancellationToken)
        {
            var path = _configuration.GetValue<string>("ClientUrl");

            var listDsUser = _context.UrlShorts.AsQueryable();

            if (request.FilterView.Id.HasValue)
                listDsUser = listDsUser.Where(x => x.Id == request.FilterView.Id);

            if (request.FilterView.UserId.HasValue)
                listDsUser = listDsUser.Where(x => x.UserId == request.FilterView.UserId);

            if (!String.IsNullOrEmpty(request.FilterView.Url))
                listDsUser = listDsUser.Where(x => x.Url == request.FilterView.Url);

            if (!String.IsNullOrEmpty(request.FilterView.ShortUrl))
                listDsUser = listDsUser.Where(x => x.ShortUrl == request.FilterView.ShortUrl);

            if (!String.IsNullOrEmpty(request.FilterView.Description))
                listDsUser = listDsUser.Where(x => x.Description == request.FilterView.Description);

            var retVal = listDsUser.ProjectTo<ListDsUrlShortView>(_mapper.ConfigurationProvider);

            if (request.Sort == null || !request.Sort.Any())
                retVal = retVal.OrderByDescending(e => e.Id);

            var result = await retVal.Select(x=> new ListDsUrlShortView
            {
                Url = x.Url,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Id = x.Id,  
                IsActive = x.IsActive,  
                IsDeleted = x.IsDeleted,
                RedirectUrlDate = x.RedirectUrlDate,
                ShortUrl = $"{path}{x.ShortUrl}",
                ToRedirectUrl = x.ToRedirectUrl,
                UpdatedDate = x.UpdatedDate,
                UserFirstName = x.UserFirstName,
                UserLastName = x.UserLastName, 
                UserName = x.UserFirstName + " " + x.UserLastName,
                UserId = x.UserId,
                
                
            }).BToDataSourceResultAsync(request);

            
            return result;

        }
    }
}
