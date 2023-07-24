using Bentas.O2.DynamicLinq;
using MediatR;
using TestApp.Core.Application;
using TestApp.Core.Application.UserRoles.Commands;
using TestApp.Core.Application.UserRoles.Queries;
using TestApp.Core.Application.UserRoles.ViewModels;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.MVC.Extentions;
using TestApp.MVC.Services.Interfaces;
using TestApp.Service;

namespace TestApp.MVC.Services
{
   
    public class UserRoleService : IUserRoleService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private string ApiUrl => _configuration["ApiUrl"];

        public UserRoleService(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResult<UserRoleDto>> AddUserRole(AddUserRoleCommand req)
        {
            var model = await _httpClient.CustomPostAsync<ServiceResult<UserRoleDto>>($"{ApiUrl}/{ApiClient.AddUserRole}", req);
            return model;
        }

        public async Task<ServiceResult<Unit>> DeleteUserRole(int Id, DeleteUserRoleCommand req)
        {
            var model = await _httpClient.CustomDeleteAsync<ServiceResult<Unit>>($"{ApiUrl}/{ApiClient.DeleteUserRole}/" + req.Id, req);
            return model;
        }

        public async Task<ServiceResult<UserRoleDto>> GetUserRoleById(GetUserRoleByIdQuery req)
        {
            var model = await _httpClient.CustomGetAsync<ServiceResult<UserRoleDto>>($"{ApiUrl}/{ApiClient.GetUserRoleById}/" + req.Id, req);
            return model;
        }

        public async Task<BDataSourceResult<ListDsUserRoleView>> ListDsUserRoleQuery(ListDsUserRoleQuery req)
        {
            var model = await _httpClient.CustomPostAsync<BDataSourceResult<ListDsUserRoleView>>($"{ApiUrl}/{ApiClient.ListDsUserRole}", req);
            return model;
        }

        public async Task<ServiceResult<UserRoleDto>> UpdateUserRole(int Id, UpdateUserRoleCommand req)
        {
            var model = await _httpClient.CustomPutAsync<ServiceResult<UserRoleDto>>($"{ApiUrl}/{ApiClient.UpdateUserRole}/" + Id, req);
            return model;
        }

        public async Task<ServiceResult<List<UserRoleDto>>> GetAllUserRoles(GetAllUserRolesQuery req)
        {
            var model = await _httpClient.CustomGetAsync<ServiceResult<List<UserRoleDto>>>($"{ApiUrl}/{ApiClient.GetAllUserRoles}", req);
            return model;
        }
    }
}
