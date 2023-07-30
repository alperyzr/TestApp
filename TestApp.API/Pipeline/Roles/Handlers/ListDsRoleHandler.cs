using AutoMapper.QueryableExtensions;
using AutoMapper;
using Bentas.O2.DynamicLinq;
using MediatR;
using TestApp.Core.Application.Roles.Queries;
using TestApp.Core.Application.Roles.ViewModels;
using TestApp.Core.Application.Users.Queries;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.Repository;

namespace TestApp.API.Pipeline.Roles.Handlers
{
    public class ListDsRoleHandler : IRequestHandler<ListDsRoleQuery, BDataSourceResult<ListDsRoleView>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ListDsRoleHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BDataSourceResult<ListDsRoleView>> Handle(ListDsRoleQuery request, CancellationToken cancellationToken)
        {
            var listDsRole = _context.Roles.AsQueryable();

            if (request.FilterView.Id.HasValue)
                listDsRole = listDsRole.Where(x => x.Id == request.FilterView.Id);

            if (!String.IsNullOrEmpty(request.FilterView.Name))
                listDsRole = listDsRole.Where(x => x.Name == request.FilterView.Name);
            

            var retVal = listDsRole.ProjectTo<ListDsRoleView>(_mapper.ConfigurationProvider);

            if (request.Sort == null || !request.Sort.Any())
                retVal = retVal.OrderByDescending(e => e.Id);

            var result = await retVal.BToDataSourceResultAsync(request);

            return result;

        }
    }
}
