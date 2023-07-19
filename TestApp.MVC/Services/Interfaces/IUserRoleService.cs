using Bentas.O2.DynamicLinq;
using MediatR;
using TestApp.Core.Application;
using TestApp.Core.Application.UserRoles.Commands;
using TestApp.Core.Application.UserRoles.Queries;
using TestApp.Core.Application.UserRoles.ViewModels;

namespace TestApp.MVC.Services.Interfaces
{
    public interface IUserRoleService
    {
        Task<ServiceResult<UserRoleDto>> AddUserRole(AddUserRoleCommand req);
        Task<ServiceResult<Unit>> DeleteUserRole(int Id, DeleteUserRoleCommand req);
        Task<ServiceResult<UserRoleDto>> UpdateUserRole(int Id, UpdateUserRoleCommand req);
        Task<ServiceResult<UserRoleDto>> GetUserRoleById(GetUserRoleByIdQuery req);
        Task<BDataSourceResult<ListDsUserRoleView>> ListDsUserRoleQuery(ListDsUserRoleQuery req);
        Task<ServiceResult<List<UserRoleDto>>> GetAllUserRoles(GetAllUserRolesQuery req);
    }
}
