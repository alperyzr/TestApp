using AutoMapper.QueryableExtensions;
using AutoMapper;
using Bentas.O2.DynamicLinq;
using MediatR;
using TestApp.Core.Application.UserRoles.Queries;
using TestApp.Core.Application.UserRoles.ViewModels;
using TestApp.Core.Application.Users.Queries;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.Repository;
using Microsoft.EntityFrameworkCore;

namespace TestApp.API.Pipeline.UserRoles.Handlers
{
    public class ListDsUserRoleHandler : IRequestHandler<ListDsUserRoleQuery, BDataSourceResult<ListDsUserRoleView>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ListDsUserRoleHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BDataSourceResult<ListDsUserRoleView>> Handle(ListDsUserRoleQuery request, CancellationToken cancellationToken)
        {
            var listDsUserRole = _context.UserRoles.AsQueryable();

            if (request.FilterView.Id.HasValue)
                listDsUserRole = listDsUserRole.Where(x => x.Id == request.FilterView.Id);

            if (request.FilterView.RoleId.HasValue)
                listDsUserRole = listDsUserRole.Where(x => x.RoleId == request.FilterView.RoleId);

            if (request.FilterView.UserId.HasValue)
                listDsUserRole = listDsUserRole.Where(x => x.UserId == request.FilterView.UserId);

            var retVal = listDsUserRole.ProjectTo<ListDsUserRoleView>(_mapper.ConfigurationProvider);

            if (request.Sort == null || !request.Sort.Any())
                retVal = retVal.OrderByDescending(e => e.Id);

            var result = await retVal.Select(x=> new ListDsUserRoleView{ 
                CreatedDate = x.CreatedDate,
                UserId = x.UserId,
                UserFirstName = x.UserFirstName,
                UserLastName = x.UserLastName,
                UserName = x.UserFirstName + " " + x.UserLastName,
                UpdatedDate = x.UpdatedDate,
                Id = x.Id,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted,
                RoleId = x.RoleId,
                RoleName = x.RoleName,
                SelectedRoles = x.SelectedRoles
            }).BToDataSourceResultAsync(request);

            return result;

        }
    }
}
