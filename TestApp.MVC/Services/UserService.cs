using Bentas.O2.DynamicLinq;
using MediatR;
using TestApp.Core.Application;
using TestApp.Core.Application.UserRoles.Queries;
using TestApp.Core.Application.Users.Commands;
using TestApp.Core.Application.Users.Queries;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.MVC.Extentions;
using TestApp.MVC.Services.Interfaces;
using TestApp.Service;

namespace TestApp.MVC.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private string ApiUrl => _configuration["ApiUrl"];

        public UserService(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResult<UserDto>> AddUser(AddUserCommand req)
        {
            var model = await _httpClient.CustomPostAsync<ServiceResult<UserDto>>($"{ApiUrl}/{ApiClient.AddUser}", req);
            return model;
        }

        public async Task<ServiceResult<Unit>> DeleteUser(int Id, DeleteUserCommand req)
        {
            var model = await _httpClient.CustomDeleteAsync<ServiceResult<Unit>>($"{ApiUrl}/{ApiClient.DeleteUser}/"+req.Id, req);
            return model;
        }

        public async Task<ServiceResult<UserDto>> GetUserById(GetUserByIdQuery req)
        {
            var model = await _httpClient.CustomGetAsync<ServiceResult<UserDto>>($"{ApiUrl}/{ApiClient.GetUserById}/"+req.Id, req);
            return model;
        }

        public async Task<BDataSourceResult<ListDsUserView>> ListDsUserQuery(ListDsUserQuery req)
        {
            var model = await _httpClient.CustomPostAsync<BDataSourceResult<ListDsUserView>>($"{ApiUrl}/{ApiClient.ListDsUser}", req);
            return model;
        }

        public async Task<ServiceResult<UserDto>> UpdateUser(int Id, UpdateUserCommand req)
        {
            var model = await _httpClient.CustomPutAsync<ServiceResult<UserDto>>($"{ApiUrl}/{ApiClient.UpdateUser}/"+req.Id, req);
            return model;
        }

        public async Task<ServiceResult<List<UserDto>>> GetAllUser(GetAllUsersQuery req)
        {
            var model = await _httpClient.CustomGetAsync<ServiceResult<List<UserDto>>>($"{ApiUrl}/{ApiClient.GetAllUsers}",req);
            return model;
        }
    }
}
