using AutoMapper;
using Bentas.O2.DynamicLinq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Core.Application.Users.Queries;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.Core.Entities;
using TestApp.Repository;
using AutoMapper.QueryableExtensions;

namespace TestApp.API.Pipeline.Users.Handlers
{
    public class ListDsUserHandler : IRequestHandler<ListDsUserQuery, BDataSourceResult<ListDsUserView>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ListDsUserHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BDataSourceResult<ListDsUserView>> Handle(ListDsUserQuery request, CancellationToken cancellationToken)
        {
            var listDsUser = _context.Users.AsQueryable();

            if (request.FilterView.Id.HasValue)
                listDsUser = listDsUser.Where(x => x.Id == request.FilterView.Id);

            if (!String.IsNullOrEmpty(request.FilterView.FirstName))
                listDsUser = listDsUser.Where(x => x.FirstName == request.FilterView.FirstName);

            if (!String.IsNullOrEmpty(request.FilterView.LastName))
                listDsUser = listDsUser.Where(x => x.LastName == request.FilterView.LastName);

            var retVal = listDsUser.ProjectTo<ListDsUserView>(_mapper.ConfigurationProvider);

            if (request.Sort == null || !request.Sort.Any())
                retVal = retVal.OrderByDescending(e => e.Id);

            var result = await retVal.BToDataSourceResultAsync(request);

            return result;

        }
    }
}
