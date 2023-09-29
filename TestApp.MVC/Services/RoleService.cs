
using MediatR;
using TestApp.Core.Application;
using TestApp.Core.Application.Roles.Commands;
using TestApp.Core.Application.Roles.Queries;
using TestApp.Core.Application.Roles.ViewModels;
using TestApp.MVC.Extentions;
using TestApp.MVC.Services.Interfaces;
using TestApp.Service;

namespace TestApp.MVC.Services
{
    
    public class RoleService : IRoleService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private string ApiUrl => _configuration["ApiUrl"];

        public RoleService(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResult<RoleDto>> AddRole(AddRoleCommand req)
        {
            var model = await _httpClient.CustomPostAsync<ServiceResult<RoleDto>>($"{ApiUrl}/{ApiClient.AddRole}", req);
            return model;
        }

        public async Task<ServiceResult<Unit>> DeleteRole(int Id, DeleteRoleCommand req)
        {
            var model = await _httpClient.CustomDeleteAsync<ServiceResult<Unit>>($"{ApiUrl}/{ApiClient.DeleteRole}/" + req.Id, req);
            return model;
        }

        public async Task<ServiceResult<RoleDto>> GetRoleById(GetRoleByIdQuery req)
        {
            var model = await _httpClient.CustomGetAsync<ServiceResult<RoleDto>>($"{ApiUrl}/{ApiClient.GetRoleById}/" + req.Id, req);
            return model;
        }

        public async Task<ListDsRoleView> ListDsRoleQuery(ListDsRoleQuery req)
        {
            var model = await _httpClient.CustomPostAsync<ListDsRoleView>($"{ApiUrl}/{ApiClient.ListDsRole}", req);
            return model;
        }

        public async Task<ServiceResult<RoleDto>> UpdateRole(int Id, UpdateRoleCommand req)
        {
            var model = await _httpClient.CustomPutAsync<ServiceResult<RoleDto>>($"{ApiUrl}/{ApiClient.UpdateRole}/" + req.Id, req);
            return model;
        }

        public async Task<ServiceResult<List<RoleDto>>> GetAllRole(GetAllRolesQuery req)
        {
            var model = await _httpClient.CustomGetAsync<ServiceResult<List<RoleDto>>>($"{ApiUrl}/{ApiClient.GetAllRoles}", req);
            return model;
        }
    }
}
