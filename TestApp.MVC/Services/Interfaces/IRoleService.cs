
using MediatR;

using TestApp.Core.Application;
using TestApp.Core.Application.Roles.Commands;
using TestApp.Core.Application.Roles.Queries;
using TestApp.Core.Application.Roles.ViewModels;

namespace TestApp.MVC.Services.Interfaces
{
    public interface IRoleService
    {
        Task<ServiceResult<RoleDto>> AddRole(AddRoleCommand req);
        Task<ServiceResult<Unit>> DeleteRole(int Id, DeleteRoleCommand req);
        Task<ServiceResult<RoleDto>> UpdateRole(int Id, UpdateRoleCommand req);
        Task<ServiceResult<RoleDto>> GetRoleById(GetRoleByIdQuery req);
        Task<ListDsRoleView> ListDsRoleQuery(ListDsRoleQuery req);
        Task<ServiceResult<List<RoleDto>>> GetAllRole(GetAllRolesQuery req);
    }
}
