
using MediatR;
using TestApp.Core.Application.UserRoles.ViewModels;


namespace TestApp.Core.Application.UserRoles.Queries
{
    public class ListDsUserRoleQuery : IRequest<ListDsUserRoleView>
    {
        public UserRoleFilterView FilterView { get; set; } = new UserRoleFilterView();
    }
}
