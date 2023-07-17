using TestApp.Core.Application;
using TestApp.Core.Application.Login.Queries;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.MVC.Extentions;
using TestApp.MVC.Services.Interfaces;
using TestApp.Service;

namespace TestApp.MVC.Services
{
    public class LoginService : ILoginService
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        private string ApiUrl => _configuration["ApiUrl"];

        public LoginService(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResult<UserDto?>> Login(LoginQuery req)
        {
            var model = await _httpClient.CustomPostAsync<ServiceResult<UserDto>>($"{ApiUrl}/{ApiClient.Login}", req);
            return model;
        }
    }
}
