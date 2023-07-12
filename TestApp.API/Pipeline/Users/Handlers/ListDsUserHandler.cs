using Bentas.O2.DynamicLinq;
using MediatR;
using TestApp.Core.Application.Users.Queries;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.Repository;

namespace TestApp.API.Pipeline.Users.Handlers
{
    public class ListDsUserHandler : IRequestHandler<ListDsUserQuery, BDataSourceResult<ListDsUserView>>
    {
        private readonly AppDbContext _context;

        public ListDsUserHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BDataSourceResult<ListDsUserView>> Handle(ListDsUserQuery request, CancellationToken cancellationToken)
        {
            var retVal = _context.Users.Select(x=> new ListDsUserView
            {
                Id = x.Id,
                BirthDate = x.BirthDate,
                CreatedDate = x.CreatedDate,
                Email = x.Email,
                FirstName = x.FirstName,
                ImagePath = x.ImagePath,
                LastName = x.LastName,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted,
                Password = x.Password,
                UpdatedDate = x.UpdatedDate
            });

            var result = await retVal.BToDataSourceResultAsync(request);
            return result;
        }
    }
}
