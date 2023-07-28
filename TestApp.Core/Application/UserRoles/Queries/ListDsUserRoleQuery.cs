using Bentas.O2.DynamicLinq;
using MediatR;
using TestApp.Core.Application.UserRoles.ViewModels;


namespace TestApp.Core.Application.UserRoles.Queries
{
    public class ListDsUserRoleQuery : BDataSourceRequest, IRequest<BDataSourceResult<ListDsUserRoleView>>
    {
        public UserRoleFilterView FilterView { get; set; } = new UserRoleFilterView();
    }
}
